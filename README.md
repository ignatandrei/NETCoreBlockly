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

*Demo* at https://netcoreblockly.herokuapp.com/ ( play with the links from the bottom)

*Demo* Video at https://www.youtube.com/watch?v=GptkNWjmCzk

Sample Project is TestBlocklyHtml from this repository

*Contributors welcome!* - please send email to <img src='email.png' height='10px' title = "please write email from image" alt='email'></img> or see issues tab.

# How to install NETCore2Blockly in a .NET Core 3.1  WebAPI / MVC application in 3 steps + run application

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

To see the UI , please add
```csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env){
       
       app.UseBlocklyUI(); // you can customize (with BlocklyUIOptions argument )header name, start blocks, others... 
       //you can add  storage like local storage or sqlite 
       //app.UseBlocklyLocalStorage();
       //app.UseBlocklySqliteStorage() ; // other nuget package
       app.UseBlockly();
}
```


## Run application

Run the application from VS and browse to  /blockly.html

## That's all !( 3 steps + run )


## Advanced usage remote data


### For Remote Swagger ( CORS activated )

app.UseBlocklySwagger("petstore", "https://petstore.swagger.io/v2/swagger.json")

You can see demo at https://netcoreblockly.herokuapp.com/ ,colapse category local function, expand category Swagger.

See link 25 from https://netcoreblockly.herokuapp.com/ 


### For ODATA ( local or remote - CORS activated if remote)

app.UseBlocklyOData("OdataV4", "https://services.odata.org/TripPinRESTierService/");

You can see demo at https://netcoreblockly.herokuapp.com/ ,colapse category local function, expand category OData.


### For GraphQL (local or remote - CORS activated if remote)- Work In progress

app.UseBlocklyGraphQL("localGraphql", "/graphql");

You can see demo at https://netcoreblockly.herokuapp.com/ ,colapse category local function, expand category GraphQL.

See link 32,33 from https://netcoreblockly.herokuapp.com/ 

### For authentication  - JSON Web Tokens
 
See links 22 for JWT and 31 for Auth0  from https://netcoreblockly.herokuapp.com/ 

Also, it works with Active Directory enabled - see Authentication category.

### For adding headers to Http requests
 
See links 22 for JWT from https://netcoreblockly.herokuapp.com/ 

### For exporting data as CSV

See link 2  from https://netcoreblockly.herokuapp.com/ 

### For exporting data as image

See link 1  from https://netcoreblockly.herokuapp.com/ 

### Making a simple CRUD ( create ,read, update , delete ) application

See link 6,7,8,9,   from https://netcoreblockly.herokuapp.com/ 

### Adding your blocks

Please see how I add  CustomBlocksForUI below

```csharp
app.UseBlocklyUI(new BlocklyUIOptions()
            {
                StartBlocks = StartBlocksForUI,
                HeaderName = "Demo test for .NET Core WebAPI To Blockly ( demo site with Blockly +  swaggers + odata loaded + graphql)",
                CustomBlocks = CustomBlocksForUI
            });
```

## More information

Download the source code, run the TestBlocklyHtml project ( in the test folder ).

See there 

 region blockly needed

and

 region blockly optional 


and follow the code.

All other code is just boilerplate for Swagger, OData,GraphQL that are mandatory for demo'ing the application, not for Blockly2NetCore itself.

## Testing

There is a integration testing at \IntegrationTesting that tests the UI.
Generates images and verifies " program complete " textbox.

There are 42 tests that you can also click the demo at https://netcoreblockly.herokuapp.com/
( see links on the bottom of the page)

## Contributors ✨

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

