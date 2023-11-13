// O código do cliente escolhe uma estratégia concreta e a passa para o
// contexto. O cliente deve estar ciente das diferenças entre
// estratégias para fazer a escolha certa.
using Strategy;

var context = new Context();

Console.WriteLine("Client: Escolhendo estratégia de Ônibus.");
context.SetStrategy(new BusRouteStrategy());
context.PlanRoute(latitude: 100, longitude: 500);

Console.WriteLine();

Console.WriteLine("Client: Escolhendo estratégia de Bike.");
context.SetStrategy(new BikeRouteStrategy());
context.PlanRoute(latitude: 100, longitude: 500);

Console.WriteLine();

Console.WriteLine("Client: Escolhendo estratégia de Carro.");
context.SetStrategy(new CarRouteStrategy());
context.PlanRoute(latitude: 100, longitude: 500);
