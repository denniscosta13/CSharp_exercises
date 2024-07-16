using ClosedXML.Excel;
using PaoDuro.Domain.Enums;
using PaoDuro.Domain.Reports;
using PaoDuro.Domain.Repositories.Despesas;

namespace PaoDuro.Application.UseCase.Despesas.Reports.Excel;

public class GenerateDespesasReportExcelUseCase : IGenerateDespesasReportExcelUseCase
{
    private const string CURRENCY_SYMBOL = "$";
    private readonly IDespesasReadOnlyRepository _repository;

    public GenerateDespesasReportExcelUseCase(IDespesasReadOnlyRepository repository)
    {
        _repository = repository;
    }
    public async Task<byte[]> Execute(DateOnly month)
    {
        var despesas = await _repository.FilterByMonth(month);

        if (despesas.Count == 0) 
        {
            return [];
        }
        
        using var workbook = new XLWorkbook();

        workbook.Author = "Dennis";
        workbook.Style.Font.FontSize = 12;
        workbook.Style.Font.FontName = "Calibri";
        var worksheet = workbook.Worksheets.Add(month.ToString("Y"));

        InsertHeader(worksheet);

        var row = 2;
        foreach (var despesa in despesas) 
        {
            worksheet.Cell($"A{row}").Value = despesa.Title;
            worksheet.Cell($"B{row}").Value = despesa.Date;
            worksheet.Cell($"C{row}").Value = ConvertPaymentType(despesa.PaymentType);

            worksheet.Cell($"D{row}").Value = despesa.Amount;
            worksheet.Cell($"D{row}").Style.NumberFormat.Format = $"-{CURRENCY_SYMBOL}#,##0.00";

            worksheet.Cell($"E{row}").Value = despesa.Description;
            row++;

        }

        worksheet.Columns().AdjustToContents();

        var file = new MemoryStream();
        workbook.SaveAs(file);
        
        return file.ToArray();
    }

    private string ConvertPaymentType(PaymentType paymentType)
    {
        return paymentType switch
        {
            PaymentType.BankTransfer => PaymentTypeDescription.BANK_TRANSFER,
            PaymentType.Cash => PaymentTypeDescription.CASH,
            PaymentType.DebitCard => PaymentTypeDescription.DEBIT_CARD,
            PaymentType.CreditCard => PaymentTypeDescription.CREDIT_CARD,
            _ => string.Empty
        };
    }

    private void InsertHeader(IXLWorksheet worksheet)
    {
        worksheet.Cell("A1").Value = ResourceReportGenerationMessages.TITLE;
        worksheet.Cell("B1").Value = ResourceReportGenerationMessages.DATE;
        worksheet.Cell("C1").Value = ResourceReportGenerationMessages.PAYMENT_TYPE;
        worksheet.Cell("D1").Value = ResourceReportGenerationMessages.AMOUNT;
        worksheet.Cell("E1").Value = ResourceReportGenerationMessages.DESCRIPTION;

        worksheet.Cells("A1:E1").Style.Font.Bold = true;
        worksheet.Cells("A1:E1").Style.Fill.BackgroundColor = XLColor.FromHtml("#A020F0");

        worksheet.Cell("A1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        worksheet.Cell("B1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        worksheet.Cell("C1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        worksheet.Cell("D1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
        worksheet.Cell("E1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
    }
}
