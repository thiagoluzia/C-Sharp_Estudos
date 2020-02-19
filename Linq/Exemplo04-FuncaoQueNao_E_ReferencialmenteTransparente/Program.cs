using System;

namespace Exemplo04_FuncaoQueNao_E_ReferencialmenteTransparente
{
    class Program
    {
        public static int valorGlobal = 3;
        static void Main(string[] args)
        {
            //Cria e instancia um vetor com valores
            int[] vet = new int[] {3,4,5};
            //funcao que vai alterar apenas os valores impares do vetor
            AlterarValorImpar(vet);
            //o join vai pegar cada elemento do vetor e juntar em uma string separando por espaços
            Console.WriteLine(string.Join(" ", vet));
        }

        //funcao que vai alterar o vetor. Ela recebe um vetor, percorre ele e onde for impar ela vai somar o valor do vetor com uma variavel global que vale 3
        public static void AlterarValorImpar(int[] numeros){
            for(int i = 0; i < numeros.Length; i++){
                if(numeros[i] % 2 != 0){
                    numeros[i] += valorGlobal;
                }
            }
        }
    }
}
