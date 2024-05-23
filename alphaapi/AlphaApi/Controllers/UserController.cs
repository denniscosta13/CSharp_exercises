using AlphaApi.Communication.Requests;
using AlphaApi.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AlphaApi.Controllers;


public class UserController : AlphaApiBaseController
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

    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisterUserJson), StatusCodes.Status201Created)]
    public IActionResult Create([FromBody] RequestRegisterUserJson request)
    {
        var response = new ResponseRegisterUserJson
        {
            Id = 1,
            Name = request.Name,
        };
        
        return Created(string.Empty, response);
    }
    [HttpPut]
    /*[Route("{id}")]*/
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Update(
        /*[FromRoute] int id,*/
        [FromBody] RequestUpdateUserProfileJson request)
    {
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Update()
    {
        return NoContent();
    }


    [HttpGet]
    [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
    public IActionResult GetAll() 
    {
        var response = new List<User>()
        {
            new User {Id = 1, Age = 28, Name = "Dennis"},
            new User {Id = 2, Age = 30, Name = "Joao"},
            new User {Id = 3, Age = 77, Name = "Jose"}
        };

        return Ok(response);
    }

    [HttpPut("change-password")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult ChangePassword([FromBody] RequestChangePasswordJson request)
    {
        return NoContent();
    }
}
