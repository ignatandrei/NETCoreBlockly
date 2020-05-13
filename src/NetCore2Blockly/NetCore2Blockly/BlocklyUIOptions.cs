using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore2Blockly
{
    /// <summary>
    /// options for UI
    /// </summary>
    public class BlocklyUIOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlocklyUIOptions"/> class.
        /// </summary>
        public BlocklyUIOptions()
        {
            StartBlocks = "";
        }
        
        /// <summary>
        /// Gets or sets the start blocks.
        /// </summary>
        /// <value>
        /// The start blocks.
        /// </value>
        public string StartBlocks { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string HeaderName { get; set; }
    }
}
