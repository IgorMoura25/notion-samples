using FactoryMethod;

Console.WriteLine("Client: I'm not aware of the SeaLogistics class or the LandLogistics class, but it still works.\n");
ClientCode(new SeaLogistics());
ClientCode(new LandLogistics());


// O código do cliente trabalha com a instância de um Concrete Creator através da Interface Creator
// Enquanto o cliente continuar trabalhando com o Creator,
// você pode passar qualquer ConcreteCreator Subclass que vai funcionar
static void ClientCode(Logistics creator)
{
    // ...
    Console.WriteLine(creator.PlanDelivery());
    // ...
}