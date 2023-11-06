namespace FactoryMethod;

// A classe Creator (Superclass) declara o Factory Method que deve retornar um objeto da interface Product.
// A subclasse do Creator geralmente fornece a implementação deste método
public abstract class Logistics // ## Creator ##
{
    // Tenha em mente que o Creator também pode fornecer uma implementação padrão do factory method
    public abstract ITransport CreateTransport(); // ## Factory Method ##

    // Perceba que apesar do nome, a responsabilidade principal do Creator não é a criação de Products
    // Geralmente ele contém lógica de negócio que depende de objetos de Product's retornado pelo Factory Method Usually, it contains some
    // Subclasses podem indiretamente mudar essa regra de negócio sobrescrevendo
    // o Factory Method e retornando um tipo de Product diferente
    public string PlanDelivery()
    {
        // Chama o Factory Method para criar um objeto de Product
        var product = CreateTransport();

        // Agora podemos usar o Product
        return $"Creator: The same creator's code has just worked with {product.DeliverCargo()}";
    }
}

// Concrete Creator's (Subclass) sobrescreve o Factory Method
// para alterar o tipo do Product
public class SeaLogistics /* ## Concrete Creator ## */ : Logistics
{
    // Perceba que a assinatura do método utiliza o tipo abstrato de Product
    // mesmo que o ConcreteProduct (Ship) seja o retorno.
    // Dessa forma o Creator (Logistics) permanece independente das classes ConcreteProduct (Ship)
    public override ITransport CreateTransport()
    {
        return new Ship();
    }
}

public class LandLogistics /* ## Concrete Creator ## */ : Logistics
{
    public override ITransport CreateTransport()
    {
        return new Truck();
    }
}

// Product interface que declara todas as operações
// que os ConcreteProducts devem implementar
public interface ITransport
{
    string DeliverCargo();
}

// Concrete Products fornecem as implementações específicas
public class Ship : ITransport
{
    public string DeliverCargo()
    {
        return "Delivery by Sea";
    }
}

public class Truck : ITransport
{
    public string DeliverCargo()
    {
        return "Delivery by Land";
    }
}
