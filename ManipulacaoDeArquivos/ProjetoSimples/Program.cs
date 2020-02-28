using System;
using System.IO;//1º Importar  namespace para trabalhar com arquivos

namespace ProjetoSimples
{
    class Program
    {
        static void Main(string[] args)
        {
            //-----------------------------------
            //  Criação de um arquivo!
            //-----------------------------------

            //2º Criar uma string com o caminho para o arquivo, contendo seu nome e sua extensão
            string caminho = "./nomeDoArquivo.son";

            //3º Verificar se o arquivo já existe no caminho passado, caso não exista o metodo create irá cria-lo
            if (!File.Exists(caminho))
            {
                File.Create(caminho);
            }

            //-----------------------------------
            //  Escrever dados em um arquivo!
            //-----------------------------------

            //1º Criar um canal de escrita
            StreamWriter escritor = new StreamWriter(caminho, append: true);//4º passo ou poderia ter sido o 1º é inserir append: true apos o caminho, pois a cada chamada do metodo ele iria apagar o arquivo e reescrever,com o append ele sempre vai adicionar uma nova linha ao final do arquivo
            //2ºChamar o metodo de escrita
            escritor.Write("Thiago Moura - sem quebra de linha");
            escritor.WriteLine("Thiago Henrique Moura Luzia - com quebra de linha 1");
            escritor.WriteLine("com quebra de linha 2");
            escritor.WriteLine("com quebra de linha 3");
            //3ºFechando o canal de escrita
            escritor.Close(); 

        }
    }
}
