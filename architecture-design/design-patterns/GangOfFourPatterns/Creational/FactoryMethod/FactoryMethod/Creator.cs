namespace FactoryMethod;

// Interface / Classe Abstrata (Creator)
public abstract class Restaurant
{
    public Burguer OrderBurguer()
    {
        var burguer = CreateBurguer();

        burguer.Prepare();

        return burguer;
    }

    // Factory Method
    public abstract Burguer CreateBurguer();
}
