using System;

namespace ExpressoesLambda
{
    class Program
    {
        //Criando um delegate para nao utilizar o generico Func<> oferecido pela linguagem
        delegate int semparametro(int numero);
      
        static void Main(string[] args)
        {
            //Parametros => Implementação 
            Func<int, int> quadrado = x => x * x;
            Console.WriteLine(quadrado(10));

            //Com meu delegate
            semparametro meudelegate = x => x * x;
            Console.WriteLine(meudelegate(5));

            Console.ReadKey();
        }
    }
}
