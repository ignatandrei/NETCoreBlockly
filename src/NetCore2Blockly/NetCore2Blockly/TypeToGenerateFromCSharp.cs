using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace NetCore2Blockly
{
    [DebuggerDisplay("Create {id}")]

    class TypeToGenerateFromCSharp: TypeArgumentBase
    {
        static ConcurrentDictionary<string, TypeToGenerateFromCSharp> allData = new ConcurrentDictionary<string, TypeToGenerateFromCSharp>();
        internal readonly Type t;
        private PropertyBase[] props;
        public TypeToGenerateFromCSharp(Type t) : base(t.FullName)
        {
            string fullName = t.FullName;
            this.t = t;
            if(!allData.ContainsKey(fullName))
                allData.TryAdd(fullName, this);

            props =
                t
                .GetProperties()
                .Where(prop => prop.GetSetMethod() != null)
                .Select(it => {
                    var f = it.PropertyType.FullName;
                    if (!allData.ContainsKey(f))
                    {
                        allData.TryAdd(f, new TypeToGenerateFromCSharp(it.PropertyType));
                    }
                    return new PropertyCSharp()
                    {
                        Name = it.Name,
                        PropertyType = allData[f]
                    };
                })
                .ToArray();
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
                string typeName = type.Name;
                if (type.IsGenericType)
                {
                    typeName = typeName.Replace("`", "_");
                }
                return typeName;
            }
        }

        public override string FullName => t.FullName;

        public override bool IsValueType => t.IsValueType;

        public TypeToGenerateFromCSharp GetUnderlyingArrayType()
        {
            if (!t.IsArray)
                return null;
            return new TypeToGenerateFromCSharp( t.GetElementType());

        }
    }

}