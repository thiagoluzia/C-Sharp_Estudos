using Exemplo01_IComparable.Entities;
using System;
using System.Collections.Generic;

namespace Exemplo01_IComparable
{
    /// <summary>
    /// Foi criado um programa para adiciona alguns produtos por meio de uma lista 
    /// depois ordenando os por meio de nomes, seguida da impressao na tela
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            List<Produto> list = new List<Produto>();
            list.Add(new Produto("TV", 900.00));
            list.Add(new Produto("Notebook", 1200.00));
            list.Add(new Produto("Tablet", 450.00));

            //list.Sort();

            //passando referencia como argumento para a funcao "DELEGATE"
            list.Sort(CompararProdutos);

            //O MESMO RESULTADO  DA LINHA ACIMA
            //Comparison<Produto> comp = CompararProdutos;
            //list.Sort(comp);

            foreach (var produto in list)
            {
                Console.WriteLine(produto.ToString());
            }

            Console.ReadKey();
        }

        //Criando um metodo auxiliar que compara dois produtos.
        //CompareTo(em strings pois ela tem a implementação do IComparable)
        static int CompararProdutos(Produto p1, Produto p2)
        {
            return p1.Nome.ToUpper().CompareTo(p2.Nome.ToUpper());//
        }
    }
}
