using Microsoft.AspNetCore.Mvc;

namespace AlphaApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public IActionResult GetById([FromRoute] int id)
    {
        var response = new User
        {
            Id = 1,
            Age = 0,
            Name = "Dennis"
        };
        
        return Ok(response);
    }
}
