namespace src.Interfaces;
public abstract class DocumentElement
{
    public abstract void Render();
    public abstract void Accept(IDocumentElementVisitor visitor);
}