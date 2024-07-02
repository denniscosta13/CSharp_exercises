using Microsoft.AspNetCore.Mvc;
using PaoDuro.Application.UseCase.Despesas.Delete;
using PaoDuro.Application.UseCase.Despesas.GetAll;
using PaoDuro.Application.UseCase.Despesas.GetById;
using PaoDuro.Application.UseCase.Despesas.Register;
using PaoDuro.Application.UseCase.Despesas.Update;
using PaoDuro.Communication.Requests;
using PaoDuro.Communication.Responses;

namespace PaoDuro.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DespesasController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisterDespesaJson),StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromServices] IRegisterDespesaUseCase useCase , [FromBody] RequestDespesaJson request)
    {
            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseDespesasJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAllDespesas([FromServices] IGetAllDespesasUseCase useCase)
    {
        var response = await useCase.Execute();

        if(response.Despesas.Count != 0)
            return Ok(response);
        
        return NoContent();
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseDespesaJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById([FromServices] IGetDespesaByIdUseCase useCase, [FromRoute] long id)
    {
        var response = await useCase.Execute(id);

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete([FromServices] IDeleteDespesaUseCase useCase, [FromRoute] long id)
    {
        await useCase.Execute(id);

        return NoContent();
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(
        [FromServices] IUpdateDespesaUseCase useCase, 
        [FromRoute] long id,
        [FromBody] RequestDespesaJson request)
    {
        await useCase.Execute(id, request);

        return NoContent();
    }

}
