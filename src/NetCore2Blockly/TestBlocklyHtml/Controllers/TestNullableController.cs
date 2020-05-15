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
            return (id == null) ? "no parameter" : $"parameter {id}";
        }

        [HttpGet("{id}")]
        public string ActionWith2ParametersAndARoute(int id, int x, int y)
        {
            return $"received route {id} and parameters {x} {y}";
        }
    }
}