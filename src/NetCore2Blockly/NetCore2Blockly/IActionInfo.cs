using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace NetCore2Blockly
{
    /// <summary>
    /// generic action info
    /// </summary>
    [DebuggerDisplay("{Verb} {RelativeRequestUrl}")]
    public abstract class ActionInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActionInfo"/> class.
        /// </summary>
        public ActionInfo()
        {
            Params = new Dictionary<string, (TypeArgumentBase type, BindingSourceDefinition bs)>();
        }
        /// <summary>
        /// Gets or sets the name of the action.
        /// </summary>
        /// <value>
        /// The name of the action.
        /// </value>
        public string ActionName { get; set; }
        /// <summary>
        /// Gets or sets the name of the controller.
        /// </summary>
        /// <value>
        /// The name of the controller.
        /// </value>
        public string ControllerName { get; set; }
        /// <summary>
        /// Gets or sets the host.
        /// </summary>
        /// <value>
        /// The host.
        /// </value>
        public string Host { get; set; }
        /// <summary>
        /// Gets or sets the relative request URL.
        /// </summary>
        /// <value>
        /// The relative request URL.
        /// </value>
        public string RelativeRequestUrl { get; set; }
        /// <summary>
        /// Gets or sets the type of the return.
        /// </summary>
        /// <value>
        /// The type of the return.
        /// </value>
        public TypeArgumentBase ReturnType { get; set; }
        /// <summary>
        /// Gets or sets the verb.
        /// </summary>
        /// <value>
        /// The verb.
        /// </value>
        public string Verb { get; set; }
        /// <summary>
        /// Gets or sets the site.
        /// </summary>
        /// <value>
        /// The site.
        /// </value>
        public string Site { get; set; }
        /// <summary>
        ///  hash code do display.
        /// </summary>
        /// <returns></returns>
        public int CustomGetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + Host?.GetHashCode() ?? 0;
            hash = (hash * 7) + ControllerName.GetHashCode();

            return hash;

        }
        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        /// <value>
        /// The parameters.
        /// </value>
        public Dictionary<string, (TypeArgumentBase type, BindingSourceDefinition bs)> Params { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance has parameters.
        /// </summary>
        /// <value>
        ///  <c>true</c> if this instance has parameters; otherwise, <c>false</c>.
        /// </value>
        public bool HasParams => (Params?.Count > 0);
    }
}