using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain
{
    public class Categoria : Entity
    {
        public string Nome { get; set; }
        public int Codigo { get; set; }

        public Categoria(string nome, int codigo)
        {
            Nome = nome;
            Codigo = codigo;

            Validar();
        }

        public void Validar()
        {
            // Validate it's own state to guarantee the integrity of the class, like checking if the class has a StockAmount minor than zero, etc.
            // Best practice is to have the validations on a AssertionConcern class that will throw an exception

            // AssertionConcern.ValidateIfEmpty(Nome, "Nome não pode ser vazio.");
        }
    }
}
