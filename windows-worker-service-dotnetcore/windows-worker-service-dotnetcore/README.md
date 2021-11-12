# Nuget Packages

- Microsoft.Extensions.Http: To get an HttpClientFactory and create clients that can execute http requests.
- Serilog.AspNetCore: Lo create a logger to a file in the C drive.
- Microsoft.Extensions.Hosting.WindowsService: To execute the worker as a Windows Service (Needed to update Microsoft.Extensions.Hosting)

# Publish And Install

- Publish our application in a local Directory
- Execute PowerShell as an Administrator

> New-Service -Name { SERVICE NAME } -BinaryPathName { EXE FILE PATH } -Description "{ DESCRIPTION }" -DisplayName "{ DISPLAY NAME }" -StartupType Automatic

(Replace values inside curly brackets)