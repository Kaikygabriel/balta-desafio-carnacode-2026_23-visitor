using src.Interfaces;

namespace src.Exports
{
    public sealed class WordCountVisitor : IDocumentElementVisitor
    {
        public int TotalWords { get; private set; }

        public void Visit(Models.Paragraph p)
        {
            TotalWords += CountWords(p.Text);
        }

        public void Visit(Models.Image img)
        {
            // imagens não contam
        }

        public void Visit(Models.Table t)
        {
            foreach (var row in t.Cells)
            foreach (var cell in row)
                TotalWords += CountWords(cell);
        }

        private static int CountWords(string text) =>
            string.IsNullOrWhiteSpace(text)
                ? 0
                : text.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
    }
}