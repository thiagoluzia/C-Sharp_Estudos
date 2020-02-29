using System;

namespace Delegates
{
    class Program
    {
        #region 1º 
        //Criando a estrutura de um delegate, ou seja, a definição de um delegate
        delegate void PrimeiroDelegate(int x);
        //Criado uma variável que pode guardar metodos que seguem o padrão do delegate
        static PrimeiroDelegate meuDelegate;
        #endregion

        static void Main(string[] args)
        {
            #region 3º
            //atribuindo ao delegate um metodo e chamando um metodo atraves do delegate
            meuDelegate = CalcularNada;
            meuDelegate(10);

            meuDelegate = PrintarIdade;
            meuDelegate(30);

            Console.ReadKey();

            #endregion
        }

        #region 2º
        //Criando um metodo qualquer para testes
        static void CalcularNada(int nada)
        {
            Console.WriteLine(nada * 0);
        }
        static void PrintarIdade(int idade)
        {
            Console.WriteLine(idade);
        }
        #endregion
    }
}
