using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TestBlocklyHtml.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class RestrictedAccessController : ControllerBase
    {
        [HttpGet]
        public IActionResult Ping()
        {
            return Ok("pong");
        }
    }
}
