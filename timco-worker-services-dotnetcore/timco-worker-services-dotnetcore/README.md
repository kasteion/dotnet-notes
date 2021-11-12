# Nuget Packages

- Serilog.AspNetCore
- Serilog.Sinks.File
- Microsoft.Extensions.Hosting.WindowServices

# Publish & Install

- Publish in a Directory
- Execute PowerShell as an Administrator

> sc.exe crete WebsiteStatus bipath= c:\temp\workerservice\WebsiteStatus.exe start= auto

(The spaces are necesary according to docs)

# Uninstall

- First stop the service to ensure a graceful shutdown.
- Open powershell with Administration pemission

> sc.exe delete WebsiteStatus