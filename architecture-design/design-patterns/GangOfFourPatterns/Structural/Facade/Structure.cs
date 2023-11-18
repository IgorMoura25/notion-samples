namespace Facade;

// A classe Façade fornece uma interface simples para a lógica complexa de um
// ou vários subsistemas. O Façade delega as solicitações do cliente ao
// objetos apropriados dentro do subsistema. A Fachada também é responsável
// por gerenciar seu ciclo de vida. Tudo isso protege o cliente da
// complexidade indesejada do subsistema.
public class Facade
{
    protected Subsystem1 _subsystem1;

    protected Subsystem2 _subsystem2;

    public Facade(Subsystem1 subsystem1, Subsystem2 subsystem2)
    {
        _subsystem1 = subsystem1;
        _subsystem2 = subsystem2;
    }

    // Os métodos do Façade são atalhos convenientes para as sofisticadas
    // funcionalidades dos subsistemas. No entanto, os clientes chegam apenas a uma
    // fração das capacidades de um subsistema.
    public string Operation()
    {
        string result = "Facade initializes subsystems:\n";
        result += _subsystem1.operation1();
        result += _subsystem2.operation1();
        result += "Facade orders subsystems to perform the action:\n";
        result += _subsystem1.operationN();
        result += _subsystem2.operationZ();
        return result;
    }
}

// O subsistema pode aceitar solicitações da fachada ou do cliente
// diretamente (recomendado que seja sempre da Fachada).
// De qualquer forma, para o Subsistema, a Fachada é mais um cliente, e não faz parte do Subsistema.
public class Subsystem1
{
    public string operation1()
    {
        return "Subsystem1: Faz alguma coisa!\n";
    }

    public string operationN()
    {
        return "Subsystem1: Faz alguma outra coisa!\n";
    }
}

// Some facades can work with multiple subsystems at the same time.
public class Subsystem2
{
    public string operation1()
    {
        return "Subsystem2: Faz tal coisa!\n";
    }

    public string operationZ()
    {
        return "Subsystem2: Faz tal outra coisa!\n";
    }
}
