using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestNetCorePackage
{
    [ApiController]
    [Route("api/[controller]")]
    public partial class RestMathController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public IEnumerable<MathParts> Get()
        {
            return new MathParts[]
            {
                new MathParts(0,0),
                new MathParts(1,1)
            };
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<MathParts> Get(int id)
        {
            await Task.Delay(1000);
            return new MathParts()
            {
                x = 1,
                y = id - 1
            };
        }

        [HttpPost]
        public async Task<double> Post([FromBody] MathParts values)
        {
            await Task.Delay(1000);
            return (double)values.x / (double)values.y;
        }
        [HttpPut("{id}")]
        public async Task<MathParts> Put(int id,[FromBody] MathParts values)
        {
            await Task.Delay(1000);
            return new MathParts()
            {
                x = values.x / id,
                y = values.y
            };
        }
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await Task.Delay(1000);
            return;
        }

    }
}
