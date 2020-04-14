using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestBlocklyHtml
{
    [ApiController]
    [Route("api/[controller]")]
    public partial class MathDivideRestController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public IEnumerable<Math2Values> Get()
        {
            return new Math2Values[]
            {
                new Math2Values(0,0),
                new Math2Values(1,1)
            };
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<Math2Values> Get(int id)
        {
            await Task.Delay(1000);
            return new Math2Values()
            {
                x = 1,
                y = id - 1
            };
        }

        [HttpPost]
        public async Task<double> Post([FromBody] Math2Values values)
        {
            await Task.Delay(1000);
            return (double)values.x / (double)values.y;
        }
        [HttpPut("{id}")]
        public async Task<Math2Values> Put(int id,[FromBody] Math2Values values)
        {
            await Task.Delay(1000);
            return new Math2Values()
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
