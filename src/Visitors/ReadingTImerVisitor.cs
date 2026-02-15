using src.Interfaces;

namespace src.Visitors
{
    public sealed class ReadingTimeVisitor : IDocumentElementVisitor
    {
        private int _totalWords;
        public int Minutes => _totalWords / 200; // 200 palavras/min

        public void Visit(Models.Paragraph p) => _totalWords += CountWords(p.Text);
        public void Visit(Models.Image img) { }
        public void Visit(Models.Table t)
        {
            foreach (var row in t.Cells)
            foreach (var cell in row)
                _totalWords += CountWords(cell);
        }

        private static int CountWords(string text) =>
            string.IsNullOrWhiteSpace(text)
                ? 0
                : text.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
    }
}