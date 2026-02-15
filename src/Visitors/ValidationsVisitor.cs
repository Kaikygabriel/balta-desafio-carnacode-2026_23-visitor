using src.Interfaces;

namespace src.Visitors
{
    public sealed class ValidationVisitor : IDocumentElementVisitor
    {
        public bool IsValid { get; private set; } = true;
        public string? Error { get; private set; }

        public void Visit(Models.Paragraph p)
        {
            if (!IsValid) return;
            if (string.IsNullOrWhiteSpace(p.Text)) Fail("Parágrafo sem texto.");
            else if (p.Text.Length >= 1000) Fail("Parágrafo grande demais.");
        }

        public void Visit(Models.Image img)
        {
            if (!IsValid) return;
            if (string.IsNullOrWhiteSpace(img.Url)) Fail("Imagem sem URL.");
            else if (img.Width <= 0 || img.Height <= 0) Fail("Imagem com dimensões inválidas.");
        }

        public void Visit(Models.Table t)
        {
            if (!IsValid) return;
            if (t.Rows <= 0 || t.Columns <= 0) Fail("Tabela com tamanho inválido.");
            else if (t.Cells.Count != t.Rows) Fail("Tabela com linhas inconsistentes.");
        }

        private void Fail(string msg)
        {
            IsValid = false;
            Error = msg;
        }
    }
}