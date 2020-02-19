using Exemplo06_Predicate_RemoveALL.Entities;
using System;
using System.Collections.Generic;

/// <summary>
/// Predicate é um delegate 
/// Predicate pode ser qualquer função que eu referencie em um metodo
/// Desde que ela receba um objeto e devolve um boleano
/// Seja ela normal ou lambda
/// </summary>
namespace Exemplo06_Predicate_RemoveALL
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Produto> list = new List<Produto>();
            list.Add(new Produto("TV", 900.00));
            list.Add(new Produto("Mouse", 50.00));
            list.Add(new Produto("Tablet", 350.50));
            list.Add(new Produto("HD Case", 80.90));


            #region 1º Solução utilizando expressao lambda - REMOVE ALL
            //Pra entender melhor vamos fazer uma expressao lambda antes de aplicar o predicate
            //Ela temabem funciona. ONDE p representa o produto
            list.RemoveAll(p => p.Preco >= 100.00);
            //PErcorrendo a lista para testar se os produtos foram removidos 
            foreach (Produto p in list)
            {
                Console.WriteLine(p);
            }
            #endregion

            #region 2º Solução utilizando uma função como parametro - PREDICATE
            list.RemoveAll(ProdutoTeste);
            foreach (Produto p in list)
            {
                Console.WriteLine(p);
            }
            #endregion 

            #region 3º Solução - Testes pessoais
            //EXEMPLO 3 SEM O USO DE LISTAS
            Pessoa pessoa = new Pessoa("Tarcyla", 11);

            Predicate<Pessoa> predicate = MaiorIdade;
            Console.WriteLine(predicate(pessoa));
            #endregion

            Console.ReadKey();
        }

        //2º Solução - Função para ser passado como parametro no list.RemoveAll(PirodutoTeste);
        public static bool ProdutoTeste(Produto p)
        {
            return p.Preco >= 100.00;//Com isso ele retorna os itens que obdecem a condição
        }

        //3º FUNÇAO PARA O EXEMPLO 3
        public static bool MaiorIdade(Pessoa p)
        {
            return p.Idade >= 18;
        }
    }
}
