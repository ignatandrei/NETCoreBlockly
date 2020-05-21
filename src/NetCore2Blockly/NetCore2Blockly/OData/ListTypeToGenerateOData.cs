using System;
using System.Collections.Generic;
using System.Linq;

namespace NetCore2Blockly.OData
{
    class ListTypeToGenerateOData : List<TypeArgumentBase>
    {
        
        internal TypeArgumentBase FindAfterId(string id)
        {
            var ret= this.FirstOrDefault(it => it.id == id);
            if(ret== null)
            {
                var lastId = id.Split('.', StringSplitOptions.RemoveEmptyEntries).Last();
                ret = this.FirstOrDefault(it => it.id == id);
            }
            if(ret == null)
            {
                ret = BlocklyTypeOdata.CreateValue(id);
                this.Add(ret);
            }
            return ret;
        }
    }
}
