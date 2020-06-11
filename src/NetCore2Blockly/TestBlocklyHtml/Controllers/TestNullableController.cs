using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestBlocklyHtml.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VariousTestsController : ControllerBase
    {

        [HttpGet("{id?}")]
        public string ActionWithNullParameter(int? id)
        {
            return (id == null) ? "from GET no parameter" : $"from GET parameter {id}";
        }

        [HttpPatch("{id?}")]
        public string ActionWithNullParameterPATCH(int? id)
        {
            return (id == null) ? "from PATCH no parameter" : $"from PATCH parameter {id}";
        }
        [HttpGet("{id}")]
        public string ActionWith2ParametersAndARoute(int id, int x, int y)
        {
            return $"received route {id} and parameters {x} {y}";
        }

        [HttpPost()]
        public string ActionWithDictionary([FromBody]Dictionary<string,string> id)
        {
            var str = 
                string.Join(",",
                id.Select(it => it.Key + "= " + it.Value)
                );
            return $"received {str}";
        }
    }
}