namespace FactoryMethod_Problem;

public class Burguer
{
    public int ProductId { get; set; } // Em comum entre os Burguers
    public string? Description { get; set; } // Em comum entre os Burguers
}

public class BeefBurguer
{
    public bool IsAngus { get; set; } // Difference from Veggie

    public void Prepare()
    {
        //... implementation
    }
}

public class VeggieBurguer
{
    public bool IsSoyBased { get; set; } // Difference from Beef

    public void Prepare()
    {
        //... implementation
    }
}
