using src.Interfaces;

namespace src.Models;

public class Paragraph : DocumentElement
{
    public string Text { get; set; }
    public string FontFamily { get; set; } = "Arial";
    public int FontSize { get; set; } = 12;

    public Paragraph(string text) => Text = text;

    public override void Render() => Console.WriteLine($"[Parágrafo] {Text}");

    public override void Accept(IDocumentElementVisitor visitor) => visitor.Visit(this);
}