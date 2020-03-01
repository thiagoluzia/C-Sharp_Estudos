using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace LeituraDeArquivos_JSON
{
    class Program
    {
        //2ºCriando a classe com a mesma assinatura do arquivo json
        class User
        {
            public string name;
            public int age;
            public string email;
        }


        static void Main(string[] args)
        {
            //1º Lendo o json 
            string caminho = "./user.json";
            var json = File.ReadAllText(caminho);

            //3º tratando o arquivo json como um objeto no c# 
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();

            //4ºConvertendo o json par aum objeto, com isso as atribuições serão feita 
            User usuario = jsonSerializer.Deserialize<User>(json);

            //5º Checando o resultado
            Console.WriteLine(usuario.name + "\n" + usuario.age.ToString() + "\n" + usuario.email);

            Console.ReadKey();
        }
    }
}
