# Install (Windows)

## Install .NET
Navigate to https://dotnet.microsoft.com/en-us/download/dotnet/6.0 and download SDK + install

Navigate to the project folder and build the solution
```
dotnet build
```

## Install PowerShell
```
dotnet tool install --global PowerShell
```

## Install Playwright
Install Playwright CLI
```
dotnet tool install --global Microsoft.Playwright.CLI
```

Install playwright tools
- navigate to root folder and run
```
playwright install
```

## Install Specflow (Visual Studio 2022)
- Install Specflow extension for VS 2022
- link: [extension](https://marketplace.visualstudio.com/items?itemName=TechTalkSpecFlowTeam.SpecFlowForVisualStudio2022)
- note: there is an open bug with the Specflow.Autofac(v3.9.74) nuget (it still works in VS2022 but there is a visual issue) -> https://github.com/SpecFlowOSS/SpecFlow.VS/issues/91
- nuget link: [specflow-auto-fac-nuget](https://www.nuget.org/packages/SpecFlow.Autofac/)

# Configurations
There are two types of config files:
- `appsettings.json` file to instantiate `BrowserNewContextOptions` -> Viewport and BaseURL can be set here
```json
{
  "browserContextOptions": {
    "baseURL": "https://strypes.eu",
    "viewportSize": {
      "width": 1920,
      "height": 1080
    }
  }
}
```

- `specflow.actions.json` file to setup Playwright browser options -> browser type and headless mode can be set here
  - Supported Browsers
        - Chromium
        - Firefox
        - Edge
        - Chrome
```json
{
  "playwright": {
    "browser": "chrome",
    "defaultTimeout": 30,
    "headless": false,
    "slowmo": 100
  }
}
```

  - see [specflow.actions](https://github.com/SpecFlowOSS/SpecFlow.Actions/blob/main/Plugins/SpecFlow.Actions.Playwright/Readme.md)

# Run tests
run tests using "Test Explorer" in Visual studio (tests should be discovered after solution build)

run all tests (from root dir)
```
dotnet test
```

run specific test
```
dotnet test  --filter "Name~SearchByAKeyword"
```
 