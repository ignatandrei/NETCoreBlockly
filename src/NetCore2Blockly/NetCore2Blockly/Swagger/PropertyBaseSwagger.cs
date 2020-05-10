using Microsoft.OpenApi.Models;
using System;

namespace NetCore2Blockly.Swagger
{
    class PropertyBaseSwagger : PropertyBase
    {
        //TODO: verify is array here! 
        public override bool IsArray =>  false;

        internal OpenApiSchema propertyTypeSchema;
    }
}
