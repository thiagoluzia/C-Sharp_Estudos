using Exemplo10_Linq_Com_Lambda_Parte01.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exemplo10_Linq_Com_Lambda_Parte01
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

            //Initial linq - filter (where)
            var r1 = products.Where(p => p.Category.Tier == 1 && p.Price < 900.00);
            Print("Display TIER 1 AND PRICE < 900:", r1);

            //Filter Where with select 
            var r2 = products.Where(p => p.Category.Name == "Tools").Select(p => p.Name);
            Print("Display NAMES OF PRODUCTS FROM TOOLS:", r2);

            //Filtragem where e Objeto anonimo, ele tem um ToString Padrão {Atributo = Valor, }
            var r3 = products.Where(p => p.Name[0] == 'C').Select(p => new { p.Name, p.Price, CategoryNameApelido = p.Category.Name });//Obj anonimo e um alias para categoria
            Print("Display STARTED WITH 'C' AND ANONYMOUS OBJECT", r3);

            //Filtragem por Tier e depois ordenar por preco, caso preco igual ordene por nome 
            var r4 = products.Where(p => p.Category.Tier == 1).OrderBy(p => p.Price).ThenBy(p => p.Name);
            Print("Display TIER  1 ORDER BY PRICE  THEN BY NAME", r4);

            //Salta os 2 primeiros e Pega os proximos 4
            var r5 = r4.Skip(2).Take(4);
            Print("Display TIER  1 ORDER BY PRICE  THEN BY NAME  SKIP 2 TAKE 4", r5);

            //Pegando o primeiro elemento dentro da coleção
            var r6 = products.First();
            Console.WriteLine("First Test 1: " + r6);

            //Retornar tudo falso em uma consulta, e tenta exibir assim mesmo *ERRO*
            //var r7 = products.Where(p => p.Price > 3000.00).First();
            //Console.WriteLine("First test2:" + r7);

            //Tratando do problema anterior, caso nao tenha nenhum valor ele retorna nulo
            var r7 = products.Where(p => p.Price > 3000.00).FirstOrDefault();
            Console.WriteLine("FirstOrDefault test3: " + r7);

            //Retorna 1 elemento ou nenhum,  caso nao exista ira retorna nulo
            //var r8 = products.Where(p => p.Id == 3); r8 aqui é uma coleção
            var r8 = products.Where(p => p.Id == 3).SingleOrDefault();//r8 aqui é um elemento do tipo produto
            Console.WriteLine("Single or Default  test1: " + r8);

            var r9 = products.Where(p => p.Id > 30).SingleOrDefault();
            Console.WriteLine("Single or Default (Default Return null) test2: " + r9);



            //********OPERAÇÕES DE AGREGRAÇAO**************

            //Filtrar o Produto que tem o Max()"Maximo", Pode ter argumento "maior preço" ou não, 
            var r10 = products.Max(p => p.Price);
            Console.WriteLine("Max price " + r10);

            //Filtar o produto que tem o Min()
            var r11 = products.Min(p => p.Price);
            Console.WriteLine("Min price " + r11);

            //Filtrar os produtos da categorias 1, e depois somar todos eles e retornar o total
            var r12 = products.Where(p => p.Category.Id == 1).Sum(p => p.Price);
            Console.WriteLine("Category 1 Sum prices: " + r12);

            //Filtrando os produtos da cetegoria 1,  e depois calculando a media do preco 
            var r13 = products.Where(p => p.Category.Id == 1).Average(p => p.Price);
            Console.WriteLine("Category 1 Avarenge prices: " + r13);

            //Evitando erro, caso a coleção não tenha nenhum produto na categoria cadastrada, não tem como encontrar  a media
            var r14 = products.Where(p => p.Category.Id == 5).Select(p => p.Price).DefaultIfEmpty(0.0).Average();//filtro por categoria id, depois seleciono os encontrados pelo preco, seguindo da clausula que atribui 0.0 caso seja vazio
            Console.WriteLine("Category 5 avarenge prices: " + r14);

            //Trago a quantidade de produtos cadastrados na categoria 1
            var r15 = products.Where(p => p.Category.Id == 1).Count(p => p.Category.Id == 1);
            Console.WriteLine("Produtos cadastrados na categoria 1 " + r15);

            //Criando o meu proprio,  com aggregate
            var r16 = products.Where(p => p.Category.Id == 1).Select(p => p.Price).Aggregate((x, y) => x + y);
            Console.WriteLine("Category 1 aggregate sum " + r16);

            //Evitando erro, caso a coleção nao tenha nenhum produto encontrado
            var r17 = products.Where(p => p.Category.Id == 5).Select(p => p.Price).Aggregate(0.0, (x, y) => x + y);
            Console.WriteLine("Category 1 aggregate sum case 0: " + r17);
            Console.WriteLine();

            //Operações de agrupamento
            var r18 = products.GroupBy(p => p.Category);//r8 recebe o tipo IGrouping<Category, Product>
            foreach (IGrouping<Category, Product> groupItem in r18)//Agrupando os produtos por categoria
            {
                Console.WriteLine("Category: " + groupItem.Key.Name + ":");//Key edo tipo da categoria
                foreach(Product p in groupItem)//Imprimindo os produtos agrupados
                {
                    Console.WriteLine(p);
                }
                Console.WriteLine();
            }



        }
    }
}
