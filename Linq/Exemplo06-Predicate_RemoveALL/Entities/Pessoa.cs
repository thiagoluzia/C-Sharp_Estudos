namespace Exemplo06_Predicate_RemoveALL.Entities
{
    class Pessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }

        public Pessoa()
        {

        }
        public Pessoa(string nome, int idade)
        {
            Nome = nome;
            Idade = idade;
        }

        public override string ToString()
        {
            return Nome + ", " + Idade;
        }
    }
}
