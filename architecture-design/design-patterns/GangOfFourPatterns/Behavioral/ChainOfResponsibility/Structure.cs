namespace ChainOfResponsibility;

// A interface do Handler declara o método para construir a corrente de handlers.
// Também declara o método para processar a requisição.
public interface IHandler
{
    IHandler SetNext(IHandler handler); // ..construir a corrente de handlers

    object Handle(object request); // ..processar a requisição.
}

// O comportamento padrão do encadeamento pode ser implementado dentro do BaseHandler
abstract class AbstractHandler : IHandler
{
    private IHandler _nextHandler;

    // Guarda o próximo Handler
    // Não queremos que os ConcreteHandlers sobrescrevam esse método (então não colocamos virtual)
    public IHandler SetNext(IHandler handler)
    {
        _nextHandler = handler;

        // Se retornarmos o próprio Handler aqui podemos encadear chamadas
        // monkey.SetNext(squirrel).SetNext(dog);
        return handler;
    }

    // Chama o próximo Handler se houver
    // se não, o último handler já foi chamado e a corrente acabou
    // Virtual para que possa ser sobrescrito
    public virtual object Handle(object request)
    {
        if (_nextHandler != null)
        {
            return _nextHandler.Handle(request);
        }

        return null;
    }
}

// Concrete Handlers
class MonkeyHandler : AbstractHandler
{
    public override object Handle(object request)
    {
        if ((request as string) == "Banana")
        {
            return $"Monkey: I'll eat the {request}.\n";
        }
        else
        {
            return base.Handle(request);
        }
    }
}

class SquirrelHandler : AbstractHandler
{
    public override object Handle(object request)
    {
        if (request.ToString() == "Nut")
        {
            return $"Squirrel: I'll eat the {request}.\n";
        }
        else
        {
            return base.Handle(request);
        }
    }
}

class DogHandler : AbstractHandler
{
    public override object Handle(object request)
    {
        if (request.ToString() == "MeatBall")
        {
            return $"Dog: I'll eat the {request}.\n";
        }
        else
        {
            return base.Handle(request);
        }
    }
}