using Microsoft.AspNetCore.Mvc;

namespace AlphaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class AlphaApiBaseController : ControllerBase
    {
        public string Author { get; set; } = "Dennis Costa";

        [HttpGet("healthy")]
        public IActionResult Healthy()
        {
            return Ok("Funcionando!");
        }

        protected string GetCustomKey() 
        {
            return Request.Headers["MyKey"].ToString();
        }
    }
}
