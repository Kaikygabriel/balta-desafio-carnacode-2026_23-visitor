using src.Interfaces;

namespace src.Models;

public class Table : DocumentElement
{
    public List<List<string>> Cells { get; set; }
    public int Rows { get; }
    public int Columns { get; }

    public Table(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        Cells = new List<List<string>>();

        for (int i = 0; i < rows; i++)
        {
            var row = new List<string>();
            for (int j = 0; j < columns; j++)
                row.Add($"Cell {i},{j}");
            Cells.Add(row);
        }
    }

    public override void Render() => Console.WriteLine($"[Tabela] {Rows}x{Columns}");

    public override void Accept(IDocumentElementVisitor visitor) => visitor.Visit(this);
}
