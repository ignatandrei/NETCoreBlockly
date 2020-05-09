using NetCore2Blockly.Swagger;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace NetCore2Blockly
{
   class AllTypes : List<TypeArgumentBase>
    {
        public TypeArgumentBase FindAfterId(string id)
        {
            var ret = this.FirstOrDefault(it => it.id == id);
            if (ret == null)
            {
                ret = BlocklyType.CreateValue(id);
                this.Add(ret);
            }
            return ret;
        }

        public TypeToGenerateSwagger[] MustCreateBlocks()
        {
            return this
                .Where(it => it as TypeToGenerateSwagger != null)

                .Cast<TypeToGenerateSwagger>()

                .ToArray();
        }
    }
    /// <summary>
    /// emultates a type
    /// </summary>
    public abstract class TypeArgumentBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TypeArgumentBase"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        protected TypeArgumentBase(string id)
        {
            this.id = id;
            this.Name = id;
        }

        /// <summary>
        /// The name
        /// </summary>
        protected internal string Name;
        /// <summary>
        /// The identifier
        /// </summary>
        protected internal readonly string id;
        /// <summary>
        /// Gets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        public abstract string FullName { get; }
        /// <summary>
        /// Translates the type of to blockly.
        /// </summary>
        /// <returns></returns>
        public abstract string TranslateToBlocklyType();

        /// <summary>
        /// Convertibles the type of to blockly.
        /// </summary>
        /// <returns></returns>
        public abstract bool ConvertibleToBlocklyType();

        /// <summary>
        /// Translates the type of to blockly blocks.
        /// </summary>
        /// <returns></returns>
        public abstract string TranslateToBlocklyBlocksType();

        /// <summary>
        /// Translates the name of to new type.
        /// </summary>
        /// <returns></returns>
        public abstract string TranslateToNewTypeName();
        /// <summary>
        /// Gets a value indicating whether this instance is enum.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is enum; otherwise, <c>false</c>.
        /// </value>
        public abstract bool IsEnum { get; }

        /// <summary>
        /// Gets the type name for blockly.
        /// </summary>
        /// <value>
        /// The type name for blockly.
        /// </value>
        public abstract string TypeNameForBlockly { get; }

        /// <summary>
        /// Gets the properties.
        /// </summary>
        /// <returns></returns>
        public abstract PropertyBase[] GetProperties();

        /// <summary>
        /// Gets the values for enum.
        /// </summary>
        /// <returns></returns>
        public abstract Dictionary<string, long> GetValuesForEnum();

        /// <summary>
        /// Gets a value indicating whether this instance is value type.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is value type; otherwise, <c>false</c>.
        /// </value>
        public abstract bool IsValueType { get; }
        
    }
    /// <summary>
    /// emulates a property
    /// </summary>
    public abstract class PropertyBase
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of the property.
        /// </summary>
        /// <value>
        /// The type of the property.
        /// </value>
        public TypeArgumentBase PropertyType { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance is array.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is array; otherwise, <c>false</c>.
        /// </value>
        public abstract bool IsArray { get; }
    }

}