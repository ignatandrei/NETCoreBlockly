namespace NetCore2Blockly
{
    /// <summary>
    /// defintion of binding
    /// See BindingSource
    /// </summary>
    internal enum BindingSourceDefinition
    {
        None = 0,
        Body,
        Custom,
        Form,
        Header,
        ModelBinding,
        Path,
        Query,
        Services,
        Special,
        FormFile,
    }
}