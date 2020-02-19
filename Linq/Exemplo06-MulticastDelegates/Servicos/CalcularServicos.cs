namespace Exemplo06_MulticastDelegates.Servicos
{
    class CalcularServicos
    {
        public static void MostrarMaior(double x, double y)
        {
            double maior = (x > y) ? x : y;
            System.Console.WriteLine(maior);
        }

        public static void MostarSoma(double x, double y)
        {
            double resultado = x + y;
            System.Console.WriteLine(resultado);
        }
    }
}