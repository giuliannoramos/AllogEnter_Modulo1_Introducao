using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManipulacaoDeVetores
{
    internal class Program
    {
        static int[] vetor;

        static void Main()
        {
            int opcao;

            do
            {
                ExibirMenu();
                opcao = LerOpcao();

                switch (opcao)
                {
                    case 1:
                        CarregarVetor();
                        break;
                    case 2:
                        ListarVetor();
                        break;
                    case 3:
                        ExibirPares();
                        break;
                    case 4:
                        ExibirImpares();
                        break;
                    case 5:
                        ContarParesPosicoesImpares();
                        break;
                    case 6:
                        ContarImparesPosicoesPares();
                        break;
                    case 7:
                        Console.WriteLine("\nPrograma encerrado");
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida. Digite um número válido.");
                        break;
                }

                Console.WriteLine();
            }
            while (opcao != 7);
        }

        static void ExibirMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n----- MENU -----");
            Console.ResetColor();            
            Console.WriteLine("1 - Carregar Vetor");
            Console.WriteLine("2 - Listar Vetor");
            Console.WriteLine("3 - Exibir apenas os números pares do vetor");
            Console.WriteLine("4 - Exibir apenas os números ímpares do vetor");
            Console.WriteLine("5 - Exibir a quantidade de números pares existentes nas posições ímpares do vetor");
            Console.WriteLine("6 - Exibir a quantidade de números ímpares existentes nas posições pares do vetor");
            Console.WriteLine("7 - Sair");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("----------------");
            Console.ResetColor();
        }

        static int LerOpcao()
        {
            Console.Write("\nDigite a opção desejada: ");
            int opcao;

            while (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 1 || opcao > 7)
            {
                Console.Write("\nOpção inválida. Digite um número válido: ");
            }

            return opcao;
        }

        static void CarregarVetor()
        {
            Console.Write("\nDigite a quantidade de elementos do vetor (até 50): ");
            int quantidade = LerQuantidade();

            vetor = new int[quantidade];

            for (int i = 0; i < quantidade; i++)
            {
                Console.Write($"\nDigite o valor do elemento {i + 1}: ");
                vetor[i] = LerValor();
            }

            Console.WriteLine("\nVetor carregado com sucesso!");
        }

        static int LerQuantidade()
        {
            int quantidade;

            while (!int.TryParse(Console.ReadLine(), out quantidade) || quantidade < 1 || quantidade > 50)
            {
                Console.Write("\nQuantidade inválida. Digite um número inteiro positivo até 50: ");
            }

            return quantidade;
        }

        static int LerValor()
        {
            int valor;

            while (!int.TryParse(Console.ReadLine(), out valor))
            {
                Console.Write("\nValor inválido. Digite um número inteiro: ");
            }

            return valor;
        }

        static void ListarVetor()
        {
            if (vetor == null)
            {
                Console.WriteLine("\nVetor não carregado.");
            }
            else
            {
                Console.WriteLine("\nVetor:");
                foreach (int elemento in vetor)
                {
                    Console.Write($"{elemento} ");
                }
                Console.WriteLine();
            }
        }

        static void ExibirPares()
        {
            if (vetor == null)
            {
                Console.WriteLine("\nVetor não carregado.");
            }
            else
            {
                Console.WriteLine("\nNúmeros pares do vetor:");
                foreach (int elemento in vetor)
                {
                    if (elemento % 2 == 0)
                    {
                        Console.Write($"{elemento} ");
                    }
                }
                Console.WriteLine();
            }
        }

        static void ExibirImpares()
        {
            if (vetor == null)
            {
                Console.WriteLine("\nVetor não carregado.");
            }
            else
            {
                Console.WriteLine("\nNúmeros ímpares do vetor:");
                foreach (int elemento in vetor)
                {
                    if (elemento % 2 != 0)
                    {
                        Console.Write($"{elemento} ");
                    }
                }
                Console.WriteLine();
            }
        }

        static void ContarParesPosicoesImpares()
        {
            if (vetor == null)
            {
                Console.WriteLine("\nVetor não carregado.");
            }
            else
            {
                int count = 0;

                for (int i = 1; i < vetor.Length; i += 2)
                {
                    if (vetor[i] % 2 == 0)
                    {
                        count++;
                    }
                }

                Console.WriteLine($"\nQuantidade de números pares nas posições ímpares do vetor: {count}");
            }
        }

        static void ContarImparesPosicoesPares()
        {
            if (vetor == null)
            {
                Console.WriteLine("\nVetor não carregado.");
            }
            else
            {
                int count = 0;

                for (int i = 0; i < vetor.Length; i += 2)
                {
                    if (vetor[i] % 2 != 0)
                    {
                        count++;
                    }
                }

                Console.WriteLine($"\nQuantidade de números ímpares nas posições pares do vetor: {count}");
            }
        }
    }
}
