using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace NetCore2Blockly
{
    /// <summary>
    /// host to enumerate
    /// </summary>
    /// <seealso cref="Microsoft.Extensions.Hosting.IHostedService" />
    public class EnumerateWebAPIHostedService : IHostedService
    {
        private Timer _timer;
        /// <summary>
        /// The application
        /// </summary>
        public IApplicationBuilder app=null;
        private readonly IApiDescriptionGroupCollectionProvider api;
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumerateWebAPIHostedService"/> class.
        /// </summary>
        /// <param name="api">The API.</param>
        public EnumerateWebAPIHostedService(IApiDescriptionGroupCollectionProvider api)
        {
            this.api = api;
        }/// <summary>
        /// starts
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
            return Task.CompletedTask;
        }
        private bool ExistsApp()
        {
            return (app != null);

        }
        private void DoWork(object state)
        {
            if (!ExistsApp())
            {
                Console.WriteLine("WebAPI2CLI: waiting to have app");
                return;
            }
            //var serverAddresses = app.ServerFeatures.Get<IServerAddressesFeature>();
            //if (serverAddresses == null)
            //{
            //    Console.WriteLine("WebAPI2CLI: waiting to have server adresses");
            //    return;
            //}
            _timer.Dispose();
            var e = new EnumerateWebAPI(api);
            var list = e.FindWebAPI();
            BlocklyTypesDefinition = list.TypesToBeGenerated();
            var nr = BlocklyTypesDefinition.Length;
            BlocklyToolBoxValueDefinition = list.GenerateBlocksValueDefinition();
            BlocklyAPIFunctions = list.FunctionsToBeGenerated();
            BlocklyToolBoxFunctionDefinition = list.GenerateBlocksFunctionsDefinition();
            nr++;
        }
        /// <summary>
        /// The blockly tool box function definition
        /// </summary>
        public string BlocklyToolBoxFunctionDefinition;

        /// <summary>
        /// The blockly API functions
        /// </summary>
        public string BlocklyAPIFunctions;
        /// <summary>
        /// The blockly tool box definition
        /// </summary>
        public string BlocklyToolBoxValueDefinition;
        /// <summary>
        /// Blockly variables
        /// </summary>
        public string BlocklyTypesDefinition;
        /// <summary>
        /// Triggered when the application host is performing a graceful shutdown.
        /// </summary>
        /// <param name="cancellationToken">Indicates that the shutdown process should no longer be graceful.</param>
        public Task StopAsync(CancellationToken cancellationToken)
        {

            return Task.CompletedTask;
        }
    }
    /// <summary>
    /// enumerate and generate
    /// </summary>
    public class EnumerateWebAPI
    {
        //private readonly ICollection<string> addresses;
        private readonly IApiDescriptionGroupCollectionProvider api;
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumerateWebAPI"/> class.
        /// </summary>
        /// <param name="api">The API.</param>
        public EnumerateWebAPI( IApiDescriptionGroupCollectionProvider api)
        {
            //this.addresses = addresses;
            this.api = api;
            
        }
        /// <summary>
        /// Finds the web API.
        /// </summary>
        /// <returns></returns>
        public ListOfBlockly FindWebAPI()
        {
            var allCommands = new ListOfBlockly();

            //var allAdresses = addresses.ToArray();


            var groups = api.ApiDescriptionGroups;

            foreach (var g in groups.Items)
            {

                foreach (var api in g.Items)
                {

                    //foreach (var adress in allAdresses)
                    {
                        //var ad = new Uri(adress);
                        var v1 = new BlocklyGenerator();
                        v1.NameCommand = api.RelativePath;
                        v1.Verb = api.HttpMethod??"GET";
                        //v1.Host = ad.GetLeftPart(UriPartial.Scheme);
                        v1.RelativeRequestUrl = api.RelativePath;
                        
                        v1.Params = GetParameters(api.ParameterDescriptions.ToArray());
                        var c = api.ActionDescriptor as ControllerActionDescriptor;
                        

                        v1.ReturnType = c?.MethodInfo?.ReturnType;
                        var type = v1.ReturnType;
                        if (type != null && type.IsGenericType)
                        {
                            if (type.IsSubclassOf(typeof(Task))){
                                type = type.GetGenericArguments()[0];//TODO: get all
                                v1.ReturnType = type;
                            }
                        }
                        v1.ControllerName = c?.ControllerName;
                        allCommands.Add(v1);
                    }

                }
            }
            return allCommands;
        }
        Dictionary<string, (Type type, BindingSource bs)> GetParameters(ApiParameterDescription[] parameterDescriptions)
        {
            if (parameterDescriptions?.Length == 0)
                return null;

            var desc = new Dictionary<string, (Type type, BindingSource bs) >();
            var pdAll = parameterDescriptions
                .Where(it => it != null)
                .Select(it => it.ParameterDescriptor)
                .Where(it => it != null)
                .Distinct()
                .ToArray();
            var strType = typeof(string).FullName;
            var okBindingSource = new[]
            {
                BindingSource.Body,
                BindingSource.Form,
                BindingSource.Path,
                BindingSource.Query
            };

            foreach (var pd in pdAll)
            {
                if( okBindingSource.Contains(pd.BindingInfo?.BindingSource) )
                    desc.Add(pd.Name,  (pd.ParameterType, pd.BindingInfo.BindingSource));
            }
            return desc;
        }
        

    }
}
