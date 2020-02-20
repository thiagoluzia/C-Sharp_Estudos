using System;
using System.Globalization;
using System.Text;

namespace Exercicio12_Linq.Entities
{
    class Funcionario
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public double Salario { get; set; }

        public Funcionario()
        {
        }
        public Funcionario(string nome, string email, double salario)
        {
            Nome = nome;
            Email = email;
            Salario = salario;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Nome);
            sb.Append(", ");
            sb.Append(Email);
            sb.Append(", ");
            sb.Append(Salario.ToString("F2", CultureInfo.InvariantCulture));

            return sb.ToString();
        }

    }
}
