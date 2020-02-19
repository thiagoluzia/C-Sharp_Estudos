using System;
using Exemplo05_Delegates.Servicos;

namespace Exemplo05_Delegates
{
    //criando a estrutura de um delegate
    delegate double MeuDelegate(double x, double y);
    //delegate double MeuQuadrado(double x);
    
    class Program
    {
        static void Main(string[] args)
        {
            double a = 10;
            double b = 12;

            //criando uma variavel do tipo do delegate
            MeuDelegate maiorNumero = new MeuDelegate(CalcularServicos.Maior);

            //Resultado de saida
            Console.WriteLine(maiorNumero(a, b));


            //*Outra maneira de chamar um delegate*
            MeuDelegate op = CalcularServicos.Somar;
            double resultado = op.Invoke(a, b);
            Console.WriteLine(resultado);

            MeuQuadrado quadrado = new MeuQuadrado(CalcularServicos.Quadrado);
            Console.WriteLine(quadrado(10));

            Console.ReadKey();

        }
    }
}
