using System;

namespace Eventos
{
    //1º Delcarar um delegate para o evento
    public delegate void DelegatePadrao();

    //2º Um evento esta sempre atrelado a uma classe, e funciona bem semelhante a um atributo comum
    class TesteEvento
    {
        event DelegatePadrao meuPrimeiroEvento;

        //3ºCadatrando os metodos ao evento
        public TesteEvento()
        {
            //Adicionando um metodo em um evento
            meuPrimeiroEvento += Normal;
            meuPrimeiroEvento += Thiago;
            //meuPrimeiroEvento -= Thiago; Removendo metodos do evento
            
        }

        //4º Para testes, metodo que chama o evento
        public void ChamarEvento()
        {
            meuPrimeiroEvento();
        }
        private void Thiago()
        {
            Console.WriteLine("Meu nome é Thiago");        }
        private void Normal()
        {
            Console.WriteLine("Metodo Normal...");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //5º Testando a execução do evento
            var minhaClasseEvento = new TesteEvento();
            minhaClasseEvento.ChamarEvento();

            Console.ReadKey();
        }
    }
}
