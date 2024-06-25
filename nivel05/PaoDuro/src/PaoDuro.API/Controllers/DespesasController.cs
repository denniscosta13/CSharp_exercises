using Microsoft.AspNetCore.Mvc;
using PaoDuro.Application.UseCase.Despesas.GetAll;
using PaoDuro.Application.UseCase.Despesas.Register;
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
    public async Task<IActionResult> Register([FromServices] IRegisterDespesaUseCase useCase , [FromBody] RequestRegisterDespesaJson request)
    {
            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseDespesaJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAllDespesas([FromServices] IGetAllDespesasUseCase useCase)
    {
        var response = await useCase.Execute();

        if(response.Despesas.Count != 0)
            return Ok(response);
        
        return NoContent();
    }
}
