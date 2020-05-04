using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TestBlocklyHtml.Authorization;

namespace TestBlocklyHtml.Controllers
{
    [Route("api/[controller]")]
    public class RegistrationController : ControllerBase
    {
        private const string ExpectedSecretCode = "blockly";
        private readonly IConfiguration configuration;

        public RegistrationController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpPost]
        public IActionResult Register([FromBody] string secretCode)
        {
            if (IsRegistrationSuccessful(secretCode))
            {
                var authorizationToken = new AuthorizationToken(configuration);
                return Ok(authorizationToken.GenerateFrom(secretCode));
            }

            return BadRequest("invalid registration");
        }

        private bool IsRegistrationSuccessful(string secretCode)
        {
            return secretCode == ExpectedSecretCode;
        }
    }
}
