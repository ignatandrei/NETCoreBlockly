using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
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

        #region swaggers
        private Dictionary<string, string> swaggers;
        public string[] KeySwaggers()
        {
            return swaggers.Select(it => it.Key).ToArray();
        }
        public string SwaggerBlocklyTypesDefinition(string key)
        {
            return "";
        }
        public string SwaggersDictionaryJS
        {
            get
            {
                var s = string.Join(Environment.NewLine,
                    swaggers.Select(it => $@"dictSwagger.push({{key:'{it.Key}',value:'{it.Value}'}});"));

                return $@"var dictSwagger=[]; {s}";
            }
        }
        public void AddSwagger(string name, string endpoint)
        {
            swaggers.Add(name, endpoint);
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
            this.swaggers = new Dictionary<string, string>();
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
