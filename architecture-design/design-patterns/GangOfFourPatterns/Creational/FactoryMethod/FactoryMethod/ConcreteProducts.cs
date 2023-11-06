namespace FactoryMethod;

// Concrete Product
public class BeefBurguer : Burguer
{
    public bool IsAngus { get; set; } // Differenças do Veggie

    public override void Prepare()
    {
        //... único lugar do código que sabe como um Hamburguer de Carne é feito
    }
}

// Concrete Product
public class VeggieBurguer : Burguer
{
    public bool IsSoyBased { get; set; } // Differenças entre Beef

    public override void Prepare()
    {
        //... único lugar do código que sabe como um Hamburguer Veggie é feito
    }
}
