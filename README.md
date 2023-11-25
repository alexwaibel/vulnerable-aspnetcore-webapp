# Vulnerable .NET Core Webapp

## About
This is an intentionally vulnerable webapp written in .NET Core. It is intended to provide code examples using .NET Core to go alongside the [Portswigger Web Academy](https://portswigger.net/web-security/dashboard). This is primarily done as a learning exercise for myself but I am happy to accept community discussion and contributions.

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