
using DocumentFormat.OpenXml.Bibliography;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PaoDuro.Application.UseCase.Despesas.Reports.Pdf.Colors;
using PaoDuro.Application.UseCase.Despesas.Reports.Pdf.Fonts;
using PaoDuro.Domain.Entities;
using PaoDuro.Domain.Reports;
using PaoDuro.Domain.Repositories.Despesas;
using PdfSharp.Fonts;
using System.Reflection;

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

        var document = CreateDocument(month);
        var page = CreatePage(document);

        //cabecalho
        CreateHeaderPhotoAndName(page);

        //total de despesas
        var totalAmount = despesas.Sum(despesa => despesa.Amount);
        CreateTotalExpenseSection(page, month, totalAmount);

        foreach(var despesa in despesas)
        {
            var table = CreateExpenseTable(page);

            var row = table.AddRow();
            row.Height = 25;

            row.Cells[0].AddParagraph(despesa.Title);
            row.Cells[0].Format.Font = new Font { Name = FontHelper.RALEWAY_BLACK, Size = 14, Color = ColorsHelper.BLACK };
            row.Cells[0].Shading.Color = ColorsHelper.RED_LIGHT;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[0].MergeRight = 2; //mescla a com a celulas a direita, nesse caso as 2 a direita + a atual
            row.Cells[0].Format.LeftIndent = 20;

            row.Cells[3].AddParagraph(ResourceReportGenerationMessages.AMOUNT);
            row.Cells[3].Format.Font = new Font { Name = FontHelper.RALEWAY_BLACK, Size = 14, Color = ColorsHelper.WHITE };
            row.Cells[3].Shading.Color = ColorsHelper.RED_DARK;
            row.Cells[3].VerticalAlignment = VerticalAlignment.Center;

            var rowDivider = table.AddRow();
            rowDivider.Height = 25;
            rowDivider.Borders.Visible = false;
        } 

        return RenderDocument(document);
    }

    private Document CreateDocument(DateOnly month)
    {
        var document = new Document();
        document.Info.Title = $"{ResourceReportGenerationMessages.EXPENSES_FOR} {month:Y}";
        document.Info.Author = "Dennis Costa";

        var style = document.Styles["Normal"];
        style!.Font.Name = FontHelper.RALEWAY_REGULAR;

        return document;
    }

    private Section CreatePage(Document document)
    {
        var section = document.AddSection();
        section.PageSetup = document.DefaultPageSetup.Clone();
        section.PageSetup.PageFormat = PageFormat.A4;
        section.PageSetup.LeftMargin = 40;
        section.PageSetup.RightMargin = 40;
        section.PageSetup.TopMargin = 80;
        section.PageSetup.BottomMargin = 80;


        return section;
    }

    private byte[] RenderDocument(Document document)
    {
        var renderer = new PdfDocumentRenderer
        {
            Document = document,
        };

        renderer.RenderDocument();

        using var file = new MemoryStream();
        renderer.PdfDocument.Save(file);

        return file.ToArray();
    }

    private void CreateHeaderPhotoAndName(Section page)
    {
        var table = page.AddTable();
        table.AddColumn("85");
        table.AddColumn("300");

        var assembly = Assembly.GetExecutingAssembly();
        var directoryName = Path.GetDirectoryName(assembly.Location);
        var imagePath = Path.Combine(directoryName!, "Logo", "vp_email.jpg");

        var row = table.AddRow();
        row.Cells[0].AddImage(imagePath);

        row.Cells[1].AddParagraph("Hey, Dennis Costa");
        row.Cells[1].Format.Font = new Font { Name = FontHelper.RALEWAY_BLACK, Size = 16 };
        row.Cells[1].VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Center;
    }

    private void CreateTotalExpenseSection(Section page, DateOnly month, decimal totalAmount)
    {
        var paragraph = page.AddParagraph();
        paragraph.Format.SpaceBefore = "40";
        paragraph.Format.SpaceAfter = "40";

        var title = string.Format(ResourceReportGenerationMessages.TOTAL_SPENT_IN, month.ToString("Y"));

        paragraph.AddFormattedText(title, new Font { Name = FontHelper.RALEWAY_REGULAR, Size = 15 });

        paragraph.AddLineBreak();

        paragraph.AddFormattedText($"{totalAmount} {CURRENCY_SYMBOL}", new Font { Name = FontHelper.WORKSANS_BLACK, Size = 50 });
    }

    private Table CreateExpenseTable(Section page)
    {
        var table = page.AddTable();

        table.AddColumn("195").Format.Alignment = ParagraphAlignment.Left;
        table.AddColumn("80").Format.Alignment = ParagraphAlignment.Center;
        table.AddColumn("120").Format.Alignment = ParagraphAlignment.Center;
        table.AddColumn("120").Format.Alignment = ParagraphAlignment.Right;

        return table;
    }
}
