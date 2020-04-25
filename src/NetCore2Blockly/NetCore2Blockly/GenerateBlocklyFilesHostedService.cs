using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NetCore2Blockly
{
    /// <summary>
    /// host to enumerate
    /// </summary>
    /// <seealso cref="Microsoft.Extensions.Hosting.IHostedService" />
    public class GenerateBlocklyFilesHostedService : IHostedService
    {

        public string BlocklyToolBoxFunctionDefinition;

        public string BlocklyAPIFunctions;
       
        public string BlocklyToolBoxValueDefinition;
       
        public string BlocklyTypesDefinition;

        private Timer _timer;
        
        /// <summary>
        /// The application
        /// </summary>
        public IApplicationBuilder app=null;


        private readonly IApiDescriptionGroupCollectionProvider api;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenerateBlocklyFilesHostedService"/> class.
        /// </summary>
        /// <param name="api">The API.</param>
        public GenerateBlocklyFilesHostedService(IApiDescriptionGroupCollectionProvider api)
        {
            this.api = api;
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
           
            _timer.Dispose();
            var e = new EnumerateWebAPI(api);
            var actionList = e.CreateActionList();
            var blocklyFileGenerator = new BlocklyFileGenerator(actionList);
            BlocklyTypesDefinition = blocklyFileGenerator.GenerateNewBlocklyTypesDefinition();
            BlocklyAPIFunctions = blocklyFileGenerator.GenerateBlocklyAPIFunctions();
            BlocklyToolBoxValueDefinition = blocklyFileGenerator.GenerateBlocklyToolBoxValueDefinitionFile();
            BlocklyToolBoxFunctionDefinition = blocklyFileGenerator.GenerateBlocklyToolBoxFunctionDefinitionFile();
           
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
