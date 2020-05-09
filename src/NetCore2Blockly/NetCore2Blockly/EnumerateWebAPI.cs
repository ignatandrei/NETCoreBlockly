
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NetCore2Blockly
{
    /// <summary>
    /// enumerate and generate
    /// </summary>
    public class EnumerateWebAPI
    {
       
        private readonly IApiDescriptionGroupCollectionProvider api;
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumerateWebAPI"/> class.
        /// </summary>
        /// <param name="api">The API.</param>
        public EnumerateWebAPI(IApiDescriptionGroupCollectionProvider api)
        {
            
            this.api = api;

        }

        /// <summary>
        /// Creates the action list to generate blocks
        /// </summary>
        /// <returns></returns>
        public List<ActionInfo> CreateActionList()
        {
            var allActions = new List<ActionInfo>();
            var groups = api.ApiDescriptionGroups;

            foreach (var g in groups.Items)
            {

                foreach (var api in g.Items)
                {
                    var controllerInformation = new ActionInfoFromNetAPI(api);

                    allActions.Add(controllerInformation);

                }
            }
            return allActions;
        }

       
    }
}