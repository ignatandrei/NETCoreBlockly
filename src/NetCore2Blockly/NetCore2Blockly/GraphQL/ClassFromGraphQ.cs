using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace NetCore2Blockly.GraphQL
{
    public partial class Root
    {
        // [JsonProperty("kind")]
        public string Kind { get; set; }

        //[JsonProperty("name")]
        public string Name { get; set; }

        // [JsonProperty("description")]
        public object Description { get; set; }

        //[JsonProperty("fields")]
        public List<Field> Fields { get; set; }

        // [JsonProperty("inputFields")]
        public object InputFields { get; set; }

        // [JsonProperty("interfaces")]
        public List<object> Interfaces { get; set; }

        // [JsonProperty("enumValues")]
        public object EnumValues { get; set; }

        // [JsonProperty("possibleTypes")]
        public object PossibleTypes { get; set; }
    }

    public partial class Field
    {
        // [JsonProperty("name")]
        public string Name { get; set; }

        // [JsonProperty("description")]
        public object Description { get; set; }

        // [JsonProperty("args")]
        public List<Arg> Args { get; set; }

        // [JsonProperty("type")]
        public TypeClass Type { get; set; }

        // [JsonProperty("isDeprecated")]
        public bool IsDeprecated { get; set; }

        // [JsonProperty("deprecationReason")]
        public object DeprecationReason { get; set; }
    }

    public partial class Arg
    {
        // [JsonProperty("name")]
        public string Name { get; set; }

        // [JsonProperty("description")]
        public object Description { get; set; }

        // [JsonProperty("type")]
        public TypeClass Type { get; set; }

        // [JsonProperty("defaultValue")]
        public string DefaultValue { get; set; }
    }

    public partial class TypeClass
    {
        // [JsonProperty("kind")]
        public string Kind { get; set; }

        // [JsonProperty("name")]
        public string Name { get; set; }

        //[JsonProperty("ofType")]
        public TypeClass OfType { get; set; }
    }

    public partial class Root
    {
        public static Root FromJson(string json) => JsonConvert.DeserializeObject<Root>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Root self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
