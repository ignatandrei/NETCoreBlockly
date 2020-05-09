using System.Collections.Generic;
using System.Net.Mail;

namespace NetCore2Blockly
{
    public abstract class TypeArgumentBase
    {
        protected TypeArgumentBase(string id)
        {
            this.id = id;
            this.Name = id;
        }
        protected internal string Name;
        protected internal readonly string id;

        public abstract string FullName { get; }
        public abstract string TranslateToBlocklyType();

        public abstract bool ConvertibleToBlocklyType();

        public abstract string TranslateToBlocklyBlocksType();

        public abstract string TranslateToNewTypeName();
        public abstract bool IsEnum { get; }

        public abstract string TypeNameForBlockly { get; }

        public abstract PropertyBase[] GetProperties();

        public abstract Dictionary<string, long> GetValuesForEnum();

        public abstract bool IsValueType { get; }
        
    }
    public abstract class PropertyBase
    {
        public string Name { get; set; }
       
        public TypeArgumentBase PropertyType { get; set; }

        public abstract bool IsArray { get; }
    }

}