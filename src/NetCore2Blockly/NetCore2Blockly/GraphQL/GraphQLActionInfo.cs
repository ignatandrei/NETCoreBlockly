using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NetCore2Blockly.Swagger;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using System.Text.Json;
using System.Text.Json.Serialization;

namespace NetCore2Blockly.GraphQL
{
    class GraphQLActionInfo : ActionInfo
    {
        private Field f;
        private TypeArgumentBase returnType;
        private AllTypes allTypesInGraph;


        public GraphQLActionInfo(Field f, AllTypes allTypesInGraph) 
        {
            this.f = f;
            this.allTypesInGraph = allTypesInGraph;
        }

        internal void Init()
        {
            ActionName = f.Name;
            var retName = f.Type?.OfType?.Name ?? f.Type.Name;
            returnType = allTypesInGraph.FindAfterId(retName);
            string ret = "";
            if(returnType != null)
            {
                ret = string.Join(" ",
                    returnType.GetProperties().Select(it => it.Name)
                    );
            }

            string argsInQuery = "";
            if (f.Args?.Count > 0)
            {
                foreach (var arg in f.Args)
                {
                    var type = arg.Type;
                    var typeInGraph = allTypesInGraph.FindAfterId(type.Name);
                    Params.Add(arg.Name, (typeInGraph, BindingSourceDefinition.Query));
                }
                argsInQuery = string.Join(",",
                    f.Args
                    .Select(it=>new { it.Name, isString=(it.Type.Name == "String") })
                    .Select(it=>it.Name +":"
                    + (it.isString ? "\"" : "")
                    + "{" +it.Name +"}"
                    + (it.isString ? "\"" : "")
                    )

                    );
                argsInQuery = $"({argsInQuery})";
            }

            RelativeRequestUrl = "/graphql?query={" + f.Name + argsInQuery+ "{"+ ret +"}}";
            this.
            Verb = "GET";
            ReturnType = BlocklyType.CreateValue(null);



        }
        private BindingSourceDefinition ConvertFromBindingSource(BindingSource bindingSource)
        {
            return bindingSource switch
            {
                var x when x == BindingSource.Query => BindingSourceDefinition.Query,
                var x when x == BindingSource.Header => BindingSourceDefinition.Header,
                var x when x == BindingSource.Path => BindingSourceDefinition.Path,
                _ => throw new ArgumentException($"not know {bindingSource.DisplayName}")
            };
        }

        Dictionary<string, (TypeArgumentBase type, BindingSourceDefinition bs)> GetParameters(object[] parameterDescriptions = null)
        {
            //just for the demo. the schema
            var schema = "{\"_queryType\":\"GetAllQuery\",\"_mutationType\":null,\"_subscriptionType\":null,\"_directives\":[\"@include\",\"@skip\",\"@deprecated\"],\"_typeMap\":{\"String\":\"String\",\"Boolean\":\"Boolean\",\"Float\":\"Float\",\"Int\":\"Int\",\"ID\":\"ID\",\"Date\":\"Date\",\"DateTime\":\"DateTime\",\"DateTimeOffset\":\"DateTimeOffset\",\"Seconds\":\"Seconds\",\"Milliseconds\":\"Milliseconds\",\"Decimal\":\"Decimal\",\"__Schema\":\"__Schema\",\"__Type\":\"__Type\",\"__TypeKind\":\"__TypeKind\",\"__Field\":\"__Field\",\"__InputValue\":\"__InputValue\",\"__EnumValue\":\"__EnumValue\",\"__Directive\":\"__Directive\",\"__DirectiveLocation\":\"__DirectiveLocation\",\"GetAllQuery\":\"GetAllQuery\",\"DepartmentOGT\":\"DepartmentOGT\"},\"_subTypeMap\":{},\"_implementationsMap\":{}}\r\n";

            var desc = new Dictionary<string, (TypeArgumentBase type, BindingSourceDefinition bs)>();

            if (parameterDescriptions?.Length == 0)
                return desc;

            var bindingSources = new[]
            {
                BindingSource.Query,
                BindingSource.Header,
                BindingSource.Path,
                null // for the items that have not binding source
            };

            // parse the above schema
            using (JsonDocument doc = JsonDocument.Parse(schema))
            {
                JsonElement root = doc.RootElement;
                JsonElement info = root;

                //Console.WriteLine(info.GetProperty("_typeMap").GetProperty("DepartmentOGT"));
                desc.Add("queyType", (null, BindingSourceDefinition.Query)); //not correct
            }
            return null;
        }

       
    
    }
}
