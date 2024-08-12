namespace PaoDuro.Application.UseCase.Despesas.Reports.Pdf;
public interface IGenerateDespesaReportPdfUseCase
{
    Task<byte[]> Execute(DateOnly month);
}
