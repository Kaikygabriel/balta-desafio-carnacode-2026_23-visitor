
namespace src.Interfaces;

public interface IDocumentElementVisitor
{
    void Visit(Models.Paragraph p);
    void Visit(Models.Image img);
    void Visit(Models.Table t);
}