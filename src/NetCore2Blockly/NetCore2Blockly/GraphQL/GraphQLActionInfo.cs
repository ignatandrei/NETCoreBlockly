using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NetCore2Blockly.GraphQL
{
    class GraphQLActionInfo : ActionInfo
    {
        static readonly HttpClient client = new HttpClient();

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

                Console.WriteLine(info.GetProperty("_typeMap").GetProperty("DepartmentOGT"));
                desc.Add("queyType", (null, BindingSourceDefinition.Query)); //not correct
            }
            return null;
        }

        private async static Task<JsonElement> GetIntrospection()
        {

            var typesKindName = @"{
                                      __schema {
                                        types {
                                          name kind
                                        }
                                      }
                                    }";
            var endpoint = "https://localhost:5001/graphql?query=";
            var response = await client.GetAsync($"{endpoint + typesKindName}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            using (JsonDocument doc = JsonDocument.Parse(responseBody))
            {
                JsonElement root = doc.RootElement;
                JsonElement info = root;
                var types = info.GetProperty("data").GetProperty("__schema").GetProperty("types");
                var x = types.EnumerateArray().ToArray();//because our collection is an array
                var ourTypes = x.Where(condition => condition.GetProperty("kind").GetString().Equals("OBJECT"))
                                .Where(condition => !condition.GetProperty("name").GetString().StartsWith("__"));

                ourTypes.ToList().ForEach(res => Console.WriteLine(res));

            }
            return new JsonElement();
        }
    
    }
}
