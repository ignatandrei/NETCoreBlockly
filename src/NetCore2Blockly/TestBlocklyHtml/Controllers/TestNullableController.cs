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
    public class TestNullableController : ControllerBase
    {

        [HttpGet("{id?}")]
        public string ActionWithNullParameter(int? id)
        {
            return (id == null) ? "no parameter" : $"parameter {id}";
        }
    }
}