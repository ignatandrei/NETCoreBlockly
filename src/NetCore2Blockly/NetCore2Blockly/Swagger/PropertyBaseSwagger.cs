using Microsoft.OpenApi.Models;
using System;

namespace NetCore2Blockly.Swagger
{
    class PropertyBaseSwagger : PropertyBase
    {
        public override bool IsArray => throw new NotImplementedException();

        internal OpenApiSchema propertyTypeSchema;
    }
}
