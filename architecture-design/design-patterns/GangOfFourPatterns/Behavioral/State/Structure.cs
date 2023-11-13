namespace State;

// O Contexto define a interface de interesse dos clientes. Isso também
// mantém uma referência a uma instância de uma subclasse State, que
// representa o estado atual do Contexto.
public class Context
{
    // Uma referência ao estado atual do Contexto.
    private State? _state = null;

    public Context(State state)
    {
        ChangeState(state);
    }

    // O Contexto permite alterar o objeto State em tempo de execução.
    public void ChangeState(State state)
    {
        Console.WriteLine($"Context: Trocando estado para {state.GetType().Name}.");
        _state = state;
        _state.SetContext(this);
    }

    // O Contexto delega parte do seu comportamento ao Estado atual
    public void ApertarBotão()
    {
        _state?.ApertarBotão();
    }

    public void Falar()
    {
        _state?.Falar();
    }
}

// A classe base abstrata "State" declara métodos que todo "Estado Concreto" deve
// implementar e também fornece uma referência ao próprio objeto Context,
// associado ao Estado.
//
// Esta referência pode ser usada pelos Estados para fazer a transição do Contexto para outro Estado.
public abstract class State
{
    protected Context? _context;

    public void SetContext(Context context)
    {
        this._context = context;
    }

    public abstract void ApertarBotão();

    public abstract void Falar();
}

// Os Estados Concretos implementam vários comportamentos,
// associados a um estado do contexto.
class AngryState : State
{
    public override void ApertarBotão()
    {
        Console.WriteLine("Apertando botão com Raiva!!!");
        Console.WriteLine("Agora que a Raiva passou, estou Feliz.");

        _context?.ChangeState(new HappyState());
    }

    public override void Falar()
    {
        Console.WriteLine("Falando com Raiva!!!");
    }
}

class HappyState : State
{
    public override void ApertarBotão()
    {
        Console.WriteLine("Apertando botão com Felicidade!!!");
    }

    public override void Falar()
    {
        Console.WriteLine("Falando com Felicidade!!!");
        Console.WriteLine("Agora que a Felicidade passou, estou com Raiva.");

        _context?.ChangeState(new AngryState());
    }
}
