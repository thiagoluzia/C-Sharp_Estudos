using System;
using System.Text;

namespace Exemplo01_IComparable.Entities
{
    class Produto//: IComparable<Produto>
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
            StringBuilder sb = new StringBuilder();
            sb.Append(Nome);
            sb.Append(", ");
            sb.Append(Preco.ToString("C2"));
            return sb.ToString();
        }

        // Igualo os maiusculos e minusculos antes, para depois comparar
        //public int CompareTo(Produto other)
        //{
        //    return Nome.ToUpper().CompareTo(other.Nome.ToUpper());
        //}
        

    }
}
