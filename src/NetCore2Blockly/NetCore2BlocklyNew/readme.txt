What it does NETCore2Blockly

Read this better at https://github.com/ignatandrei/netcoreblockly

NETCore2Blockly generates Blockly blocks for each of your controller actions.

Demo at https://netcoreblockly.herokuapp.com/blockly.html ( play with the links from the bottom)

Demo Video at https://www.youtube.com/watch?v=GptkNWjmCzk

How to install NETCore2Blockly in a .NET Core 5 WebAPI / MVC application

Step 1:
Install https://www.nuget.org/packages/NetCore2Blockly/ by running the following command in the Package Manager Console:

Install-Package NetCore2Blockly

Step 2:
Modify Startup.cs by adding
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    app.UseDefaultFiles();
    app.UseStaticFiles();
    //your code ...
}

public void Configure(IApplicationBuilder app, IWebHostEnvironment env){
//should have swagger
app.UseSwagger();


app.UseBlocklyUI(env);
app.UseEndpoints(endpoints =>
{
}
endpoints.UseBlocklyAutomation();
}



# How to install NETCore2Blockly in a .NET Core 6  WebAPI / MVC application in 2 steps + run application

## Step 1:
Install https://www.nuget.org/packages/NetCore2Blockly/ by running the following command in the Package Manager Console:
> Install-Package NetCore2Blockly

## Step 2:

app.UseBlocklyUI(app.Environment);
//after app.MapControllers();
app.UseBlocklyAutomation();


Step 3:
Run the application and browse to /blocklyautomation or /blocklyautomation/index.html


That's all!