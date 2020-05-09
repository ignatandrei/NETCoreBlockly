using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;

namespace NetCore2Blockly
{
    public abstract class TypeArgument
    {
        protected TypeArgument(string id)
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

        public abstract Property[] GetProperties();

        public abstract Dictionary<string, long> GetValuesForEnum();

        public abstract bool IsValueType { get; }
        
    }
    public class ListProperties : List<Property>
    {

    }
    public abstract class Property
    {
        public string Name { get; set; }
       
        public TypeArgument PropertyType { get; set; }

        public abstract bool IsArray { get; }
    }

    public class PropertyCSharp : Property
    {
        public override bool IsArray
        {
            get
            {
                var str = typeof(string).FullName;
                var arr = typeof(IEnumerable);
                return (!PropertyType.IsValueType)
                         &&
                         (PropertyType.FullName != str)
                         &&
                         arr.IsAssignableFrom((PropertyType as TypeToGenerateFromCSharp).t);
            }
        }
    }


    [DebuggerDisplay("Create {id}")]

    public class TypeToGenerateFromCSharp: TypeArgument
    {
        internal readonly Type t;
        private Property[] props;
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
        public override Property[] GetProperties()
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

        public override Dictionary<string, long> GetValuesForEnum()
        {
            if(!IsEnum)
                throw new NotImplementedException();

            var names = Enum.GetNames(t);
            var opt = names.Select(it => new KeyValuePair<string, long>(it, ValueEnum(Enum.Parse(t, it))));
            var ret = new Dictionary<string, long>(opt);
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