using FactoryMethod;

// Passando a responsabilidade ao cliente
// de chamar o ConcreteCreator (Subclasse) que fará a criação do Burguer
var beefRestaurant = new BeefBurguerRestaurant();
var veggieRestaurant = new VeggieBurguerRestaurant();

// Chamando o método da Creator (Restaurant) que por sua vez
// chama o método CreateBurguer da ConcreteCreator (BeefRestaurant)
var test = beefRestaurant.OrderBurguer();

var test2 = veggieRestaurant.OrderBurguer();
