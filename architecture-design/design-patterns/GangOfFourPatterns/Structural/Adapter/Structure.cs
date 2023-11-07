namespace Adapter;

// A classe que será Adaptada contém comportamentos que queremos utilizar
// mas sua interface é incompatível com o código atual do cliente que só aceita XML
public class JsonLibrary // (Service)
{
    public string ReturnJsonRequest()
    {
        return "Here's your request!";
    }
}

// A classe que será usada para colaborar com o cliente
public interface ILibrary // (Client Interface)
{
    string ReturnXMLRequest();
}

// O Adapter faz a classe que será Adaptada (Service) ser compatível com a
// classe que o cliente usa (Client Interface)
public class XmlAdapter : ILibrary
{
    private readonly JsonLibrary _adaptee;

    public XmlAdapter(JsonLibrary adaptee)
    {
        _adaptee = adaptee;
    }

    public string ReturnXMLRequest()
    {
        var json = _adaptee.ReturnJsonRequest();

        var xml = ConvertToXml(json);

        return $"This is '{xml}' that was JSON";
    }

    private string ConvertToXml(string json)
    {
        return "XML";
    }
}
