namespace PaoDuro.Application.UseCase.Despesas.Reports.Excel;
public interface IGenerateDespesasReportExcelUseCase
{
    Task<byte[]> Execute(DateOnly month);
}
