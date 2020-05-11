using Microsoft.OpenApi.Models;
using System;

namespace NetCore2Blockly.Swagger
{
    class PropertyBaseSwagger : PropertyBase
    {
        //TODO: find an example with an array here 
        public override bool IsArray =>  false;

        internal OpenApiSchema propertyTypeSchema;
    }
}
