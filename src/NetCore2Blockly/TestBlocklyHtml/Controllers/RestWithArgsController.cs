using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestBlocklyHtml.Controllers
{
    [Route("api/[controller]/[action]")]
    public class RestWithArgsController : Controller
    {
        
       
        // POST api/<controller>
        [HttpPost]
        public async Task<string> PostWithArgs(string value)
        {
            await Task.Delay(500);
            return " received " + value;
        }

        
    }
}
