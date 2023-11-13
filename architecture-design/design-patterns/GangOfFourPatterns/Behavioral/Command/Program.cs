// The client code can parameterize an invoker with any commands.
using Command;

Invoker invoker = new Invoker();

invoker.SetOnStart(new SimpleCommand("Say Hi!"));

CommandHandler receiver = new CommandHandler();

invoker.SetOnFinish(new ComplexCommand(receiver, "Send email", "Save report"));

invoker.DoSomethingImportant();
