using Facade;

Subsystem1 subsystem1 = new Subsystem1();
Subsystem2 subsystem2 = new Subsystem2();
var facade = new Facade.Facade(subsystem1, subsystem2);

// O código cliente trabalha com subsistemas complexos através de uma simples
// interface fornecida pelo Façade. Quando uma fachada gerencia o ciclo de vida
// do subsistema, o cliente pode nem saber da existência
// do subsistema. Essa abordagem permite manter a complexidade sob controle.
Console.Write(facade.Operation());
