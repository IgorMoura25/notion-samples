namespace FactoryMethod;

// ConcreteCreators (Subclasses)
public class BeefBurguerRestaurant : Restaurant
{
    //             Product
    public override Burguer CreateBurguer()
    {
        // Único lugar no código que é especialista em
        // instanciar esse hamburguer de carne super "complexo" :D
        return new BeefBurguer(); // Concrete Product
    }
}

// ConcreteCreators (Subclasses)
public class VeggieBurguerRestaurant : Restaurant
{
    public override Burguer CreateBurguer()
    {
        // Único lugar no código que é especialista em
        // instanciar esse hamburguer Veggie super "complexo" :D
        return new VeggieBurguer();
    }
}
