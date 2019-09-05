using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyWeb.Controllers {
    [Route("api/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [ApiController]
    public class DataController : ControllerBase {

        [HttpGet]
        public dynamic[] GetComputers() {
            var user = this.User.Identity.Name;

            return new[] {
                new {
                    IP = "1.2.3.4",
                    User = user
                }
            };
        }
    }
}