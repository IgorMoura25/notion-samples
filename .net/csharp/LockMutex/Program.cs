namespace AsyncTasks;

public static class Program
{
    // #! Para evitar deadlocks !#
    //     Uma instância de objeto dedicado para o lock.
    //     Tente evitar usar a mesma instância de objeto lock para diferentes tipos
    //     de recursos compartilhados, pois pode ocasionar deadlocks.
    private static readonly object _counterLock = new object();

    // Recurso compartilhado entre as threads
    // que será bloqueado através de exclusão mútua
    private static int _counter { get; set; } = 0;

    public async static Task Main(string[] args)
    {
        // Criando uma lista de Tasks e executando
        // passando a Action (IncrementCounter) como argumento

        //      Lembretes !
        //          -- Action: Um delegate que não retorna um tipo
        //          -- Func: Um delegate que retorna um tipo
        //          -- Delegate: Um ponteiro para uma função/método, ou seja, pode ser armazenado e executado através de variáveis
        var tasks = new List<Task>();

        for (int i = 0; i < 20; i++)
        {
            tasks.Add(Task.Run(() => IncrementCounter(i)));
        }

        // Aguarda as Tasks serem executadas nas threads
        await Task.WhenAll(tasks);

        Console.WriteLine("Todas as tarefas foram concluídas.");

        // Cada thread deve incrementar o contador em 1000, portanto com 20 threads o contador deve ser 20.000
        // Se tirarmos o lock muito provável que não chegará nesse valor por conta da concorrência
        // que está ocorrendo entre as threads, tornando o recurso compartilhado inconsistente
        Console.WriteLine($"Valor final do contador: {_counter}");
    }

    public static void IncrementCounter(int id)
    {
        Console.WriteLine($"Iniciando tarefa {id}");

        for (int i = 0; i < 1000; i++)
        {
            lock (_counterLock) // Utilizando lock para controlar o acesso ao recurso compartilhado
            {
                _counter++; // Operação crítica que incrementa o contador
            }
        }

        Console.WriteLine($"Tarefa {id} concluída");
    }
}