using Adapter;

var adaptee = new JsonLibrary();

ILibrary adapter = new Adapter.XmlAdapter(adaptee);

// Cliente chamando a interface diretamente
// e o adapter se encarregando de encapsular o Adaptee
// e converter seu código tornando compatível o compartilhamento
// entre Cliente vs Interface incompatível
Console.WriteLine(adapter.ReturnXMLRequest());
