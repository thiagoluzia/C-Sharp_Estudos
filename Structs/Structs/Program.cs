using System;

namespace Structs
{
    class Program
    {
        static void Main(string[] args)
        {
            //Chamada de um struct.
            Pessoa pessoa = new Pessoa();
            pessoa.nome = "Thiago";
            pessoa.idade = 30;

            Console.WriteLine($"NOME: {pessoa.nome} \nIDADE: {pessoa.idade}");
            Console.ReadKey();

        }
    }
}
