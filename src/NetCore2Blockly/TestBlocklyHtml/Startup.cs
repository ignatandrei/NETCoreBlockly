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
//using NetCore2Blockly;
using TestBlocklyHtml.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Logging;
using System.Text.Json.Serialization;
using Microsoft.OData.Edm;
using OdataToEntity.EfCore.DynamicDataContext;
using OdataToEntity.EfCore.DynamicDataContext.InformationSchema;
using OdataToEntity.AspNetCore;
using Microsoft.Net.Http.Headers;
//using Hellang.Middleware.ProblemDetails;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using TestBlocklyHtml.resolveAtRuntime;
using GraphQL.Server;
using TestBlocklyHtml.GraphQL;
using GraphQL;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using GraphQL.Server.Ui.Playground;
using System.Reflection;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HCVersion;
using AMSWebAPI;
using NetCore2BlocklyNew;

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
            //services.AddSingleton<IActionDescriptorChangeProvider>(MyActionDescriptorChangeProvider.Instance);
            //services.AddSingleton(MyActionDescriptorChangeProvider.Instance);
            #region health check
            string name = Assembly.GetExecutingAssembly().GetName().Name;
            //services.AddHealthChecks()
            //    .AddCheck<HealthCheckVersion>(name)
            //    ;
            //services
            //    .AddHealthChecksUI(setup =>
            //    {
            //        setup.AddHealthCheckEndpoint("All", $"/hc");
            //    })
            //    .AddInMemoryStorage()
            //    ;
            //navigate to healthchecks-ui
            #endregion
            services.AddProblemDetails();
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
            //TODO: odata
            //services.AddOData();
            services.AddSingleton<VisualizeDot>();
            services.AddControllers(
                #region blockly optional
                //config => config.Filters.Add<BlocklyActionRegisterFilter>()
                #endregion
                )

                .AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
            #region for odata
            services.AddMvcCore(options =>
            {
                //TODO: odata
                //foreach (var outputFormatter in options.OutputFormatters.OfType<ODataOutputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
                //{
                //    outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                //}
                //foreach (var inputFormatter in options.InputFormatters.OfType<ODataInputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
                //{
                //    inputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                //}
            });
            #endregion
            #region blockly needed
            //services.AddBlockly();
            #endregion
            #region for graphql
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            #endregion
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
            //services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            //TODO : graphql
            //services.AddGraphQL(o => { o.ExposeExceptions = true; })
            //                .AddGraphTypes(ServiceLifetime.Scoped);

            services.AddScoped<DepartmentRepository>();
            services.AddScoped<DepartmentSchema>();

            //var key = Encoding.ASCII.GetBytes(Configuration["ApplicationSecret"]);
            //please change also in AuthorizationToken . 
            var key = Encoding.ASCII.GetBytes("mySecretKeyThatShouldBeStoredInConfiguration");
            services.AddAuthentication()
                .AddJwtBearer("AuthoBearer",options =>
                {
                    options.Authority = "https://ignatandrei.eu.auth0.com/";
                    options.Audience = "mytest";
                    //options.TokenValidationParameters = new TokenValidationParameters
                    //{
                    //    NameClaimType = ClaimTypes.NameIdentifier
                    //};
                })
                .AddJwtBearer("CustomBearer", options =>
                {
                    options.Events = new JwtBearerEvents()
                    {
                        OnMessageReceived = ctx =>
                        {
                            if (!(ctx?.Request?.Headers?.ContainsKey("Authorization") ?? true))
                            {
                                ctx.NoResult();
                                return Task.CompletedTask;
                            };
                            var auth = ctx.Request.Headers["Authorization"].ToString();
                            if (string.IsNullOrEmpty(auth))
                            {
                                ctx.NoResult();
                                return Task.CompletedTask;
                            }
                            if (!auth.StartsWith("CustomBearer ", StringComparison.OrdinalIgnoreCase))
                            {
                                ctx.NoResult();
                                return Task.CompletedTask;
                            }

                            ctx.Token = auth.Substring("CustomBearer ".Length).Trim();
                            return Task.CompletedTask;

                        }
                    };
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = false
                    };
                });
            services.AddAuthorization(options =>
            {
                //var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(
                //    //JwtBearerDefaults.AuthenticationScheme,
                //    "CustomBearer");
                //defaultAuthorizationPolicyBuilder =
                //    defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();
                //options.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
                options.AddPolicy("Auth0Policy", policy =>
                {
                    policy.AuthenticationSchemes.Add("AuthoBearer");
                    policy.RequireAuthenticatedUser();
                });
                options.AddPolicy("CustomBearer", policy =>
                {
                    policy.AuthenticationSchemes.Add("CustomBearer");
                    policy.RequireAuthenticatedUser();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseProblemDetails();
            #region odata
            //todo  odata
            //IEdmModel edmModel = ModelDB();
            #endregion
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
                IdentityModelEventSource.ShowPII = true;
                //just developer testing! do not use in production
         
            }
            app.UseCors("AllowAll");
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseFileServer(enableDirectoryBrowsing: true);
            #region blockly needed
            //you can use simply this
            //app.UseBlocklyUI();
            //or you can use a start blocks
            //app.UseBlocklyUI(new BlocklyUIOptions()
            //{
            //    StartBlocks = StartBlocksForUI,
            //    HeaderName = "Demo test for .NET Core WebAPI To Blockly ( demo site with Blockly +  swaggers + odata loaded + graphql)",
            //    CustomBlocks = CustomBlocksForUI,
            //    RunTimeString = c =>
            //    {
            //        var str=$"console.log('this is from runtime blocks {DateTime.Now.Ticks}');";
            //        var val = c.GetRequiredService<IConfiguration>().GetSection("myCustomValue").Value;
            //        str += val;
            //        return str;
            //    }
            //}); 

            //app.UseBlocklyLocalStorage();
            //app.UseBlocklySqliteStorage();
            #endregion
            #region blockly optional
            //app.UseBlocklySwagger("petstore", "https://petstore.swagger.io/v2/swagger.json");
            //Cors, http, https issues and latest / solving
            //app.UseBlocklySwagger("xkcd", "https://raw.githubusercontent.com/APIs-guru/openapi-directory/master/APIs/xkcd.com/1.0.0/openapi.yaml");
            //app.UseBlocklySwagger("apiGuru", "https://api.apis.guru/v2/swagger.yaml");
            //app.UseBlocklySwagger("heroku", "https://netcoreblockly.herokuapp.com/swagger/v1/swagger.json");
            //TODO: find if figshare respects swagger or not
            //app.UseBlocklySwagger("figShare", "https://docs.figshare.com/swagger.json");
            //app.UseBlocklyOData("localodata", "/odata");
            //app.UseBlocklyOData("OdataV4", "https://services.odata.org/TripPinRESTierService/");
            //app.UseBlocklyOData("heroku", "https://netcoreblockly.herokuapp.com/odata");
            //app.UseBlocklyOData("OdataV3", "https://services.odata.org/V3/OData/OData.svc");
            //app.UseBatchBlocklyLinks(this.Configuration.GetSection("NetCoreBlockly:OtherLinks").Get<BLocklyOtherLinks>());
            //app.UseBlocklyLinksFromConfig(this.Configuration);
            #endregion
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
            app.UseBlocklyUI(env);
            //TODO : graphql

            //app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
            //app.UseGraphQL<DepartmentSchema>();
            //app.UseBlocklyRegisterMiddleware();
            app.UseEndpoints(endpoints =>
            {
                //if (edmModel != null)
                //{
                //    endpoints.EnableDependencyInjection();
                //    endpoints.Select().Expand().Filter().OrderBy().MaxTop(2).Count();
                //    endpoints.MapODataRoute("odata", "odata", edmModel);
                //}
                endpoints.MapControllers();
                #region healthcheck
                //endpoints.MapHealthChecks("/hc", new HealthCheckOptions()
                //{
                //    Predicate = _ => true,
                //    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                //});
                //endpoints.MapHealthChecksUI();
                #endregion
                endpoints.UseAMS();
                endpoints.UseBlocklyAutomation();
                endpoints.MapGraph("/graph");
            });
            #region blockly optional
            //TODO : graphql
            //if (edmModel != null)
            //{
            //    app.UseOdataToEntityMiddleware<OePageMiddleware>("/odataDB", edmModel);
            //    //app.UseBlocklyOData("/odataDB","/odataDB");
            //}
            //app.UseBlocklyGraphQL("localGraphql", "/graphql");
            #endregion
            #region blockly needed
            //app.UseBlockly();
            #endregion
            using var scope = app.ApplicationServices.CreateScope();
            using var context = scope.ServiceProvider.GetService<testsContext>();
            context.Database.EnsureCreated();

        }
        private IEdmModel? ModelDB()
        {
            try
            {
                #region odata
                var optionsBuilder = new DbContextOptionsBuilder<DynamicDbContext>();
                IEdmModel edmModel;
                //optionsBuilder = optionsBuilder.UseSqlServer("Server=.;Initial Catalog=test;Trusted_Connection=No;UID=sa;PWD=Your_password123;Connect Timeout=5");
                //using (var providerSchema = new SqlServerSchema(optionsBuilder.Options))

                var con = Environment.GetEnvironmentVariable("MySql");
                optionsBuilder = optionsBuilder.UseMySQL(con);
                using (var providerSchema = new MySqlSchema(optionsBuilder.Options))
                //var con = Environment.GetEnvironmentVariable("Postgres");
                //optionsBuilder = optionsBuilder.UseNpgsql(con);
                //using (var providerSchema = new PostgreSqlSchema(optionsBuilder.Options))
                {
                    //TODO : graphql

                    // edmModel = DynamicMiddlewareHelper.CreateEdmModel(providerSchema, informationSchemaMapping: null);

                }
                //return edmModel;
                return null;
                #endregion 

            }
            catch (Exception)
            {
                //Console.WriteLine($" exception {ex.Message}");
                return null;
            }
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
        private readonly string CustomBlocksForUI = @"
<category name='UserDefinedBlocks'>
<category name='Database'>

 <block type='procedures_defreturn' x='97' y='25'>
    <mutation>
      <arg name='NameDepartment' varid='iyUw;Eri3EKdpA#7(]cT'></arg>
    </mutation>
    <field name='NAME'>FindEmployees</field>
    <comment pinned='true' h='80' w='160'>Find all employees from department</comment>
    <statement name='STACK'>
      <block type='variables_set'>
        <field name='VAR' id='hO`?kR*XbVn|uJq:?jJ_'>N</field>
        <value name='VALUE'>
          <block type='api_VariousTests_GetDepartment__name__GET'>
            <value name='val_name'>
              <shadow type='text'>
                <field name='TEXT'>IT</field>
              </shadow>
              <block type='variables_get'>
                <field name='VAR' id='iyUw;Eri3EKdpA#7(]cT'>NameDepartment</field>
              </block>
            </value>
          </block>
        </value>
        <next>
          <block type='variables_set'>
            <field name='VAR' id='hO`?kR*XbVn|uJq:?jJ_'>N</field>
            <value name='VALUE'>
              <block type='converttojson'>
                <value name='ValueToConvert'>
                  <block type='variables_get'>
                    <field name='VAR' id='hO`?kR*XbVn|uJq:?jJ_'>N</field>
                  </block>
                </value>
              </block>
            </value>
            <next>
              <block type='variables_set'>
                <field name='VAR' id='hO`?kR*XbVn|uJq:?jJ_'>N</field>
                <value name='VALUE'>
                  <block type='getproperty'>
                    <field name='objectName'>object</field>
                    <field name='prop'>property</field>
                    <value name='ObjectToChange'>
                      <block type='variables_get'>
                        <field name='VAR' id='hO`?kR*XbVn|uJq:?jJ_'>N</field>
                      </block>
                    </value>
                    <value name='PropertyName'>
                      <block type='text'>
                        <field name='TEXT'>employee</field>
                      </block>
                    </value>
                  </block>
                </value>
              </block>
            </next>
          </block>
        </next>
      </block>
    </statement>
    <value name='RETURN'>
      <block type='converttostring'>
        <value name='ValueToConvert'>
          <block type='variables_get'>
            <field name='VAR' id='hO`?kR*XbVn|uJq:?jJ_'>N</field>
          </block>
        </value>
      </block>
    </value>
  </block>
  <block type='text_print' x='105' y='293'>
    <value name='TEXT'>
      <shadow type='text'>
        <field name='TEXT'>abc</field>
      </shadow>
      <block type='procedures_callreturn'>
        <mutation name='FindEmployees'>
          <arg name='NameDepartment'></arg>
        </mutation>
        <value name='ARG0'>
          <block type='text'>
            <field name='TEXT'>IT</field>
          </block>
        </value>
      </block>
    </value>
  </block>
</category>
</category>
";
    }
}