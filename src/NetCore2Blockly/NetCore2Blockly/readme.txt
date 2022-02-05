What it does NETCore2Blockly

Read this better at https://github.com/ignatandrei/netcoreblockly

NETCore2Blockly generates Blockly blocks for each of your controller actions.

Demo at https://netcoreblockly.herokuapp.com/blockly.html ( play with the links from the bottom)

Demo Video at https://www.youtube.com/watch?v=GptkNWjmCzk

How to install NETCore2Blockly in a .NET Core 3.1 WebAPI / MVC application
Step 1:
Install https://www.nuget.org/packages/NetCore2Blockly/ by running the following command in the Package Manager Console:

Install-Package NetCore2Blockly

Step 2:
Modify Startup.cs by adding

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
Step 3:

To see the UI , please add

public void Configure(IApplicationBuilder app, IWebHostEnvironment env){
       
       app.UseBlocklyUI();
}


Step 4:
Run the application and browse to /blockly.html

For WebAPI (local):
app.UseBlocklyUI();

For Swagger ( local or remote )
app.UseBlocklySwagger("petstore", "https://petstore.swagger.io/v2/swagger.json")

For ODATA ( local or remote)
app.UseBlocklyOData("OdataV4", "https://services.odata.org/TripPinRESTierService/");

For GraphQL
app.UseBlocklyGraphQL("localGraphql", "/graphql");

For authentication
See links 22 for JWT and 31 for Auth0 from https://netcoreblockly.herokuapp.com/

That's all!


## Migrating from 1 
 
Replace

using NetCore2Blockly; => using NetCore2BlocklyNew;
app.UseBlocklyUI(); =>   app.UseBlocklyUI(env);
Delete app.UseBlockly(); =>
Add => endpoints.UseBlocklyAutomation();

Navigate to /blocklyAutomation