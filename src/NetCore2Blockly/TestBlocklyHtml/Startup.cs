using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NetCore2Blockly;
using TestBlocklyHtml.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Logging;
using System.Text.Json.Serialization;

namespace TestBlocklyHtml
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowAll",
                                  builder =>
                                  {
                                      builder
                                      .AllowAnyOrigin()
                                      .AllowAnyMethod()
                                      .AllowAnyHeader()
                                      ;
                                  });
            });
            services.AddControllers().AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
            services.AddBlockly();
            services.AddDbContext<testsContext>(options => options

              .UseInMemoryDatabase(databaseName: "MyDB"));

        
            //this is not necessary to be added
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Please see blockly.html",
                    Version = "v1",
                    Description = " Please see https://github.com/ignatandrei/netcoreblockly"
                });
                
            });

            //var key = Encoding.ASCII.GetBytes(Configuration["ApplicationSecret"]);
            //please change also in AuthorizationToken . 
            var key = Encoding.ASCII.GetBytes("mySecretKeyThatShouldBeStoredInConfiguration");
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = false
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
                IdentityModelEventSource.ShowPII = true;
            }
            app.UseCors("AllowAll");

            //just developer testing! do not use in production
            app.UseFileServer(enableDirectoryBrowsing: true);
            //you can use simply this
            //app.UseBlocklyUI();
            //or you can use a start blocks
            app.UseBlocklyUI(new BlocklyUIOptions()
            {
                StartBlocks = StartBlocksForUI,
                HeaderName = "Demo test for .NET Core WebAPI ( site with Blockly + 2 swaggers loaded)"
            });

            app.UseBlocklyLocalStorage();//this is not necessary , if you use app.UseBlocklyUI();
            //app.UseBlocklySwagger("heroku", "https://netcoreblockly.herokuapp.com/swagger/v1/swagger.json");
            app.UseBlocklySwagger("petstore", "https://petstore.swagger.io/v2/swagger.json");
            app.UseBlocklySwagger("apiGuru","https://api.apis.guru/v2/swagger.yaml");
            //TODO: find if figshare respects swagger or not
            //app.UseBlocklySwagger("figShare", "https://docs.figshare.com/swagger.json");
        
              //app.UseBlocklySqliteStorage();
              //this is not necessary to be added
            app.UseSwagger();

            //this is not necessary to be added
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseBlockly();
        }
        private readonly string StartBlocksForUI = @"<xml xmlns='https://developers.google.com/blockly/xml'>
  <block type='variables_set' y='20' x='20' inline='true'>
    <field id='hO`?kR*XbVn|uJq:?jJ_' name='VAR'>n</field>
    <value name='VALUE'>
      <block type='math_number'>
        <field name='NUM'>1</field>
      </block>
    </value>
    <next>
      <block type='controls_repeat_ext' inline='true'>
        <value name='TIMES'>
          <block type='math_number'>
            <field name='NUM'>4</field>
          </block>
        </value>
        <statement name='DO'>
          <block type='variables_set' inline='true'>
            <field id='hO`?kR*XbVn|uJq:?jJ_' name='VAR'>n</field>
            <value name='VALUE'>
              <block type='math_arithmetic'>
                <field name='OP'>MULTIPLY</field>
                <value name='A'>
                  <block type='variables_get'>
                    <field id='hO`?kR*XbVn|uJq:?jJ_' name='VAR'>n</field>
                  </block>
                </value>
                <value name='B'>
                  <block type='math_number'>
                    <field name='NUM'>2</field>
                  </block>
                </value>
              </block>
            </value>
            <next>
              <block type='text_print'>
                <value name='TEXT'>
                  <block type='variables_get'>
                    <field id='hO`?kR*XbVn|uJq:?jJ_' name='VAR'>n</field>
                  </block>
                </value>
                <next>
                  <block type='text_print'>
                    <value name='TEXT'>
                      <block type='WeatherForecast_GET'></block>
                    </value>
                  </block>
                </next>
              </block>
            </next>
          </block>
        </statement>
      </block>
    </next>
  </block>
</xml>";
    }
}