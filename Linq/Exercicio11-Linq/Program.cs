using Exercicio11_Linq.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Exercicio11_Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            //Caminho do xml
            Console.Write("Digite o caminho do arquivo: ");
            string path = Console.ReadLine();

            //Lista de produtos
            List<Product> list = new List<Product>();

            //Passando o caminho do arquivo para trabalhar com seus dadosno bloco
            using (StreamReader sr = File.OpenText(path))
            {
                //Enquanto tiver linha no xml, será executado
                while (!sr.EndOfStream)
                {
                    //Lendo, pegando, e passsando os valores do xml para variaveis
                    string[] fields = sr.ReadLine().Split(',');
                    string name = fields[0];
                    double price = double.Parse(fields[1], CultureInfo.InvariantCulture);

                    //Inserir um novo produto com os dados instanciados nas variaveis locais 
                    list.Add(new Product(name, price));
                }
            }

            //Encontrando o preço media de preço dos produtos com LINQ
            var media = list.Select(p => p.Price).DefaultIfEmpty(0.0).Average();//.DefaultIfEmpty(0.0) caso a media seja menor que zero, nao retorne um erro
            Console.WriteLine($"Media de preço de todos os produtos: {media.ToString("F2", CultureInfo.InvariantCulture)}");

            //Ordenando em ordem decrescente alfabetica os produtos com precos abaixo da media com LINQ
            var names = list.Where(p => p.Price < media).OrderByDescending(p => p.Name).Select(p => p.Name);

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }

        }
    }
}
