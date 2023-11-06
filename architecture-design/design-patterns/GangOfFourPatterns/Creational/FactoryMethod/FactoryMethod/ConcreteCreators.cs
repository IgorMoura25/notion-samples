namespace FactoryMethod;

// ConcreteCreators (Subclasses)
public class BeefBurguerRestaurant : Restaurant
{
    //             Product
    public override Burguer CreateBurguer()
    {
        return new BeefBurguer(); // Concrete Product
    }
}

// ConcreteCreators (Subclasses)
public class VeggieBurguerRestaurant : Restaurant
{
    public override Burguer CreateBurguer()
    {
        return new VeggieBurguer();
    }
}
