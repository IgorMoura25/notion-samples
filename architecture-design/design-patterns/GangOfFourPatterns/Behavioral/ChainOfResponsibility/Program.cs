using ChainOfResponsibility;

// Montamos a corrente
var monkey = new MonkeyHandler();
var squirrel = new SquirrelHandler();
var dog = new DogHandler();

// Main chain (Chamando a corrente inteira)
monkey.SetNext(squirrel).SetNext(dog);

IHandler dependencyInjection = monkey;

Console.WriteLine("Main chain (Chamando a corrente inteira)\n");
Console.WriteLine(dependencyInjection.Handle("Banana"));
Console.WriteLine(dependencyInjection.Handle("Nut"));
Console.WriteLine(dependencyInjection.Handle("MeatBall"));

// Subchain (Chamando da metade da corrente pra frente)
squirrel.SetNext(dog);

dependencyInjection = squirrel;

Console.WriteLine("Subchain (Chamando da metade da corrente pra frente)\n");
Console.WriteLine(dependencyInjection.Handle("Banana"));
Console.WriteLine(dependencyInjection.Handle("Nut"));
Console.WriteLine(dependencyInjection.Handle("MeatBall"));
