using Exemplo13_Linq_Com_NotacaoSimilar_a_SQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exemplo13_Linq_Com_NotacaoSimilar_a_SQL
{
    class Program
    {
        static void Print<T>(string message, IEnumerable<T> collectionT)
        {
            Console.WriteLine(message);
            foreach (T obj in collectionT)
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            //Create three category
            Category c1 = new Category() { Id = 1, Name = "Tools", Tier = 2 };
            Category c2 = new Category() { Id = 2, Name = "Computers", Tier = 1 };
            Category c3 = new Category() { Id = 3, Name = "Eletromics", Tier = 1 };

            //List of product
            List<Product> products = new List<Product>()
            {
                new Product(){Id = 1, Name = "Computer", Price = 1100.00, Category = c2},
                new Product(){Id = 2, Name = "Hammer", Price = 90.0, Category = c1},
                new Product(){Id = 3, Name = "TV", Price = 1700.00, Category = c3},
                new Product(){Id = 4, Name = "Notebook", Price = 1300.00, Category = c2},
                new Product(){Id = 4, Name = "Saw", Price = 80.0, Category = c1},
                new Product(){Id = 6, Name = "Tablet", Price = 700.00, Category = c2},
                new Product(){Id = 7, Name = "Camera", Price = 700.00, Category = c3},
                new Product(){Id = 8, Name = "Printer", Price = 350.00, Category = c3},
                new Product(){Id = 9, Name = "MacBook", Price = 1800.00, Category = c2},
                new Product(){Id = 10, Name = "SoundBar", Price = 700.00, Category = c3},
                new Product(){Id = 11, Name = "Level", Price = 70.00, Category = c1},
            };

            /*
            var r1 = products.Where(p => p.Category.Tier == 1 && p.Price < 900.00);
            */
            var r1 =
            from p in products //1º Produto cartesiano
            where p.Category.Tier == 1 && p.Price < 900.00 //2º restrição
            select p;//3º projeção

            Print("02++++SQL++++Display TIER 1 AND PRICE < 900:", r1);

            //Filter Where with select 
            //var r2 = products.Where(p => p.Category.Name == "Tools").Select(p => p.Name);
            var r2 =
                from p in products
                where p.Category.Name == "Tools"
                select p.Name;

            Print("03++++SQL++++Display NAMES OF PRODUCTS FROM TOOLS:", r2);

            //Filtragem where e Objeto anonimo, ele tem um ToString Padrão {Atributo = Valor, }
            //var r3 = products.Where(p => p.Name[0] == 'C').Select(p => new { p.Name, p.Price, CategoryNameApelido = p.Category.Name });//Obj anonimo e um alias para categoria
            var r3 =
                from p in products
                where p.Name[0] == 'C'
                select new {
                    p.Name,
                    p.Price,
                    CategoryNameApelido = p.Category.Name //apelidadno para tirar ambiguidade 
                };
            Print("04++++SQL++++Display STARTED WITH 'C' AND ANONYMOUS OBJECT", r3);

            //Filtragem por Tier e depois ordenar por preco, caso preco igual ordene por nome 
            //var r4 = products.Where(p => p.Category.Tier == 1).OrderBy(p => p.Price).ThenBy(p => p.Name);
            var r4 =
                from p in products
                where p.Category.Tier == 1
                orderby p.Name  
                orderby p.Price
                select p;
            Print("05++++SQL++++Display TIER  1 ORDER BY PRICE  THEN BY NAME", r4);

            //Salta os 2 primeiros e Pega os proximos 4
            //var r5 = r4.Skip(2).Take(4);
            var r5 =
                (from p in r4
                 select p).Skip(2).Take(4);
            Print("06++++SQL++++Display TIER  1 ORDER BY PRICE  THEN BY NAME  SKIP 2 TAKE 4", r5);

            //Pegando o primeiro elemento dentro da coleção
            //var r6 = products.First();
            var r6 =//Cabe a voce avaliar qual é melhor de acordo com problema
                (from p in products
                 select p).First();
            Console.WriteLine("First Test 1: " + r6);



            //var r18 = products.GroupBy(p => p.Category);
            var r18 =
                from p in products
                group p by p.Category;

            foreach (IGrouping<Category, Product> groupItem in r18)
            {
                Console.WriteLine("07++++SQL++++Category: " + groupItem.Key.Name + ":");
                foreach (Product p in groupItem)
                {
                    Console.WriteLine(p);
                }
                Console.WriteLine();
            }
        }
    }
}
