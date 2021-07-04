using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace NetCore2Blockly.GraphQL
{
    /// <summary>
    /// 
    /// </summary>
    partial class Root
    {
        /// <summary>
        /// 
        /// </summary>
        public string Kind { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public object Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Field> Fields { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public object InputFields { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<object> Interfaces { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public object EnumValues { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public object PossibleTypes { get; set; }
    }

    public partial class Field
    {
        public string Name { get; set; }
        public object Description { get; set; }
        public List<Arg> Args { get; set; }
        public TypeClass Type { get; set; }
        public bool IsDeprecated { get; set; }
        public object DeprecationReason { get; set; }
    }

    public partial class Arg
    {
        public string Name { get; set; }
        public object Description { get; set; }
        public TypeClass Type { get; set; }
        public string DefaultValue { get; set; }
    }

    public partial class TypeClass
    {
        public string Kind { get; set; }
        public string Name { get; set; }
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
