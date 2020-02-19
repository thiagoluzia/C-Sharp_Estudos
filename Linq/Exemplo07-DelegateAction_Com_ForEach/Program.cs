using Exemplo07_DelegateAction_Com_ForEach.Entities;
using System;
using System.Collections.Generic;

namespace Exemplo07_DelegateAction_Com_ForEach
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Produto> list = new List<Produto>();
            list.Add(new Produto("TV", 900.00));
            list.Add(new Produto("Mouse", 50.00));
            list.Add(new Produto("Tablet", 350.50));
            list.Add(new Produto("HD", 80.90));

            #region 1º Action Tradicional
            //Utilizando o delegate tradicional
            Action<Produto> action = AumentoDePreco;
            //Utilizando o metodo foreach da lista e passando a action
            list.ForEach(action);
            foreach (Produto p in list)
            {
                Console.WriteLine(p);
            }
            #endregion

            #region 2º Action Com o uso de expressoes lambdas
            //Recebendo uma expressao lambada com action
            Action<Produto> action2 = p => { p.Preco += p.Preco * 0.10; };
            foreach (Produto p in list)
            {
                Console.WriteLine(p);
            }
            #endregion

            #region  3º Passando a Action com função direta
            ////Simplesmente passando uma action dentro do metodo da lista que efetua uma varredura
            //list.ForEach(AumentoDePreco);
            //foreach (Produto p in list)
            //{
            //    Console.WriteLine(p);
            //}
            #endregion

            Console.ReadKey();
           
        }

        //Função pra aumentar o preco 
        public static void AumentoDePreco(Produto p)
        {
            p.Preco += p.Preco * 0.10;
        }
    }
}
