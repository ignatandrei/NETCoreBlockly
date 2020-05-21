using NetCore2Blockly.Swagger;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security;

namespace NetCore2Blockly
{
    class AllTypes : List<TypeArgumentBase>
    {
        public AllTypes() : base()
        {

        }
        public AllTypes(IEnumerable<TypeArgumentBase> b) :base(b)
        {

        }
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