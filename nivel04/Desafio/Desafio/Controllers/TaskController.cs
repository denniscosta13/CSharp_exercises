using Desafio.Application.UseCases.Tasks.Delete;
using Desafio.Application.UseCases.Tasks.GetAll;
using Desafio.Application.UseCases.Tasks.GetById;
using Desafio.Application.UseCases.Tasks.Register;
using Desafio.Application.UseCases.Tasks.Update;
using Desafio.Communication.Requests;
using Desafio.Communication.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult Register(RequestTaskJson request)
    {
        var response = new RegisterTaskUseCase().Execute(request);

        return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseAllTasksJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetAll() 
    {
        var response = new GetAllTasksUseCase().Execute();
        if(response.Tasks.Count != 0) 
            return Ok(response);

        return NoContent();
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseTaskJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
    public IActionResult Get(int id)
    {
        var response = new GetByIdUseCase().Execute(id);
        
        return Ok(response);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
    public IActionResult Update([FromRoute] int id,RequestTaskJson request)
    {
        new UpdateTaskUseCase().Execute(id, request);
        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
    public IActionResult Delete(int id)
    {
        new DeleteTaskUseCase().Execute(id);
        return NoContent();
    }
}
