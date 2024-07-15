using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaoDuro.Application.UseCase.Despesas.Reports.Excel;
using PaoDuro.Communication.Requests;
using System.Net.Mime;

namespace PaoDuro.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ReportController : ControllerBase
{
    [HttpGet("excel")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetExcel(
        [FromServices] IGenerateDespesasReportExcelUseCase useCase,
        [FromHeader] DateOnly month
        )
    {
        byte[] file = await useCase.Execute(month);

        if(file.Length > 0 )
            return File(file, MediaTypeNames.Application.Octet, "report.xlsx");

        return NoContent();
    }
}
