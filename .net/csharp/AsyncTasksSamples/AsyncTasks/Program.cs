// Criando uma lista de Tasks e executando
// passando a Action (DoWork) como argumento

//      Lembretes !
//          -- Action: Um delegate que não retorna um tipo
//          -- Func: Um delegate que retorna um tipo
//          -- Delegate: Um ponteiro para uma função/método, ou seja, pode ser armazenado e executado através de variáveis
var tasks = new List<Task>()
{
    Task.Run(() => DoWork(1, 2000)),
    Task.Run(() => DoWork(2, 4000)),
    Task.Run(() => DoWork(3, 6000))
};

// Aguarda as Tasks serem executadas nas threads
await Task.WhenAll(tasks);

Console.WriteLine("Todas as tarefas foram concluídas.");


static void DoWork(int id, int milliseconds)
{
    Console.WriteLine($"Iniciando tarefa {id}");

    Thread.Sleep(milliseconds); // Simula uma operação demorada

    Console.WriteLine($"Tarefa {id} concluída");
}