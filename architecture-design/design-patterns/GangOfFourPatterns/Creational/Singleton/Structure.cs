namespace Singleton;

// Esta implementação Singleton é chamada de "bloqueio de verificação dupla". É seguro
// em ambiente multithread e fornece inicialização lenta para o Objeto singleton.
class Singleton
{
    // We'll use this property to prove that our Singleton really works.
    public string Value { get; set; }

    private static Singleton? _instance;

    // Construtor
    private Singleton() { }

    // Agora temos um objeto lock que será usado para sincronizar threads
    // durante o primeiro acesso ao Singleton.
    private static readonly object _lockInstance = new object();

    public static Singleton GetInstance(string value)
    {
        // Esta condicional é necessária para evitar que threads tropecem no
        // bloqueio quando a instância estiver pronta.
        if (_instance == null)
        {
            // Agora imagine que o programa acaba de ser lançado. Desde
            // ainda não há instância Singleton, vários threads podem
            // passe simultaneamente pela condicional anterior e alcance esta
            // ponto quase ao mesmo tempo. O primeiro deles adquirirá
            // bloqueie e prosseguirá, enquanto o resto esperará aqui.
            lock (_lockInstance)
            {
                // A primeira thread a adquirir o bloqueio chega a este
                // condicional, entra e cria o Singleton instância.
                // Depois de sair do bloco de bloqueio, um thread que
                // poderia estar esperando pela liberação do bloqueio pode então
                // entrar nesta seção. Mas como o campo Singleton já está inicializado,
                // a thread não criará um novo objeto.
                if (_instance == null)
                {
                    _instance = new Singleton();
                    _instance.Value = value;
                }
            }
        }
        return _instance;
    }
}
