namespace NerdStore.Catalogo.Domain
{
    // ValueObject
    public class Dimensoes
    {
        public decimal Altura { get; private set; }
        public decimal Largura { get; private set; }
        public decimal Profundidade { get; private set; }

        public Dimensoes(decimal altura, decimal largura, decimal profundidade)
        {
            // Validations so it can't allow an instance of a invalid "Dimensoes" object
            Altura = altura;
            Largura = largura;
            Profundidade = profundidade;
        }

    }
}
