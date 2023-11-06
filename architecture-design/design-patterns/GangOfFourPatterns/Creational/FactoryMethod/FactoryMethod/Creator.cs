namespace FactoryMethod;

// Interface / Classe Abstrata (Creator)
public abstract class Restaurant
{
    // Método principal
    // Não me interessa mais saber qual tipo de hamburguer que é
    // quem sabe criar o hamburguer é a própria subclasse
    public Burguer OrderBurguer() // Sem acoplamento, dentro do SRP e OCP
    {
        // Chamando o create burguer da Concrete Creator / SubClasse
        var burguer = CreateBurguer();

        burguer.Prepare();

        return burguer;
    }

    // Factory Method
    public abstract Burguer CreateBurguer();
}
