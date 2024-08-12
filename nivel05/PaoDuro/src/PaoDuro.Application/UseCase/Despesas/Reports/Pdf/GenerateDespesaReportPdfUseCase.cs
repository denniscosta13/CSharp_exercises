
using PaoDuro.Application.UseCase.Despesas.Reports.Pdf.Fonts;
using PaoDuro.Domain.Repositories.Despesas;
using PdfSharp.Fonts;

namespace PaoDuro.Application.UseCase.Despesas.Reports.Pdf;

public class GenerateDespesaReportPdfUseCase : IGenerateDespesaReportPdfUseCase
{
    private const string CURRENCY_SYMBOL = "€";
    private readonly IDespesasReadOnlyRepository _repository;

    public GenerateDespesaReportPdfUseCase(IDespesasReadOnlyRepository repository)
    {
        _repository = repository;

        GlobalFontSettings.FontResolver = new DespesasReportFontResolver();
    }

    public async Task<byte[]> Execute(DateOnly month)
    {
        var despesas = await _repository.FilterByMonth(month);
        if(despesas.Count == 0) 
        {
            return [];
        }

        return [];
    }
}
