using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace MyWeb.Controllers {
    [Route("api/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [ApiController]
    public class DataController : ControllerBase {

        private readonly ILogger<DataController> _logger;

        public DataController(ILogger<DataController> logger) {
            _logger = logger;
        }

        [HttpGet]
        public dynamic[] GetComputers() {
            User.Claims.ToList().ForEach(x => {
                _logger.LogInformation("claim --- {@x}", x);
            });

            var user = User.Identity.Name;

            return new[] {
                new {
                    IP = "1.2.3.4",
                    User = user
                }
            };
        }
    }
}