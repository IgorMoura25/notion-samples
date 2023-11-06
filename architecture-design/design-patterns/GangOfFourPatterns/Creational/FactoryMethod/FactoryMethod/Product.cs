namespace FactoryMethod;

// Interface / Classe Abstrata (Product)
public abstract class Burguer
{
    public int ProductId { get; set; } // Em comum entre os Burguers
    public string? Description { get; set; } // Em comum entre os Burguers

    public abstract void Prepare();
}
