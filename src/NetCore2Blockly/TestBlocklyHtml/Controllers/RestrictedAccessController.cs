using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TestBlocklyHtml.Controllers
{
    [Authorize(Policy = "CustomBearer")]
    //[Authorize]
    [Route("api/[controller]")]
    public class RestrictedAccessController : ControllerBase
    {
        [HttpGet]
        public IActionResult Ping()
        {
            return Ok("you can see a secret message that requires JWT authorization");
        }
    }
}
