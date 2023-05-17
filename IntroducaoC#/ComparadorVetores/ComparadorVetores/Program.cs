using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparadorVetores
{
    internal class Program
    {
        static void Main()
        {
            int[] V1 = LerVetor("Digite os elementos do primeiro vetor (V1):");
            int[] V2 = LerVetor("Digite os elementos do segundo vetor (V2):");

            int tamanho = Math.Min(V1.Length, V2.Length);
            int quantidade = CompararVetores(V1, V2, tamanho);

            Console.WriteLine($"Quantidade de valores idênticos nas mesmas posições: {quantidade}");
            Console.Read();
        }

        static int[] LerVetor(string mensagem)
        {
            Console.WriteLine(mensagem);
            string input = Console.ReadLine();
            string[] elementos = input.Split(' ');

            int[] vetor = new int[elementos.Length];

            for (int i = 0; i < elementos.Length; i++)
            {
                int elemento;
                if (int.TryParse(elementos[i], out elemento))
                {
                    vetor[i] = elemento;
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Digite apenas valores inteiros separados por espaço.");
                    return LerVetor(mensagem);
                }
            }

            if (vetor.Length > 50)
            {
                Console.WriteLine("A quantidade de elementos do vetor não pode ser superior a 50.");
                return LerVetor(mensagem);
            }

            return vetor;
        }

        static int CompararVetores(int[] V1, int[] V2, int tamanho)
        {
            int quantidade = 0;

            for (int i = 0; i < tamanho; i++)
            {
                if (V1[i] == V2[i])
                {
                    quantidade++;
                }
            }

            return quantidade;
        }
    }
}
