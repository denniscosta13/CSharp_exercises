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
    public IActionResult Register([FromBody] RequestRegisterDespesaJson request)
    {
        try
        {
            var useCase = new RegisterDespesaUseCase();
            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }
        catch (ArgumentException ex)
        {
            var errorResponse = new ResponseErrorJson(ex.Message);

            return BadRequest(errorResponse);
        }
        catch
        {
            var errorResponse = new ResponseErrorJson("Erro desconhecido");

            return StatusCode(StatusCodes.Status500InternalServerError,errorResponse);
        }
    }
}
