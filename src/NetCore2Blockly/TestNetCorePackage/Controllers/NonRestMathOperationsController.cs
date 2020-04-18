using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestNetCorePackage
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NonRestMathOperationsController : ControllerBase
    {
        
        private MathParts ExecuteOperation(MathOperation op, int x, MathParts data)
        {


            return null;
        }
        [HttpGet("{x}/{y}")]
        public int Multiply(int x, int y)
        {
            return x * y;
        }

        [HttpPost("{x}/{y}")]
        public MathParts GetData(int x, int y)
        {
            return new MathParts()
            {
                x = x,
                y = y
            };
        }
        [HttpPost("{id}/{x}")]
        public MathParts Operation(MathOperation id, int x,[FromBody] MathParts data)
        {
            return ExecuteOperation(id, x, data);
        }
        [HttpPost]
        public int  Add([FromBody]MathParts data)
        {
            return data.x + data.y;
        }
        [HttpPost]
        public int Divide([FromBody]MathParts data)
        {
            return data.x / data.y;
        }

        [HttpPost("{id}")]
        public int Operations(MathOperation id,[FromBody] MathParts data)
        {
            return data.x / data.y;
        }

    }
    }