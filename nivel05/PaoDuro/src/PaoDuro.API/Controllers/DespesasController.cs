using Microsoft.AspNetCore.Mvc;
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
    public IActionResult Register([FromServices] IRegisterDespesaUseCase useCase , [FromBody] RequestRegisterDespesaJson request)
    {
            var response = useCase.Execute(request);

            return Created(string.Empty, response);
    }
}
