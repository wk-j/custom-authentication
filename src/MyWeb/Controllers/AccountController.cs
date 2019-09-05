using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace MyWeb.Controllers {
    [Route("api/[controller]")]
    public class AccountController : ControllerBase {

        [HttpGet("login/{uid}")]
        public async Task<IActionResult> Login(string uid) {
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, uid));
            identity.AddClaim(new Claim(ClaimTypes.Name, uid));
            identity.AddClaim(new Claim(ClaimTypes.Role, "User"));

            var authProperties = new AuthenticationProperties {
                AllowRefresh = true,
                ExpiresUtc = DateTimeOffset.Now.AddDays(1),
                IsPersistent = true,
            };

            var principal = new ClaimsPrincipal(identity);


            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);

            return Ok(new { Uid = uid });
        }

    }
}