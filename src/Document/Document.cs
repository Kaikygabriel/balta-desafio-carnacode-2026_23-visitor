using src.Interfaces;

namespace src.Document;


public class Document
{
    public string Title { get; set; }
    public List<DocumentElement> Elements { get; } = new();

    public Document(string title) => Title = title;

    public void AddElement(DocumentElement element) => Elements.Add(element);

    public void Apply(IDocumentElementVisitor visitor)
    {
        foreach (var element in Elements)
            element.Accept(visitor);
    }
}