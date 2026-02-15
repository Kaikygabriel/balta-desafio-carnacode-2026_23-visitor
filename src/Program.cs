using src.Document;
using src.Exports;
using src.Models;
using src.Visitors;

var doc = new Document("Relatório Anual");
doc.AddElement(new Paragraph("Este é o relatório anual da empresa."));
doc.AddElement(new Image("grafico.png", 800, 600));
doc.AddElement(new Paragraph("Abaixo os resultados financeiros do ano:"));
doc.AddElement(new Table(3, 4));
doc.AddElement(new Paragraph("Conclusão do relatório com recomendações."));

// Palavras
var wc = new WordCountVisitor();
doc.Apply(wc);
Console.WriteLine($"Total de palavras: {wc.TotalWords}");

// Validação
var val = new ValidationVisitor();
doc.Apply(val);
Console.WriteLine($"Documento válido: {val.IsValid} {(val.Error is null ? "" : $"(Erro: {val.Error})")}");

// HTML
var htmlV = new HtmlExportVisitor();
doc.Apply(htmlV);
var html = htmlV.BuildDocument(doc.Title);
Console.WriteLine(html.Substring(0, Math.Min(200, html.Length)) + "...");

// PDF
var pdfV = new PdfExportVisitor();
doc.Apply(pdfV);
var pdf = pdfV.BuildDocument(doc.Title);
Console.WriteLine(pdf.Substring(0, Math.Min(150, pdf.Length)) + "...");

// Tempo leitura
var rt = new ReadingTimeVisitor();
doc.Apply(rt);
Console.WriteLine($"Tempo estimado: {rt.Minutes} min");