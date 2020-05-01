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

Recommended:
To see the UI , please add

public void Configure(IApplicationBuilder app, IWebHostEnvironment env){
       
       app.UseBlocklyUI();
}
Feel free to modify:
Download from Build Status the blockly.zip and put all contents in a wwwroot in the root of your site

Step 4:
Run the application and browse to /blockly.html

That's all!