using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace NetCore2Blockly
{
    [DebuggerDisplay("Create {id}")]

    class TypeToGenerateFromCSharp: TypeArgumentBase
    {
        internal readonly Type t;
        private PropertyBase[] props;
        public TypeToGenerateFromCSharp(Type t) : base(t.FullName)
        {
            this.t = t;
            props =
                t.GetProperties().Where(prop => prop.GetSetMethod() != null)
                .Select(it => new PropertyCSharp() {
                    Name = it.Name, 
                    
                    PropertyType = new TypeToGenerateFromCSharp(it.PropertyType)
                }).ToArray();
                ;

        }
        public override PropertyBase[] GetProperties()
        {
            return props;
        }
        public override string TranslateToBlocklyType()
        {
            return t.TranslateToBlocklyType();
        }
        public override bool ConvertibleToBlocklyType()
        {
            return t.ConvertibleToBlocklyType();
        }
        public override string TranslateToBlocklyBlocksType()
        {
            return t.TranslateToBlocklyBlocksType();
        }
        public override string TranslateToNewTypeName()
        {
            return t.TranslateToNewTypeName();
        }

        public override Dictionary<string, object> GetValuesForEnum()
        {
            if(!IsEnum)
                throw new NotImplementedException();

            var names = Enum.GetNames(t);
            var opt = names.Select(it => new KeyValuePair<string, object>(it, ValueEnum(Enum.Parse(t, it))));
            var ret = new Dictionary<string, object>(opt);
            return ret;

        }
        private long ValueEnum(object o)
        {
            try
            {
                return (long)o;
            }
            catch
            {

                return (int)o;
            }
            throw new ArgumentException("there is an enum that is not valid");
        }
        public override bool IsEnum 
        {
            get
            {
                return t.IsEnum;
            }
        }

        public override string TypeNameForBlockly
        {
            get
            {

                var type = Nullable.GetUnderlyingType(t) ?? t;
                return type.Name;
            }
        }

        public override string FullName => t.FullName;

        public override bool IsValueType => t.IsValueType;
    }

}