using NetCore2Blockly.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

using System.Text.Json;
using System.Threading.Tasks;

namespace NetCore2Blockly.GraphQL
{
    class GraphqlGenerator
    {
        public string Endpoint { get; }
        static readonly HttpClient client = new HttpClient();
        public GraphqlGenerator(string endpoint)
        {
            Endpoint = endpoint;
        }
        public async Task<List<ActionInfo>> GetIntrospection()
        {
            var arrayOfActions = new List<ActionInfo>();

            var schema = "{\r\n  __schema {\r\n    queryType {\r\n      name\r\n    }\r\n    mutationType {\r\n      name\r\n    }\r\n    subscriptionType {\r\n      name\r\n    }\r\n    types {\r\n      ...FullType\r\n    }\r\n    directives {\r\n      name\r\n      description\r\n      locations\r\n      args {\r\n        ...InputValue\r\n      }\r\n    }\r\n  }\r\n}\r\n\r\nfragment FullType on __Type {\r\n  kind\r\n  name\r\n  description\r\n  fields(includeDeprecated: true) {\r\n    name\r\n    description\r\n    args {\r\n      ...InputValue\r\n    }\r\n    type {\r\n      ...TypeRef\r\n    }\r\n    isDeprecated\r\n    deprecationReason\r\n  }\r\n  inputFields {\r\n    ...InputValue\r\n  }\r\n  interfaces {\r\n    ...TypeRef\r\n  }\r\n  enumValues(includeDeprecated: true) {\r\n    name\r\n    description\r\n    isDeprecated\r\n    deprecationReason\r\n  }\r\n  possibleTypes {\r\n    ...TypeRef\r\n  }\r\n}\r\n\r\nfragment InputValue on __InputValue {\r\n  name\r\n  description\r\n  type {\r\n    ...TypeRef\r\n  }\r\n  defaultValue\r\n}\r\n\r\nfragment TypeRef on __Type {\r\n  kind\r\n  name\r\n  ofType {\r\n    kind\r\n    name\r\n    ofType {\r\n      kind\r\n      name\r\n      ofType {\r\n        kind\r\n        name\r\n        ofType {\r\n          kind\r\n          name\r\n          ofType {\r\n            kind\r\n            name\r\n            ofType {\r\n              kind\r\n              name\r\n              ofType {\r\n                kind\r\n                name\r\n              }\r\n            }\r\n          }\r\n        }\r\n      }\r\n    }\r\n  }\r\n}";

            string endpointWithQuery = Endpoint + "?query=";
            await Task.Delay(5000);
            //schema = "{ getOneDepartment(id: 1) { iddepartment name }}";
            schema = schema.Replace("\r\n", "");
            schema = schema.Replace("  ", " ");
            var fullResponse = await client.GetAsync($"{endpointWithQuery + schema}");
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

                //Console.WriteLine(schemaObjectsToString);
                var obj = Root.FromJson(schemaObjectsToString);//works

                var nameObjectReturns = obj.Fields
                    .Where(it => it.Type?.OfType?.Name != null)
                    .Select(it => it.Type.OfType)
                    .Select(it => it.Name)
                    .ToArray();

                var nameObjectArgs = obj.Fields
                    .Where(it => it.Args?.Count > 0)
                    .SelectMany(it => it.Args)
                    .Select(it => it?.Type?.Name)
                    .Where(it=>it != null)
                    .ToArray();

                //remove from args the returns
                nameObjectArgs = 
                        nameObjectArgs.Where(it =>
                    !nameObjectReturns.Contains(it)).ToArray();

                var allObjectsNames = nameObjectReturns
                    .Union(nameObjectArgs)
                    .ToArray();
                // finally get the json
                var typesWithFields = allTypes
                    .Where(condition => condition.GetProperty("kind").GetString().Equals("OBJECT"))
                    .Where(condition => allObjectsNames.Contains( condition.GetProperty("name").GetString()))
                    .ToArray();

                var allTypesInGraph = typesWithFields
                    .Select(it => new GraphQLTypeArgument(it))
                    .ToArray();


                string controllerName = obj.Name;
                foreach(var f in obj.Fields)
                {
                    // generate GraphQLActionInfo
                    var action = new GraphQLActionInfo(f, allTypesInGraph);
                    action.ControllerName = controllerName; 
                    action.Init();

                    arrayOfActions.Add(action);

                }


            }
            //return the array of ACtion Info
            return arrayOfActions;
        }
    }
}
