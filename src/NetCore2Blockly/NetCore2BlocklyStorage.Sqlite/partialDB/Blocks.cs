namespace NetCore2BlocklyStorage.Sqlite.ModelsDB
{
    
    partial class Blocks
    {
        public void CopyPropsFrom(Blocks b)
        {
            this.Name = b.Name;
            this.Val = b.Val;
            this.Idcategory = Idcategory;
        }
        public Blocks CleanSerialize()
        {
            IdcategoryNavigation = null;
            return this;
        }
    }
}
