using Exercicio12_Linq.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Exercicio12_Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite o caminho do arquivo: ");
            string path = Console.ReadLine();


            List<Funcionario> listaFuncionario = new List<Funcionario>();
            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {

                    string[] vet = sr.ReadLine().Split(',');
                    string nome = vet[0];
                    string email = vet[1];
                    double salario = double.Parse(vet[2], CultureInfo.InvariantCulture);

                    listaFuncionario.Add(new Funcionario(nome, email, salario));
                }
            }

            Console.Write("Digite um dado valor para salário: ");
            double salarioACompar = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            //Filtragem por email
            var ordemPorEmail = listaFuncionario.Where(x => x.Salario > salarioACompar).OrderBy(x => x.Email).Select(x => x.Email);
            Console.WriteLine("Email dos funcionarios que recebem mais de 200.00");
            foreach (var funcionario in ordemPorEmail)
            {
                Console.WriteLine(funcionario);
            }

            string letra = "M";
            var salarioMaiorParaM = listaFuncionario.Where(x => x.Nome[0].ToString().ToUpper() == letra).Sum(x => x.Salario);

            Console.WriteLine("Soma do salário das pessoas que tem o nome com a inicial 'M': " + salarioMaiorParaM.ToString("F2", CultureInfo.InvariantCulture));

            Console.ReadKey();
        }
    }
}
