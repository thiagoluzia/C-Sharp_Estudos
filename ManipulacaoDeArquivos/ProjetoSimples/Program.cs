using System;
using System.IO;//1º Importar  namespace para trabalhar com arquivos
using System.Runtime.Serialization.Formatters.Binary;

namespace ProjetoSimples
{
    class Program
    {
        #region Claases criadas para testes de Escrita de um arquivo binário
        [Serializable]
        class Pessoa
        {
            public int idade;
            public string nome;

            public override string ToString()
            {
                return idade.ToString() + " " + nome;
            }
        }
        [Serializable]
        class Carro
        {
            public string modelo;
            public string marca;

            public override string ToString()
            {
                return modelo +" e, "+marca; 
            }
        }
        #endregion
        static void Main(string[] args)
        {
            //-----------------------------------
            //  Criação de um arquivo!
            //-----------------------------------

            
            //2º Criar uma string com o caminho para o arquivo, contendo seu nome e sua extensão
            string caminho = "./nomeDoArquivo.son";
            /*
            //3º Verificar se o arquivo já existe no caminho passado, caso não exista o metodo create irá cria-lo
            if (!File.Exists(caminho))
            {
                File.Create(caminho);
            }
            */

            //-----------------------------------
            //  Escrever dados em um arquivo!
            //-----------------------------------

            /*
            //1º Criar um canal de escrita
            StreamWriter escritor = new StreamWriter(caminho, append: true);//4º passo ou poderia ter sido o 1º é inserir append: true apos o caminho, pois a cada chamada do metodo ele iria apagar o arquivo e reescrever,com o append ele sempre vai adicionar uma nova linha ao final do arquivo
            //2º Chamar o metodo de escrita
            escritor.Write("Thiago Moura - sem quebra de linha");
            escritor.WriteLine("Thiago Henrique Moura Luzia - com quebra de linha 1");
            escritor.WriteLine("com quebra de linha 2");
            escritor.WriteLine("com quebra de linha 3");
            //3ºFechando o canal de escrita
            escritor.Close(); 
            */

            //-----------------------------------
            //  Ler dados de um arquivo de texto!
            //-----------------------------------
            /*
            //1º Criar um canal de leitura com o arquivo
            StreamReader leitor = new StreamReader(caminho);
            //2º Criar uma variavel para armazenar o dado lido por metodo de leitura ReadToEnd, vai ler completamente todo conteudo do arquivo" 
            string foiescrito2 = leitor.ReadToEnd();
            //3º Fechando o canal de leitura
            leitor.Close();
            Console.WriteLine(foiescrito2);
            */


            //---------------------------------------------------
            //  Ler dados de um arquivo de texto - Linha a Linha!
            //---------------------------------------------------
            /*
            //1º Criar um canal de Leitura
            StreamReader leitor = new StreamReader(caminho);
            //2º Criar um laço para varrer o leitor (Enquanto leitor não chegar ao final do arquivo)
            while (!leitor.EndOfStream)
            {
                //Processo ReadLine
                //1 - Ler a linha
                //2 - Retornar os dados da linha
                //3 - Passa para a proxima linha
                Console.WriteLine(leitor.ReadLine());
            }
            //3ºFechar o canal de comunicação 
            leitor.Close();
            */

            //-----------------------------------
            //  Escrita de um arquivo binário
            //-----------------------------------

            //0º Criando um novo caminho 
            string caminhoBinario = "./dado.som";

            //1º Criando um canal de escrita binaria (o FileStream pode ler e escrever um arquivo binario )
            FileStream canalDeEscrita = new FileStream(caminhoBinario, FileMode.OpenOrCreate);
            //Entenda o FileMode.OpenOrCreate
            //1 - ele tenta abri o arquivo
            //2 - se o arquivo existi ele abre
            //3 - senao ele cria e abre

            //3º Criando um serializado
            BinaryFormatter serializador = new BinaryFormatter();
            //4º Criando objetos para trabalhar com serializador
            Pessoa pessoa1 = new Pessoa { nome = "Thiago", idade = 30 };
            Carro carro1 = new Carro { marca = "Jeep", modelo = "Renegade" };
            //5ºSalvando em arquivo binario
            serializador.Serialize(canalDeEscrita, pessoa1);
            serializador.Serialize(canalDeEscrita, carro1);
            //6ºFechar o canal de escrita
            canalDeEscrita.Close();

            //7º para que tudo ocorra bem devemos marcar nossas classe com "DataAnotation" [Serializable] pois somente assim elas seram serializadas, por padrão todas as classes padrão do c# ja são serializadas

            Console.ReadKey();


        }
    }
}
