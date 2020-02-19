namespace Exemplo03_Comparison.Entities
{
    public class Produto
    {
        public string Nome { get; set; }
        public double Preco { get; set; }

        public Produto(string nome, double preco)
        {
            Nome = nome;
            Preco = preco;
        }
        public override string ToString()
        {
            return Nome + ", " + Preco.ToString("C2");
        }
    }
}