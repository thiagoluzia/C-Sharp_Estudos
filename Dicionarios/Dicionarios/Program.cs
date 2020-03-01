using System;
using System.Collections.Generic;
using System.Linq;

namespace Dicionarios
{
    class Program
    {//chave valor
        //1º Todo dicionario tem uma chave unica (abaixo uma chave do tipo string e o valor do tipo float)
        static Dictionary<string, float> alturas = new Dictionary<string, float>();
        static void Main(string[] args)
        {
            //Buscar dados em uma lista e array
            //Percorrer  a lista ou array
            //imagine 10000 de dados


            //Dicionario pode ser melhor, pense nisso
            //buscar dados em um dicionario
            //chave => dicionario
            //retorna o dado  buscado

            //2º Adicionar dados no dicionario
            alturas.Add("Thiago", 1.65f);
            alturas.Add("Tárcyla", 1.50f);
            alturas.Add("Alesandra", 1.60f);
            alturas.Add("Emanuel", 1.80f);

            //COMO EDITAR UM DADO EM UM DICIONARIO
            if (alturas.ContainsKey("Thiago"))
            {
                //Acessando pela chave e atribuindo um valor
                alturas["Thiago"] = 2.2f;
            }
            //REMOVER UM DADO DO DICIONARIO
            alturas.Remove("Thiago");

            //BUSCAR DADOS EM UM DICIONARIO
            //Checar se existe a chave no dicionario
            if (alturas.ContainsKey("Thiago"))
            {
                float valorDaAltura;
                //2º Procura um valor com a chave, e passa o valor como parametro para o out
                alturas.TryGetValue("Thiago", out valorDaAltura);
                Console.WriteLine("Altura " + valorDaAltura);
            }



            /* ESSE NÃO É BEM O INTUITO DE TRABALHAR COM DICIONARIO - O INTUITO É A BUSCA
            //3º Visualizando todos os dados de uma vez
            var lista = alturas.ToList();
            //4º Caso queira pegar as informações chave e valor
            for(int i = 0; i < lista.Count; i++)
            {
                Console.WriteLine(lista[i].ToString());
            }

            //5º So pegando os valores
            var lista2 = alturas.Values.ToList();
            for(int i = 0; i < lista2.Count; i++)
            {
                Console.WriteLine(lista2[i].ToString());
            }
            */



            Console.ReadKey();
        }
    }
}
