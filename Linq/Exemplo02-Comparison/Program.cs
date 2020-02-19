using Exemplo02_Comparison.Entities;
using System;
using System.Collections.Generic;

namespace Exemplo02_Comparison
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Produto> list = new List<Produto>();
            list.Add(new Produto("TV", 900.00));
            list.Add(new Produto("Notebook", 1200.00));
            list.Add(new Produto("Tablet", 350.00));

            //passando referencia como argumento para a funcao "DELEGATE"
            list.Sort(CompararProduto);

            //O MESMO RESULTADO  DA LINHA ACIMA
            //Comparison<Produto> comp = CompararProdutos;
            //list.Sort(comp);

            foreach (Produto produto in list)
            {
                Console.WriteLine(produto.ToString());
            }
        }

        //Implementação manual para comparação entre os objetos
        //Criando um metodo auxiliar que compara dois produtos.
        //CompareTo(em strings pois ela tem a implementação do IComparable)
        static int CompararProduto(Produto p1, Produto p2)
        {
            return p1.Nome.ToUpper().CompareTo(p2.Nome.ToUpper());
        }
    }
    
}
