namespace FactoryMethod_Problem;

// Problema 2: Separando a criação dos produtos em uma classe específica (fábrica)

// Mesmo que apliquemos a solução de abstração do Problema 1
// a classe restaurante ainda está violando os princípios
// de Single Responsibility e Open Closed do SOLID
public class Restaurant2
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

// Portanto, criaremos uma classe que sua
// única responsabilidade é criar os Products
public class BurguerFactory
{
    public Burguer1? CreateBurguer(string typeOfBurguer)
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

// E agora podemos deixar o Restaurante mais limpo
// tirando sua responsabilidade de criar hamburguers
public class Restaurant22
{
    public Burguer1? OrderBurguer(string typeOfBurguer)
    {
        var factory = new BurguerFactory();

        var burguer = factory.CreateBurguer(typeOfBurguer);

        return burguer;
    }
}

// Mas perceba que ainda assim essa BurguerFactory viola o Open Closed, portanto devemos aplicar o Factory Method para solucionar isso.
// Veja um exemplo de aplicação no projeto de solução