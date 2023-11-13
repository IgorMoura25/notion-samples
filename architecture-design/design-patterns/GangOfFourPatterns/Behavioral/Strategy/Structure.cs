namespace Strategy;

// A interface de estratégia declara todas as operações que são comuns para todas as "versões" de um mesmo algoritmo.
// Neste exemplo a família de algorítmos é a "Rota" e é dentro dessa família
// que as rotas/estratégias de Ônibus, Bicicleta e Carro farão parte.
// Tanto ônibus quanto bicicleta servem para levar uma pessoa de um ponto A para um ponto B (família de algoritmo),
// mas as formas que são executadas ou as "estratégias" são diferentes.
//
// O Contexto irá usar essa interface para chamar a classe concreta da estratégia.
public interface IRouteStrategy
{
    string BuildRoute(int latitude, int longitude);
}

// O Contexto define uma "ponte" entre o cliente e a estratégia
public class Context
{
    // O Contexto mantém uma referência a uma das estratégias concretas.
    // Ele não sabe a estratégia concreta, e deve trabalhar com todas elas através da inferface.
    private IRouteStrategy? _strategy;

    public Context()
    {
    }

    // Normalmente, o Contexto aceita uma estratégia através do construtor, mas
    // também fornece um setter para alterá-lo em tempo de execução.
    public Context(IRouteStrategy strategy)
    {
        _strategy = strategy;
    }

    // Normalmente, o Contexto permite substituir uma Estratégia em tempo de execução.
    public void SetStrategy(IRouteStrategy strategy)
    {
        _strategy = strategy;
    }

    // O Context delega algum trabalho ao objeto Strategy em vez de
    // implementar múltiplas versões do algoritmo por conta própria.
    public void PlanRoute(int latitude, int longitude)
    {
        Console.WriteLine("Context: Planejando uma rota utilizando uma estratégia que não sabe qual é");
        var result = _strategy.BuildRoute(latitude, longitude);

        Console.WriteLine(result);
    }
}

// Estratégias Concretas implementam o algoritmo seguindo a Interface de estratégia.
// Fazendo parte da família de algoritmos.
public class BusRouteStrategy : IRouteStrategy
{
    public string BuildRoute(int latitude, int longitude)
    {
        return "Ônibus: 20 minutos";
    }
}

public class BikeRouteStrategy : IRouteStrategy
{
    public string BuildRoute(int latitude, int longitude)
    {
        return "Bicicleta: 40 minutos";
    }
}

public class CarRouteStrategy : IRouteStrategy
{
    public string BuildRoute(int latitude, int longitude)
    {
        return "Ônibus: 10 minutos";
    }
}