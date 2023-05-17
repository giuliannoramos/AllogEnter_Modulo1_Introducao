using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcularMediaMaior
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Digite a quantidade de números a serem armazenados:");
            int quantidade = LerQuantidade();

            int[] numeros = new int[quantidade];
            LerNumeros(numeros);

            double media = CalcularMedia(numeros);
            int maiorNumero = ObterMaiorNumero(numeros);

            Console.WriteLine($"Média: {media}");
            Console.WriteLine($"Maior número: {maiorNumero}");
            Console.Read();
        }

        static int LerQuantidade()
        {
            int quantidade;

            while (!int.TryParse(Console.ReadLine(), out quantidade) || quantidade <= 0)
            {
                Console.WriteLine("Entrada inválida. Digite um valor inteiro positivo:");
            }

            return quantidade;
        }

        static void LerNumeros(int[] numeros)
        {
            for (int i = 0; i < numeros.Length; i++)
            {
                Console.WriteLine($"Digite o número {i + 1}:");
                while (!int.TryParse(Console.ReadLine(), out numeros[i]) || numeros[i] <= 0)
                {
                    Console.WriteLine("Entrada inválida. Digite um valor inteiro positivo:");
                }
            }
        }

        static double CalcularMedia(int[] numeros)
        {
            int soma = 0;
            foreach (int numero in numeros)
            {
                soma += numero;
            }

            return (double)soma / numeros.Length;
        }

        static int ObterMaiorNumero(int[] numeros)
        {
            int maior = numeros[0];
            foreach (int numero in numeros)
            {
                if (numero > maior)
                {
                    maior = numero;
                }
            }

            return maior;
        }
    }
}
