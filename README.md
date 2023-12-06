# Vulnerable .NET Core Webapp

## About
This is an intentionally vulnerable webapp written in .NET. It is intended to provide code examples using .NET to go alongside the [PortSwigger Web Academy](https://portswigger.net/web-security/dashboard). See [the wiki](https://github.com/alexwaibel/vulnerable-aspnetcore-webapp/wiki) for a write-up.

WARNING: This web app is intentionally riddled with vulnerabilities. DO NOT upload it to a host facing the public internet. For best results, run this in a virtual machine

## Getting Started
To run the application, follow the below instructions.

### Prerequisites
- [.NET Core 8.0 SDK](https://dotnet.microsoft.com/en-us/download) installed

### Running Application
- Clone this repo and cd into the root directory
    ```bash
    cd vulnerable-aspnetcore-webapp
    ```
- Start the application
    ```bash
    dotnet watch run
    ```
- In the terminal output, look for the line `Now listening on: http://localhost:{port}` where the `{port}` will be a randomly selected port
- Navigate to the above address in your browser of choice