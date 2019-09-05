using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyWeb.Controllers {
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class DataController : ControllerBase {

        [HttpGet]
        public dynamic[] GetComputers() {
            return new[] {
                new {
                    IP = "1.2.3.4"
                }
            };
        }
    }
}