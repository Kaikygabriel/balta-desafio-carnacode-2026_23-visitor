using System.Text;
using src.Interfaces;

namespace src.Exports
{
    public sealed class PdfExportVisitor : IDocumentElementVisitor
    {
        private readonly StringBuilder _sb = new();

        public string BuildDocument(string title) => $"PDF_DOCUMENT({title}) {_sb}";

        public void Visit(Models.Paragraph p)
        {
            _sb.Append($" PDF_TEXT({p.Text}, {p.FontFamily}, {p.FontSize})");
        }

        public void Visit(Models.Image img)
        {
            _sb.Append($" PDF_IMAGE({img.Url}, {img.Width}, {img.Height})");
        }

        public void Visit(Models.Table t)
        {
            _sb.Append($" PDF_TABLE({t.Rows}, {t.Columns}, data...)");
        }
    }
}