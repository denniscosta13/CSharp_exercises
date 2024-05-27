using Microsoft.AspNetCore.Mvc;
using PetFolio.Application.UseCases.Pets.Register;
using PetFolio.Application.UseCases.Pets.Update;
using PetFolio.Communication.Requests;
using PetFolio.Communication.Responses;

namespace PetFolio.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PetController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisterPetJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestPetJson request)
    {
        var response = new RegisterPetUseCase().Execute(request);
        
        return Created(string.Empty, response);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    public IActionResult Update([FromRoute] int id, RequestPetJson request) 
    {
        new UpdatePetUseCase().Execute(id, request);
        return NoContent();
    }
}
