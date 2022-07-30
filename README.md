# NETCore2Blockly

<!-- ALL-CONTRIBUTORS-BADGE:START - Do not remove or modify this section -->
[![All Contributors](https://img.shields.io/badge/all_contributors-6-orange.svg?style=flat-square)](#contributors-)
<!-- ALL-CONTRIBUTORS-BADGE:END -->
[![Build Status](https://dev.azure.com/ignatandrei0674/NETCoreBlockly/_apis/build/status/ignatandrei.NETCoreBlockly?branchName=master)](https://dev.azure.com/ignatandrei0674/NETCoreBlockly/_build?definitionId=9)
[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/ignatandrei/NetCore2Blockly/blob/master/LICENSE)
[![NuGet](https://img.shields.io/nuget/v/NetCore2Blockly.svg)](https://www.nuget.org/packages/NetCore2Blockly)
![Generate Thanks Outdated Licenses](https://github.com/ignatandrei/NETCoreBlockly/workflows/.NET%20Core/badge.svg)

# What it does
NETCore2Blockly generates [Blockly](https://developers.google.com/blockly) blocks for each of your controller actions. 

*Demo* at https://netcoreblockly.herokuapp.com/ 

*Demo* Video at https://www.youtube.com/watch?v=GptkNWjmCzk

Sample Project is TestBlocklyHtml from this repository

*Contributors welcome!* - please send email to <img src='email.png' height='10px' title = "please write email from image" alt='email'></img> or see issues tab.


# How to install NETCore2Blockly in a .NET Core 6  WebAPI / MVC application in 2 steps + run application

## Step 1:
Install https://www.nuget.org/packages/NetCore2Blockly/ by running the following command in the Package Manager Console:
> Install-Package NetCore2Blockly

## Step 2:
```csharp
//after app.MapControllers();
app.UseBlocklyUI(app.Environment);
app.UseBlocklyAutomation();

```


## Run application

Run the application from VS and browse to  /BlocklyAutomation/ or /BlocklyAutomation/index.html

## That's all !( 2 steps + run )


# How to install NETCore2Blockly in a .NET Core 5  WebAPI / MVC application in 2 steps + run application

## Step 1:

Install https://www.nuget.org/packages/NetCore2Blockly/ by running the following command in the Package Manager Console:
> Install-Package NetCore2Blockly


## Step 2:
Modify Startup.cs by adding
```csharp
public void ConfigureServices(IServiceCollection services)
{
  //somewhere generate the swagger
  services.AddSwaggerGen(c =>
  {
      c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
  });


}

public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
  //last line
  app.UseDefaultFiles();
  app.UseStaticFiles();
  app.UseSwagger();
  app.UseBlocklyUI(env);
//code
  app.UseEndpoints(endpoints =>
  {
      endpoints.MapControllers();
      endpoints.UseBlocklyAutomation();
  });
}
```

## Run application

Run the application from VS and browse to  /BlocklyAutomation/ or /BlocklyAutomation/index.html




# How to install NETCore2Blockly in a .NET Core 3.1  WebAPI / MVC application in 2 steps + run application

##  Step 1
Install-Package Swashbuckle.AspNetCore -Version 5.6.3
Install-Package NetCore2Blockly -Version 3.2022.224.16

## Step 2

```csharp
 app.UseDefaultFiles();
 app.UseStaticFiles();
 app.UseSwagger();
 //code
 app.UseBlocklyUI(env);
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.UseBlocklyAutomation();
});
```
 
## Run application

Run the application from VS and browse to  /BlocklyAutomation/ or /BlocklyAutomation/index.html

## Migrating from 1 
 
Replace

using NetCore2Blockly; => using NetCore2BlocklyNew;
app.UseBlocklyUI(); =>   app.UseBlocklyUI(env);
Delete app.UseBlockly(); =>
Add => endpoints.UseBlocklyAutomation();

Navigate to /blocklyAutomation

# Advanced usage remote data


## For Remote Swagger ( CORS activated )

TBC: create BlocklyAutomation/assets/loadAtStartup/swaggers.json 


## For authentication  - JSON Web Tokens
 
See Demos from https://netcoreblockly.herokuapp.com/ 

Also, it works with Active Directory enabled - see Authentication category.

## For adding headers to Http requests
 
See https://netcoreblockly.herokuapp.com/BlocklyAutomation/automation/loadexample/jwt

## For exporting data as CSV

See https://netcoreblockly.herokuapp.com/BlocklyAutomation/automation/loadexample/NetCoreBlockly_SaveCSV

## For exporting data as image

See https://netcoreblockly.herokuapp.com/BlocklyAutomation/automation/loadexample/saveImage

## Making a simple CRUD ( create ,read, update , delete ) application

See https://netcoreblockly.herokuapp.com/BlocklyAutomation/automation/loadexample/NetCoreBlockly_DeleteDepartment
or search for department in demos

## Adding your blocks

Create BlocklyAutomation\assets\loadAtStartup\customCategories.txt

# More information

Download the source code, run the TestNetCorePackage project ( in the test folder ).


# Testing


# Contributors ✨

Thanks goes to these wonderful people ([emoji key](https://allcontributors.org/docs/en/emoji-key)):

If you want to contribute, that is plenty of work to be done -see issues tab .

<!-- ALL-CONTRIBUTORS-LIST:START - Do not remove or modify this section -->
<!-- prettier-ignore-start -->
<!-- markdownlint-disable -->
<table>
  <tr>
    <td align="center"><a href="http://www.chestiiautomate.ro/"><img src="https://avatars1.githubusercontent.com/u/4983185?v=4" width="100px;" alt=""/><br /><sub><b>Cosmin Popescu</b></sub></a><br /><a href="https://github.com/ignatandrei/NETCoreBlockly/commits?author=cosminpopescu14" title="Code">💻</a></td>
    <td align="center"><a href="https://github.com/adriannasui"><img src="https://avatars3.githubusercontent.com/u/8627433?v=4" width="100px;" alt=""/><br /><sub><b>Adrian Nasui</b></sub></a><br /><a href="https://github.com/ignatandrei/NETCoreBlockly/commits?author=adriannasui" title="Documentation">📖</a></td>
    <td align="center"><a href="https://github.com/tudorgbiliescu"><img src="https://avatars3.githubusercontent.com/u/8693567?v=4" width="100px;" alt=""/><br /><sub><b>Tudor Iliescu</b></sub></a><br /><a href="https://github.com/ignatandrei/NETCoreBlockly/commits?author=tudorgbiliescu" title="Code">💻</a></td>
    <td align="center"><a href="https://github.com/robertszabobv"><img src="https://avatars0.githubusercontent.com/u/9404144?v=4" width="100px;" alt=""/><br /><sub><b>robertszabobv</b></sub></a><br /><a href="https://github.com/ignatandrei/NETCoreBlockly/commits?author=robertszabobv" title="Code">💻</a></td>
    <td align="center"><a href="https://github.com/NoahAndrews"><img src="https://avatars1.githubusercontent.com/u/10224994?v=4" width="100px;" alt=""/><br /><sub><b>Noah Andrews</b></sub></a><br /><a href="https://github.com/ignatandrei/NETCoreBlockly/commits?author=NoahAndrews" title="Code">💻</a></td>
    <td align="center"><a href="https://github.com/es-rene99"><img src="https://avatars3.githubusercontent.com/u/43294836?v=4" width="100px;" alt=""/><br /><sub><b>Rene Escalante</b></sub></a><br /><a href="https://github.com/ignatandrei/NETCoreBlockly/commits?author=es-rene99" title="Code">💻</a></td>
  </tr>
</table>

<!-- markdownlint-enable -->
<!-- prettier-ignore-end -->
<!-- ALL-CONTRIBUTORS-LIST:END -->

This project follows the [all-contributors](https://github.com/all-contributors/all-contributors) specification. Contributions of any kind welcome!

