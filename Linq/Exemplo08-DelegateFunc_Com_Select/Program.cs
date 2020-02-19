using Exemplo08_DelegateFunc_Com_Select.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exemplo08_DelegateFunc_Com_Select
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

            #region 1º Exemplo de forma tradicional com o uso do delegate - FUNC
            //FUNC Recebe <um tipo e o, tipo do retorno> Função
            Func<Produto, string> func = NomesMaiusculos;
            //A nova lista para fazer o que é pediddo "criar uma nova lista"
            List<string> resultado1 = list.Select(func).ToList();
            foreach (string s in resultado1)
            {
                Console.WriteLine(s);
            }
            #endregion

            #region 2º Com expressão lambada
            Func<Produto, string> func2 = p => p.Nome.ToUpper();
            List<string> resultado3 = list.Select(func2).ToList();
            foreach(string s in resultado3)
            {
                Console.WriteLine(s);
            }
            #endregion

            #region 3º Com expressão lambda inline como 
            List<string> resultado4 = list.Select(p => p.Nome.ToUpper()).ToList();
            foreach (string s in resultado4)
            {
                Console.WriteLine(s);
            }
            #endregion

            #region 4º Maneira
            List<string> resultado2 = list.Select(NomesMaiusculos).ToList();
            foreach (string s in resultado2)
            {
                Console.WriteLine(s);
            }
            #endregion

            Console.ReadKey();
        }

        //Função que retorna os nomes em maiusculo
        public static string NomesMaiusculos(Produto p)
        {
            return p.Nome.ToUpper();
        }
    }
}
