namespace FactoryMethod_Problem;

// Problema 1: Definindo os ConcreteProduct's e Products

// Imagine que estamos implementando uma aplicação igual o Ifood,
// e precisamos criar algumas classes de Hamburguers (ConcreteProduct).
// Cada hamburguer possui as suas diferenças, como por exemplo,
// se é uma carne de angus ou se é de soja, conforme abaixo
public class BeefBurguer1
{
    public int ProductId { get; set; }
    public bool IsAngus { get; set; } // Difference from Veggie
    public string? Description { get; set; }

    public void Prepare()
    {
        //... implementation
    }
}

public class VeggieBurguer1
{
    public int ProductId { get; set; }
    public bool IsSoyBased { get; set; } // Difference from Beef
    public string? Description { get; set; }

    public void Prepare()
    {
        //... implementation
    }
}

// Com base nisso, se formos implementar um método
// que realiza o pedido dos hamburguers (ConcreteProduct),
// ficaria mais ou menos assim:
public class Restaurant1
{
    // Esse código não compila porque não sabemos qual tipo de hamburguer retornar,
    // se é o Beef ou Veggie e o método retorna apenas UM tipo de objeto. 
    // Enquanto não tivermos uma classe pai que abstraia tanto o Beef quanto o Veggie,
    // essa implementação não poderá continuar.
    public void OrderBurguer(string typeOfBurguer)
    {
        if (typeOfBurguer == "BEEF")
        {
            BeefBurguer burguer = new BeefBurguer();

            burguer.Prepare();

            // return burguer; ???
        }
        else if (typeOfBurguer == "VEGGIE")
        {
            VeggieBurguer burguer = new VeggieBurguer();

            burguer.Prepare();

            // return burguer; ???
        }
    }
}

// Portanto, criaremos abaixo uma abstração para os
// ConcreteProduct’s pegando o que ambos tem em comum. Originando o Product:
public class Burguer1
{
    public int ProductId { get; set; } // Em comum entre os Burguers
    public string? Description { get; set; } // Em comum entre os Burguers

    public void Prepare()
    {
        //... implementation
    }
}

// #####################################################################

// Agora sim, o objeto de abstração (Product) pode ser herdado pelos ConcretProduct's
public class BeefBurguer11 : Burguer1
{
    public bool IsAngus { get; set; } // Difference from Veggie

    public void Prepare()
    {
        //... implementation
    }
}

public class VeggieBurguer11 : Burguer1
{
    public bool IsSoyBased { get; set; } // Difference from Beef

    public void Prepare()
    {
        //... implementation
    }
}

// E ser utilizado na função resolvendo o problema
public class Restaurant11
{
    public Burguer1? OrderBurguer(string typeOfBurguer)
    {
        if (typeOfBurguer == "BEEF")
        {
            Burguer1 burguer = new BeefBurguer11();

            burguer.Prepare();

            return burguer;
        }
        else if (typeOfBurguer == "VEGGIE")
        {
            Burguer1 burguer = new VeggieBurguer11();

            burguer.Prepare();

            return burguer;
        }

        return null;
    }
}
