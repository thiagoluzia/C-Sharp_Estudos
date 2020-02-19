namespace Exemplo05_Delegates.Servicos
{
    public class CalcularServicos
    {
        public static double Maior(double x, double y){
            return (x > y) ? x : y;
        }

        public static double Somar(double x, double y){
            return x + y;
        }
        
        public static double Quadrado(double x){
            return x * x;
        }
    }
}