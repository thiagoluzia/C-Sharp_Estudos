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
        }
    }
}
