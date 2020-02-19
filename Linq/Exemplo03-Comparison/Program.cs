using Exemplo03_Comparison.Entities;
using System;
using System.Collections.Generic;

namespace Exemplo03_Comparison
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Produto> list = new List<Produto>();
            list.Add(new Produto("TV", 900.00));
            list.Add(new Produto("Notebook", 1200.00));
            list.Add(new Produto("Tablet", 350.00));


            //Comparando uma expresao lambada"Expressao anonima"
            //Comparison<Produto> compararProduto = (p1, p2) => p1.Nome.ToUpper().CompareTo(p2.Nome.ToUpper());
            //list.Sort(compararProduto);

            //OU
            //Resulta no mesmo que a linha acima, passando a expressao diretamente como argumento
            list.Sort((p1, p2) => p1.Nome.ToUpper().CompareTo(p2.Nome.ToUpper()));

            foreach(Produto produto in list)
            {
                Console.WriteLine(produto.ToString());
            }

            //Console.ReadKey();
        }
    }
}
