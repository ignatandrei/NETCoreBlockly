# NETCoreBlockly
.NET Core API to Blockly


[![Build Status](https://dev.azure.com/ignatandrei0674/NETCoreBlockly/_apis/build/status/ignatandrei.NETCoreBlockly?branchName=master)](https://dev.azure.com/ignatandrei0674/NETCoreBlockly/_build/latest?definitionId=9&branchName=master)
[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/ignatandrei/NetCore2Blockly/blob/master/LICENSE)
[![NuGet](https://img.shields.io/nuget/v/NetCore2Blockly.svg)](https://www.nuget.org/packages/NetCore2Blockly)

# What it does
NETCoreBlockly generates [Blockly](https://developers.google.com/blockly) blocks for each of your controller actions. 


Demo at https://netcoreblockly.herokuapp.com/blockly.html

# How to install NETCoreBlockly in a .NET Core 3.1  WebAPI / MVC application

## Step 1:
Install https://www.nuget.org/packages/NetCore2Blockly/ by running the following command in the Package Manager Console:
> Install-Package NetCore2Blockly

## Step 2:
Modify Startup.cs by adding
```csharp
public void ConfigureServices(IServiceCollection services)
        {
            //last line
            services.AddBlockly();
        }
public void Configure(IApplicationBuilder app, IWebHostEnvironment env){
        //if you plan to use as html, do not forget app.UseStaticFiles
        //last line
        app.UseBlockly(); 
}
```

## Step 3:
Download from 
https://github.com/ignatandrei/NetCore2Blockly/docs/blockly.zip 

and put all contents in a wwwroot in the root of your site

## Step 4:
Run the application and browse to  /blockly.html

That's all!
