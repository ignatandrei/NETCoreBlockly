namespace NetCore2BlocklyStorage.Sqlite.ModelsDB
{
    partial class Blocks
    {
        public void CopyPropsFrom(Blocks b)
        {
            this.Name = b.Name;
            this.Value = b.Value;
            this.Idcategory = Idcategory;
        }
    }
}
