using Microsoft.AspNetCore.Mvc;

namespace api_auth.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AutoTestController : ControllerBase
    {

        [HttpGet()]
        public ActionResult AutoTest()
        {
            return Ok();
        }
    }
}
