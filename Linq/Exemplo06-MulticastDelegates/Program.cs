using Exemplo06_MulticastDelegates.Servicos;
using System;

namespace Exemplo06_MulticastDelegates
{
    class Program
    {
        delegate void MeuDelegado(double x, double y);
        static void Main(string[] args)
        {
            double a = 10;
            double b = 12;

            //com isso ele irar efetuar duas operações simultaneas
            MeuDelegado op = CalcularServicos.MostarSoma;
            op += CalcularServicos.MostrarMaior;

            //Primeiro ele exibe a soma de a+b =22, e depois o maior entre a e b = 12
            op.Invoke(a, b);
            //op(a,b);
        }
    }
}
