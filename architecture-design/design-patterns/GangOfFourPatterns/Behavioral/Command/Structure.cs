namespace Command;

// A interface Command declara um método para executar um comando.
public interface ICommand
{
    void Execute();
}

// Alguns comandos podem implementar operações simples por conta própria.
class SimpleCommand : ICommand
{
    private string _payload = string.Empty;

    public SimpleCommand(string payload)
    {
        _payload = payload;
    }

    public void Execute()
    {
        Console.WriteLine($"SimpleCommand: See, I can do simple things like printing ({_payload})");
    }
}

// Contudo, alguns comandos podem delegar operações mais complexas para outros
// objetos, chamados "Receivers" ou "CommandHandlers".
class ComplexCommand : ICommand
{
    private CommandHandler _receiver;

    // Dados de contexto, necessários para iniciar os métodos do receptor.
    private string _argumentA;

    private string _argumentB;

    // Comandos complexos podem aceitar um ou vários objetos receptores junto
    // com quaisquer dados de contexto através do construtor.
    public ComplexCommand(CommandHandler receiver, string a, string b)
    {
        _receiver = receiver;
        _argumentA = a;
        _argumentB = b;
    }

    // Commands can delegate to any methods of a receiver.
    public void Execute()
    {
        Console.WriteLine("ComplexCommand: Complex stuff should be done by a receiver/command handler object.");

        _receiver.DoSomething(_argumentA);
        _receiver.DoSomethingElse(_argumentB);
    }
}

// As classes Receivers ou CommandHandlers contêm alguma lógica de negócio importante.
// Eles sabem como realizar todos os tipos de operações, associadas à realização de um command.
// Na verdade, qualquer classe pode servir como Receiver/CommandHandler.
public class CommandHandler
{
    public void DoSomething(string a)
    {
        Console.WriteLine($"Receiver: Working on ({a}.)");
    }

    public void DoSomethingElse(string b)
    {
        Console.WriteLine($"Receiver: Also working on ({b}.)");
    }
}

// O Invoker está associado a um ou vários comandos.
// Envia uma solicitação ao comando.
public class Invoker
{
    private ICommand? _onStart;

    private ICommand? _onFinish;

    // Inicializa os comandos
    public void SetOnStart(ICommand command)
    {
        _onStart = command;
    }

    public void SetOnFinish(ICommand command)
    {
        _onFinish = command;
    }

    // O Invoker não depende de comandos concretos ou classes receptoras.
    // O Invoker passa uma solicitação para um Receiver/CommandHandler indiretamente, executando um
    // comando.
    public void DoSomethingImportant()
    {
        Console.WriteLine("Invoker: Does anybody want something done before I begin?");

        if (_onStart is ICommand)
        {
            _onStart.Execute();
        }

        Console.WriteLine("Invoker: ...doing something really important...");

        Console.WriteLine("Invoker: Does anybody want something done after I finish?");

        if (_onFinish is ICommand)
        {
            _onFinish.Execute();
        }
    }
}