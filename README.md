# WAVit Daily Reporting

## Introduction 

This is a newer version of the old WAVit Reporting, made in a ASP.NET MVC application. The purpose of this page is allowing the WAVit users to track their transactions along the time. For this new version, a page was added, called "Analytics", making possible for the user to see some data about some specif period of time.

## NuGet Packages

|Package|Status|
|-------|------|
|Azure.Identity|[Version 1.11.4](https://www.nuget.org/packages/azure.identity)|
|Azure.Security.KeyVaults.Secrets|[Version 4.6.0](https://www.nuget.org/packages/Azure.Security.KeyVault.Secrets/)|
|Chart.js|[Version 3.7.1](https://www.nuget.org/packages/Chart.js)|
|Microsoft.AspNetCore.Identity.EntityFrameworkCore|[Version 8.0.6](https://www.nuget.org/packages/Microsoft.AspNetCore.Identity.EntityFrameworkCore/9.0.0-rc.2.24474.3)|
|Microsoft.Data.SqlClient|[Version 5.2.1](https://www.nuget.org/packages/Microsoft.Data.SqlClient/6.0.0-preview2.24304.8)|
|Microsoft.EntityFrameworkCore|[Version 8.0.6](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/9.0.0-rc.2.24474.1)|
|Microsoft.EntityFrameworkCore.SqlServer|[Version 8.0.6](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/9.0.0-rc.2.24474.1)|
|Microsoft.EntityFrameworkCore.Tools|[Version 8.0.6](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools/9.0.0-rc.2.24474.1)|
|Newtonsoft.Json|[Version 13.0.3](https://www.nuget.org/packages/Newtonsoft.Json)|
|NLog|[Version 5.3.2](https://www.nuget.org/packages/NLog)|
|NumSharp|[Version 0.30.0](https://www.nuget.org/packages/NumSharp)|
|OfficeOpenXml.Extension.AspNetCore|[Version 1.0.0](https://www.nuget.org/packages/OfficeOpenXml.Extension.AspNetCore)|
|Uno.UI|[Version 5.2.161](https://www.nuget.org/packages/Uno.UI/5.6.0-dev.392)|

## Getting Started

The project is built on the .NET 8.0 version, using the MVC architecture 

## Project structure (MVC App)

Project/ </br>
├── /Common/ </br>
├── /Controllers/ </br>
├── /Data/ </br>
├── /Models/ </br>
├── /Views/ </br>
├── /wwwroot/ </br>
├── appsettings.json </br>
└── README.md </br>

### Explanation of the contents

+ **Common** - Pull the secrets from the Azure using keyvaults.
+ **Controllers** - Handle the behavior, actions and data will be sent and pulled from the views (pages).
+ **Data** - Contains the methods to pull data from DB.
+ **Models** - The models what are going to fit on the database request results.
+ **Views** - All the pages of the project, starting from the main page "/Shared/_Layout.cshtml" 
+ **wwwroot** - The public contents, such as images, js and css files

## Frameworks

1.	ASP.NET Core APP 
2.  .NET Core APP

## Build and Test Locally

To run the project, make sure you are following the steps below:

### **Requirements**
- AZURE CLI 
- .NET 8.0 version
- Must be logged in your Azure account on Visual Studio or Visual Studio Code

### Running the project

- On Visual Studio (2022 Version recommended), after you make sure you have the requirements above, build the project and run it using HTTPS method.


- On Visual Studio Code, by the terminal, it's highly recommended to have installed some Solution explorer. But in case you may haven't, just follow the steps to run.
	1. On the terminal, navigate to the folder where the file "Program.cs" is.
	2. A build is highly recommended to check if everything is working normally. Use this command to build the project.
	
```
dotnet build
```

If there's no errors after the building, run the project using this command:

```
dotnet watch run
```

## License

