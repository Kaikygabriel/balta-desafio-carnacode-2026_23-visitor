using System.Text;
using src.Interfaces;

namespace src.Exports
{
    public sealed class HtmlExportVisitor : IDocumentElementVisitor
    {
        private readonly StringBuilder _sb = new();

        public string BuildDocument(string title)
        {
            return $"<html><head><title>{title}</title></head><body>{_sb}</body></html>";
        }

        public void Visit(Models.Paragraph p)
        {
            _sb.Append($"<p style='font-family:{p.FontFamily};font-size:{p.FontSize}px'>{Escape(p.Text)}</p>");
        }

        public void Visit(Models.Image img)
        {
            _sb.Append($"<img src='{Escape(img.Url)}' width='{img.Width}' height='{img.Height}' alt='{Escape(img.Alt)}' />");
        }

        public void Visit(Models.Table t)
        {
            _sb.Append("<table>");
            foreach (var row in t.Cells)
            {
                _sb.Append("<tr>");
                foreach (var cell in row)
                    _sb.Append($"<td>{Escape(cell)}</td>");
                _sb.Append("</tr>");
            }
            _sb.Append("</table>");
        }

        private static string Escape(string s) =>
            string.IsNullOrEmpty(s) ? "" : s.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;");
    }
}