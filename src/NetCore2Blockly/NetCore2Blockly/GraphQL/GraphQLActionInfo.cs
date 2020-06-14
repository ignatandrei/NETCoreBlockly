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
        private const string EndPoint = "https://localhost:5001/graphql?query=";

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
            var schema = "{\r\n  __schema {\r\n    queryType {\r\n      name\r\n    }\r\n    mutationType {\r\n      name\r\n    }\r\n    subscriptionType {\r\n      name\r\n    }\r\n    types {\r\n      ...FullType\r\n    }\r\n    directives {\r\n      name\r\n      description\r\n      locations\r\n      args {\r\n        ...InputValue\r\n      }\r\n    }\r\n  }\r\n}\r\n\r\nfragment FullType on __Type {\r\n  kind\r\n  name\r\n  description\r\n  fields(includeDeprecated: true) {\r\n    name\r\n    description\r\n    args {\r\n      ...InputValue\r\n    }\r\n    type {\r\n      ...TypeRef\r\n    }\r\n    isDeprecated\r\n    deprecationReason\r\n  }\r\n  inputFields {\r\n    ...InputValue\r\n  }\r\n  interfaces {\r\n    ...TypeRef\r\n  }\r\n  enumValues(includeDeprecated: true) {\r\n    name\r\n    description\r\n    isDeprecated\r\n    deprecationReason\r\n  }\r\n  possibleTypes {\r\n    ...TypeRef\r\n  }\r\n}\r\n\r\nfragment InputValue on __InputValue {\r\n  name\r\n  description\r\n  type {\r\n    ...TypeRef\r\n  }\r\n  defaultValue\r\n}\r\n\r\nfragment TypeRef on __Type {\r\n  kind\r\n  name\r\n  ofType {\r\n    kind\r\n    name\r\n    ofType {\r\n      kind\r\n      name\r\n      ofType {\r\n        kind\r\n        name\r\n        ofType {\r\n          kind\r\n          name\r\n          ofType {\r\n            kind\r\n            name\r\n            ofType {\r\n              kind\r\n              name\r\n              ofType {\r\n                kind\r\n                name\r\n              }\r\n            }\r\n          }\r\n        }\r\n      }\r\n    }\r\n  }\r\n}";
            var fullResponse = await client.GetAsync($"{EndPoint + schema}");
            fullResponse.EnsureSuccessStatusCode();
            string fullResponseBody = await fullResponse.Content.ReadAsStringAsync();

            using (JsonDocument doc = JsonDocument.Parse(fullResponseBody))
            {
                JsonElement info = doc.RootElement;
                var allTypes = info.GetProperty("data").GetProperty("__schema").GetProperty("types").EnumerateArray()
                    .ToArray();
                var queryTypeName = info.GetProperty("data").GetProperty("__schema")
                    .GetProperty("queryType").GetProperty("name");

                var schemaObjects = allTypes
                    .Where(condition => condition.GetProperty("kind").GetString().Equals("OBJECT"))
                    .Where(condition => condition.GetProperty("name").GetString().Equals(queryTypeName.GetString()));
                var schemaObjectsToString = string.Join("", schemaObjects);

                Console.WriteLine(schemaObjectsToString);
                var obj = Root.FromJson(schemaObjectsToString);//works
                // Console.WriteLine(obj.Name);
            }
            return new JsonElement();
        }
    
    }
}
