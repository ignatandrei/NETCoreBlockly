namespace NetCore2Blockly
{
    /// <summary>
    /// name link in config
    /// </summary>
    public class BLocklyNameLink
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the link.
        /// </summary>
        /// <value>
        /// The link.
        /// </value>
        public string Link { get; set; }
    }
    /// <summary>
    /// other dynamic links
    /// </summary>
    public class BLocklyOtherLinks
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BLocklyOtherLinks" /> class.
        /// </summary>
        public  BLocklyNameLink[] Swaggers{get;set;}
        /// <summary>
        /// Gets or sets the o datas.
        /// </summary>
        /// <value>
        /// The o datas.
        /// </value>
        public BLocklyNameLink[] ODatas { get; set; }

    }
}
