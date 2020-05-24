using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Readers;
using NetCore2Blockly.OData;
using NetCore2Blockly.Swagger;
using SharpYaml.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace NetCore2Blockly
{
    /// <summary>
    /// host to enumerate
    /// </summary>
    /// <seealso cref="Microsoft.Extensions.Hosting.IHostedService" />
    public class GenerateBlocklyFilesHostedService : IHostedService
    {

        internal IApplicationBuilder app;

        #region swaggers
        private Dictionary<string, BlocklyFileGenerator> swaggers;
        private string _SwaggerBlocklyToolBoxFunctionDefinition;
        private string _SwaggerBlocklyAPIFunctions;
        private string _SwaggerBlocklyToolBoxValueDefinition;
        private string _SwaggerBlocklyTypesDefinition;
        private Dictionary<string, BlocklyFileGenerator> oDatas;
        private string _ODataBlocklyToolBoxFunctionDefinition;
        private string _ODataBlocklyAPIFunctions;
        private string _ODataBlocklyToolBoxValueDefinition;
        private string _ODataBlocklyTypesDefinition;
        internal async Task AddSwagger(string key, string endpoint)
        {
            try
            {
                var data = await GenerateFromSwaggerEndPoint(endpoint);

                swaggers.Add(key, new BlocklyFileGenerator(data));
            }
            catch(Exception ex)
            {
                Console.WriteLine($"adding swagger {endpoint} throws error {ex?.Message}");
                //swallowing error - should run even if the endpoint is not available
                
            }
        }
        internal string[] KeySwaggers()
        {
            return swaggers.Select(it => it.Key).ToArray();
        }
        internal string SwaggerBlocklyToolBoxFunctionDefinition()
        {
            if (string.IsNullOrWhiteSpace(_SwaggerBlocklyToolBoxFunctionDefinition))
            {
                lock(this)
                    _SwaggerBlocklyToolBoxFunctionDefinition = string.Join(Environment.NewLine, swaggers.Select(it => it.Value.GenerateBlocklyToolBoxFunctionDefinitionFile(it.Key))); ;
            }
            return _SwaggerBlocklyToolBoxFunctionDefinition;
        }
        internal string SwaggerBlocklyAPIFunctions()
        {
            if (string.IsNullOrWhiteSpace(_SwaggerBlocklyAPIFunctions))
            {
                lock(this)
                _SwaggerBlocklyAPIFunctions =string.Join(Environment.NewLine, swaggers.Select(it => it.Value.GenerateBlocklyAPIFunctions(it.Key)));
            }
            return _SwaggerBlocklyAPIFunctions;
        }
        internal string SwaggerBlocklyToolBoxValueDefinition()
        {
            if (string.IsNullOrWhiteSpace(_SwaggerBlocklyToolBoxValueDefinition))
            {
                lock(this)
                _SwaggerBlocklyToolBoxValueDefinition = string.Join(Environment.NewLine, swaggers.Select(it => it.Value.GenerateBlocklyToolBoxValueDefinitionFile(it.Key)));
            }
            return _SwaggerBlocklyToolBoxValueDefinition ;
        }

        internal string SwaggerBlocklyTypesDefinition()
        {
            if (string.IsNullOrWhiteSpace(_SwaggerBlocklyTypesDefinition))
            {
                lock(this)
                    _SwaggerBlocklyTypesDefinition =string.Join(Environment.NewLine, swaggers.Select(it => it.Value.GenerateNewBlocklyTypesDefinition()));
            }
            return _SwaggerBlocklyTypesDefinition;
        }
        internal string SwaggersDictionaryJS
        {
            get
            {
                var s = string.Join(Environment.NewLine,
                    swaggers.Select(it => $@"dictSwagger.push({{key:'{it.Key}',value:'{it.Value}'}});"));

                return $@"var dictSwagger=[]; {s}";
            }
        }
        async Task<Stream> GetFromURL(string endpoint)
        {
            
            var uri = new Uri(endpoint);
            var site = uri.Scheme + "://" + uri.Authority;
            if (uri.IsFile)
            {
                return new FileStream(uri.LocalPath, FileMode.Open, FileAccess.Read);
            }
            else
            {
                var httpClient = new HttpClient
                {
                    BaseAddress = new Uri(site)
                };
                return await httpClient.GetStreamAsync(uri.PathAndQuery);
            }

            

        }
        async Task<List<ActionInfo>> GenerateFromSwaggerEndPoint(string endpoint)
        {
            var uri = new Uri(endpoint);
            var site = uri.Scheme + "://" + uri.Authority;
            using var stream = await GetFromURL(endpoint);
            var openApiDocument = new OpenApiStreamReader().Read(stream, out var diagnostic);
            var servers = openApiDocument.Servers;
            
            if (servers?.Count > 0)
            {
                foreach (var server in servers)
                {
                    if (server.Url.StartsWith(site))
                    {
                        site = server.Url;
                        break;
                    }
                    if (server.Url.StartsWith("https://"))//prefer https
                    {
                        site = server.Url;
                        break;
                    }
                    site = server.Url;


                }
            }
            var comp = openApiDocument.Components;

            var types = new AllTypes();
            foreach (var schema in comp.Schemas)
            {

                var t = new TypeToGenerateSwagger(schema);
                t.Site = site;
                types.Add(t);
            }
            //do it again to find property types
            var existingTypes = new AllTypes(types);
            

           foreach(var t in existingTypes)
            {
                foreach(var prop in t.GetProperties())
                {
                    if (prop.PropertyType != null)
                        continue;
                    if (!(prop is PropertyBaseSwagger pbs))
                        continue;
                    var val = pbs.propertyTypeSchema;
                    var reference = val.Reference;
                    if (reference != null)
                    {
                        prop.PropertyType = types.FindAfterId(reference.ReferenceV2 + "_" + reference.ReferenceV3);
                        continue;
                    }
                    if (!string.IsNullOrWhiteSpace(val.Type))
                    {
                        if(val.Type == "object" && val.AdditionalPropertiesAllowed)
                        {
                            val.Type=val.AdditionalProperties.Type;
                        }
                        prop.PropertyType = types.FindAfterId(val.Type);
                        continue;
                    }
                    //should almost never happen , but , if not discovered...
                    prop.PropertyType = types.FindAfterId(null);
                    //Debug.Assert(prop.PropertyType != null);
                    

                }
            }
            var functions = openApiDocument.Paths;
            var actions = new List<ActionInfo>();
            foreach (var f in functions)
            {
                var val = f.Value;
                foreach (var op in val.Operations)
                {
                    var val1 = op.Value;
                    var act = new ActionInfoSwagger();
                    actions.Add(act);
                    act.Site = site;
                    act.Verb = op.Key.GetDisplayName();
                    act.RelativeRequestUrl = f.Key;
                    act.ActionName =TypeToGenerateSwagger.Prefix(site) + "_"+ act.RelativeRequestUrl;
                    var R200 = val1.Responses.FirstOrDefault(it => it.Key == "200");
                    var type = R200.Value?.Content?.FirstOrDefault().Value?.Schema?.Type;
                    if (!string.IsNullOrEmpty(type) && type !="object")
                        act.ReturnType = types.FindAfterId(type);

                    if(act.ReturnType == null)
                    {
                        var refer= R200.Value?.Content?.FirstOrDefault().Value?.Schema?.Reference;
                        if(refer != null)
                        act.ReturnType = types.FindAfterId(refer.ReferenceV2 + "_" + refer.ReferenceV3);

                    }
                    if(act.ReturnType == null)
                    {
                        act.ReturnType = types.FindAfterId(null);//null type
                    }
                    
                    if (val1.Tags?.Count > 0)
                    {
                        act.ControllerName = val1.Tags.First().Name;
                    }
                    else
                    {
                        act.ControllerName = ActionInfoSwagger.GenerateControllerName(act.RelativeRequestUrl);
                    }
                    foreach (var par in val1.Parameters)
                    {
                        var name = par.Name;
                        var s = par.In;//path , query
                        var schema = par.Schema;
                        TypeArgumentBase myType = null;
                        if (schema.Type != null)
                        {
                            myType = types.FindAfterId(schema.Type);
                        }
                        if (schema.Reference != null)
                        {
                            var id = schema.Reference.ReferenceV2 + "_" + schema.Reference.ReferenceV3;
                            myType = types.FindAfterId(id);

                        }
                        var bs = BindingSourceDefinition.None;
                        switch (par.In.GetDisplayName().ToLower())
                        {
                            case "path":
                                bs = BindingSourceDefinition.Path;
                                break;
                            case "query":
                                bs = BindingSourceDefinition.Query;
                                break;
                            default:
                                //https://swagger.io/docs/specification/describing-parameters/
                                break;

                        }
                        if (act.Params.ContainsKey(name))
                        {
                            Console.WriteLine($"DUPLICATE PARAM {name} FOR {act.RelativeRequestUrl}");
                            
                        }
                        else
                        {
                            act.Params.Add(name, (myType, bs));
                        }
                    }
                    var postData = val1.RequestBody?.Content;
                    if (postData != null )
                    {
                        var bs = BindingSourceDefinition.Body;
                        var data = postData.Values.FirstOrDefault();
                        var s = data.Schema;
                        var name = s.Type;
                        if (name != null)
                        {
                            TypeArgumentBase myType = null;
                            if (s.Reference != null)
                            {
                                var id = s.Reference.ReferenceV2 + "_" + s.Reference.ReferenceV3;
                                myType = types.FindAfterId(id);
                                name = myType.Name;
                            }
                            else
                            {
                                myType = types.FindAfterId(s.Type);
                                name = myType.Name;
                            }
                            act.Params.Add(name, (myType, bs));
                        }
                    }
                    //Console.WriteLine(op.Key);
                }
            }
            var typesFromActionToTransformBlocks= actions

                .SelectMany(it => it.Params)
                .Select(param => param.Value.type)
                .Distinct()
                .Where(type => type.TranslateToBlocklyType() == null)

                .ToArray();

            var typesToTransfromBlocks = types
                .Where(t=>t != null)
                .Where(type => type.TranslateToBlocklyType() == null).ToArray();

            var remaining = typesToTransfromBlocks.Except(typesFromActionToTransformBlocks).ToArray();
            return actions;

        }


        #endregion


        #region odata

        internal string ODataBlocklyToolBoxFunctionDefinition()
        {
            if (string.IsNullOrWhiteSpace(_ODataBlocklyToolBoxFunctionDefinition))
            {
                _ODataBlocklyToolBoxFunctionDefinition= string.Join(Environment.NewLine, oDatas.Select(it => it.Value.GenerateBlocklyToolBoxFunctionDefinitionFile(it.Key))); ;
            }
            return _ODataBlocklyToolBoxFunctionDefinition;
        }
        internal string ODataBlocklyAPIFunctions()
        {
            if (string.IsNullOrWhiteSpace(_ODataBlocklyAPIFunctions))
            {
                lock(this)
                _ODataBlocklyAPIFunctions = string.Join(Environment.NewLine, oDatas.Select(it => it.Value.GenerateBlocklyAPIFunctions(it.Key)));
            }
            return _ODataBlocklyAPIFunctions;
        }
        internal string ODataBlocklyToolBoxValueDefinition()
        {
            if (string.IsNullOrWhiteSpace(_ODataBlocklyToolBoxValueDefinition))
            {
                lock (this)
                    _ODataBlocklyToolBoxValueDefinition = string.Join(Environment.NewLine, oDatas.Select(it => it.Value.GenerateBlocklyToolBoxValueDefinitionFile(it.Key)));
            }
            return _ODataBlocklyToolBoxValueDefinition;
        }
        internal string ODataBlocklyTypesDefinition()
        {
            if (string.IsNullOrWhiteSpace(_ODataBlocklyTypesDefinition))
            {
                lock(this)
                    _ODataBlocklyTypesDefinition = string.Join(Environment.NewLine, oDatas.Select(it => it.Value.GenerateNewBlocklyTypesDefinition()));
            }
            return _ODataBlocklyTypesDefinition;
        }
        internal string ODataDictionaryJS
        {
            get
            {
                var s = string.Join(Environment.NewLine,
                    oDatas.Select(it => $@"dictOData.push({{key:'{it.Key}',value:'{it.Value}'}});"));

                return $@"var dictOData=[]; {s}";
            }
        }
        internal async Task<ListTypeToGenerateOData> AddValues(string OdataContextUrl)
        {
            var uri = new Uri(OdataContextUrl);
            var site = uri.Scheme + "://" + uri.Authority;
            var newUri = new UriBuilder(site);
            var httpClient = new HttpClient
            {
                BaseAddress = newUri.Uri
            };
            var str = await httpClient.GetStringAsync(uri.PathAndQuery);
            var data= XDocument.Parse(str);
            
            var types = new ListTypeToGenerateOData();

            var entities = data.Root.XPathSelectElements("//*[local-name()='EntitySet']");

            foreach (var et in entities){
                var newType = TypeToGenerateOData.CreateFromEntitySet(et, data);
                types.Add(newType);
            }

            entities = data.Root.XPathSelectElements("//*[local-name()='EntityType']");

            foreach (var et in entities)
            {
                
                var name = et.Attribute("Name").Value;
                var schema = et.Parent?.Attribute("Namespace")?.Value;
                if (!string.IsNullOrWhiteSpace(schema))
                {
                    name = $"{schema}.{name}";
                }
                if (types.Exists(it => it.id == name))
                    continue;

                var newType = TypeToGenerateOData.CreateFromEntityType(et, data);
                types.Add(newType);
            }

            entities = data.Root.XPathSelectElements("//*[local-name()='ComplexType']");
            foreach (var et in entities)
            {
                var newType = TypeToGenerateOData.CreateFromComplexType(et,data);
                types.Add(newType);
            }
            entities = data.Root.XPathSelectElements("//*[local-name()='EnumType']");
            foreach (var et in entities)
            {
                var newType = TypeToGenerateOData.CreateFromEnumType(et, data);
                types.Add(newType);
            }

            var existingTypes = types.ToArray();


            foreach (var t in existingTypes)
            {
                foreach (var prop in t.GetProperties())
                {
                    if (prop.PropertyType != null)
                        continue;
                    if (!(prop is PropertyBaseOData pbs))
                        continue;
                    var val = pbs.typeOdata;
                    prop.PropertyType = types.FindAfterId(val);
                }
            }
            return types;

        }
        List<string> odataLater = new List<string>();
        internal async Task AddOdata(string key, string endpoint)
        {
            try
            {
                if (endpoint.StartsWith("/"))
                {
                    odataLater.Add(endpoint);
                    return;
                }
                var data = await GenerateFromODataEndPoint(endpoint);
                oDatas.Add(key, new BlocklyFileGenerator(data));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"adding swagger {endpoint} throws error {ex?.Message}");
                //swallowing error - should run even if the endpoint is not available

            }
        }
        internal async Task<List<ActionInfo>> GenerateFromODataEndPoint( string endpoint)
        {
            var uri = new Uri(endpoint);
            var site = uri.Scheme + "://" + uri.Authority;

            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(site)
            };
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            var str = await httpClient.GetStringAsync(uri.PathAndQuery);
            var js = JsonDocument.Parse(str);
            var root = js.RootElement;
            JsonElement value;
            var versionOData = 4;   
            if (!root.TryGetProperty("@odata.context", out value))
            {
                versionOData = 3;
                if (!root.TryGetProperty("odata.metadata", out value))
                    throw new ArgumentNullException($"cannot find @odata.context or odata.metadata for {endpoint}")
                            ;
            }
            var entitiesLocation =value.GetString();
            var newUri = new UriBuilder(entitiesLocation);
            if (newUri.Port == 0)
            {
                newUri.Port = 80;
            }
            entitiesLocation = newUri.Uri.ToString();
            var types = await AddValues(entitiesLocation);

            var urls = root.GetProperty("value");
            var actions = new List<ActionInfo>();
            foreach (var entity in urls.EnumerateArray())
            {

                if (entity.TryGetProperty("kind", out var kind))//v4
                {
                    if (kind.GetString() != "EntitySet")
                        continue;

                };

                var action = entity.GetProperty("url").GetString();
                var nameAction = entity.GetProperty("name").GetString();

                var newAction = new ActionInfoOdata();
                newAction.ActionName = $"GetAll{nameAction}";
                newAction.ControllerName = action;
                newAction.Site = entitiesLocation.Replace("$metadata", "");
                newAction.Verb = "GET";
                newAction.RelativeRequestUrl = action;
                newAction.ReturnType = types.FindAfterId("array");
                actions.Add(newAction);


                newAction = new ActionInfoOdata();
                newAction.ActionName = $"Get{nameAction}_Odata";
                newAction.ControllerName = action;
                newAction.Site = entitiesLocation.Replace("$metadata", "");
                newAction.Verb = "GET";
                newAction.RelativeRequestUrl = action;
                var typeBool = types.FindAfterId("Edm.Boolean");
                var typeInt = types.FindAfterId("Edm.Int32");
                var typeString = types.FindAfterId("Edm.String");
                switch (versionOData) {
                    case 4:
                        newAction.Params.Add("$count", (typeBool, BindingSourceDefinition.Query));
                        break;
                    case 3:
                        newAction.Params.Add("$inlinecount", (typeString, BindingSourceDefinition.Query));
                        break;
                    default:
                        throw new ArgumentException($"not know odata version {versionOData}");
                }
                newAction.Params.Add("$top", (typeInt, BindingSourceDefinition.Query));
                newAction.Params.Add("$skip", (typeInt, BindingSourceDefinition.Query));
                newAction.Params.Add("$select", (typeString, BindingSourceDefinition.Query));

                newAction.ReturnType = types.FindAfterId("array");
                actions.Add(newAction);

                newAction = new ActionInfoOdata();
                newAction.ActionName = $"GetOne{nameAction}";
                newAction.ControllerName = action;
                newAction.Site = entitiesLocation.Replace("$metadata", "");
                newAction.Verb = "GET";

                var type = types.FirstOrDefault(it => it.Name == nameAction || it.id == nameAction);
                var odatType = type as TypeToGenerateOData;


                var paramKeys = odatType
                   .Keys
                   .Select(it => odatType.GetProperties().First(pr => pr.Name == it))
                   .Select(pr => new { orig = pr, Name = pr.Name, IsString = pr.PropertyType.TranslateToBlocklyBlocksType() == "text" })

                   .ToArray();



                var paramKeysStr = string.Join(",", paramKeys.Select(pr => (pr.IsString ? @"\\'" : "") + "{" + pr.Name + "}" + (pr.IsString ? @"\\'" : "")));
                newAction.RelativeRequestUrl = $"{action}({paramKeysStr})";

                foreach (var item in paramKeys)
                {
                    //item.orig.PropertyType 
                    newAction.Params.Add(item.Name, (item.orig.PropertyType, BindingSourceDefinition.Path));
                }
                newAction.ReturnType = odatType;
                actions.Add(newAction);

                newAction = new ActionInfoOdata();
                newAction.ActionName = $"Create {nameAction}";
                newAction.ControllerName = action;
                newAction.Site = entitiesLocation.Replace("$metadata", "");
                newAction.Verb = "POST";
                newAction.RelativeRequestUrl = $"{action}"; 
                newAction.ReturnType = odatType;
                newAction.Params.Add(odatType.Name, (odatType, BindingSourceDefinition.Body));
                actions.Add(newAction);

                newAction = new ActionInfoOdata();
                newAction.ActionName = $"Modify {nameAction}";
                newAction.ControllerName = action;
                newAction.Site = entitiesLocation.Replace("$metadata", "");
                newAction.Verb = "PUT";
                newAction.RelativeRequestUrl = $"{action}({paramKeysStr})"; 
                foreach (var item in paramKeys)
                {
                    //item.orig.PropertyType 
                    newAction.Params.Add(item.Name, (item.orig.PropertyType, BindingSourceDefinition.Path));
                }
                newAction.ReturnType = odatType;
                newAction.Params.Add(odatType.Name, (odatType, BindingSourceDefinition.Body));
                actions.Add(newAction);

                newAction = new ActionInfoOdata();
                newAction.ActionName = $"Delete {nameAction}";
                newAction.ControllerName = action;
                newAction.Site = entitiesLocation.Replace("$metadata", "");
                newAction.Verb = "DELETE";
                newAction.RelativeRequestUrl = $"{action}({paramKeysStr})";
                foreach (var item in paramKeys)
                {
                    //item.orig.PropertyType 
                    newAction.Params.Add(item.Name, (item.orig.PropertyType, BindingSourceDefinition.Path));
                }
                newAction.ReturnType = odatType;
                actions.Add(newAction);



            }


            return actions;
        }
        #endregion
            /// <summary>
            /// The blockly tool box function definition
            /// </summary>
        public string BlocklyToolBoxFunctionDefinition;

        /// <summary>
        /// The blockly API functions
        /// </summary>
        public string BlocklyAPIFunctions;

        /// <summary>
        /// The blockly tool box value definition
        /// </summary>
        public string BlocklyToolBoxValueDefinition;

        /// <summary>
        /// The blockly types definition
        /// </summary>
        public string BlocklyTypesDefinition;

        private Timer _timer;
        


        private readonly IApiDescriptionGroupCollectionProvider api;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenerateBlocklyFilesHostedService"/> class.
        /// </summary>
        /// <param name="api">The API.</param>
        public GenerateBlocklyFilesHostedService(IApiDescriptionGroupCollectionProvider api)
        {
            this.api = api;
            this.swaggers = new  Dictionary<string, BlocklyFileGenerator>();
            this.oDatas = new Dictionary<string, BlocklyFileGenerator>();
        }
        /// <summary>
        /// starts
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
            return Task.CompletedTask;
        }
        private void DoWork(object state)
        {
           
            var e = new EnumerateWebAPI(api);
            var actionList = e.CreateActionList();
            var blocklyFileGenerator = new BlocklyFileGenerator(actionList);
            BlocklyTypesDefinition = blocklyFileGenerator.GenerateNewBlocklyTypesDefinition();
            BlocklyAPIFunctions = blocklyFileGenerator.GenerateBlocklyAPIFunctions();
            BlocklyToolBoxValueDefinition = blocklyFileGenerator.GenerateBlocklyToolBoxValueDefinitionFile();
            BlocklyToolBoxFunctionDefinition = blocklyFileGenerator.GenerateBlocklyToolBoxFunctionDefinitionFile();
            if (app == null)
                return;
            var serverAddresses = app.ServerFeatures.Get<IServerAddressesFeature>();
            if ((serverAddresses?.Addresses?.Count() ?? 0) == 0)
                return;

            if (odataLater.Count > 0)
            {
                
                _timer.Dispose();
                var Host = "";
                foreach(var item in serverAddresses.Addresses)
                {
                    if (item.StartsWith("https"))
                    {
                        Host = item;
                    }
                    if (Host.Length == 0)
                        Host = item;

                }
                Host = Host.Replace("0.0.0.0", "localhost");
                Host = Host.Replace("[::]", "localhost");
                foreach(var item in odataLater)
                {
                    var b = new UriBuilder(Host);
                    b.Path = item;
                    var x= AddOdata(item.Replace("/", ""), b.Uri.ToString());
                    x.GetAwaiter().GetResult();
                }
                odataLater.Clear();
            }
            _timer.Dispose();
        }
        
        /// <summary>
        /// Triggered when the application host is performing a graceful shutdown.
        /// </summary>
        /// <param name="cancellationToken">Indicates that the shutdown process should no longer be graceful.</param>
        public Task StopAsync(CancellationToken cancellationToken)
        {

            return Task.CompletedTask;
        }
    }
   
}
