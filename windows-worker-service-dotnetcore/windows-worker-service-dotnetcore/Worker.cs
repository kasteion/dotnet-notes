using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace windows_worker_service_dotnetcore
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IHttpClientFactory httpClientFactory;
        private List<string> Urls = new List<string>()
        {
            "https://google.com"
        };

        // El IHttpClientFactory es por el nuget package Microsoft.Extensions.Http
        public Worker(ILogger<Worker> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            this.httpClientFactory = httpClientFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                // await Task.Delay(1000, stoppingToken);
                try
                {
                    await PollUrls();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error ocurred while polling urls");
                }
                finally
                {
                    await Task.Delay(1000, stoppingToken);
                }
            }
        }

        private async Task PollUrls()
        {
            List<Task> tasks = new List<Task>();
            foreach(var url in Urls)
            {
                tasks.Add(PollUrl(url));
            }
            await Task.WhenAll(tasks);
        }

        private async Task PollUrl(string url)
        {
            try
            {
                var client = httpClientFactory.CreateClient();
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("{url} is online.", url);
                }
                else
                {
                    _logger.LogWarning("{url} is offline", url);
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "{url} is offline.", url);
            }
        }
    }
}
