namespace NetCore2Blockly.OData
{
    class PropertyBaseOData : PropertyBase
    {
        internal readonly string typeOdata;

        public PropertyBaseOData(string name, string typeOdata):base()
        {
            this.Name = name;
            this.typeOdata = typeOdata;
        }
        public override bool IsArray => false;

        
    }
}
