using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcularArmazenarIMC
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Calculadora de IMC");

            while (true)
            {
                Console.WriteLine("\nSelecione uma opção:");
                Console.WriteLine("1 - Novo cadastro");
                Console.WriteLine("2 - Consultar cadastros");
                Console.WriteLine("0 - Sair");

                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        CadastrarUsuario();
                        break;
                    case 2:
                        ConsultarCadastros();
                        break;
                    case 0:
                        Console.WriteLine("\nPrograma encerrado");
                        return;
                    default:
                        Console.WriteLine("\nOpção inválida. Tente novamente.");
                        break;
                }                
            }            
        }

        static void CadastrarUsuario()
        {
            Console.WriteLine("\nDigite o nome do usuário:");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite a idade do usuário:");
            int idade = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o peso do usuário em kg:");
            double peso = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite a altura do usuário em metros:");
            double altura = double.Parse(Console.ReadLine());

            double imc = CalcularIMC(peso, altura);

            string arquivo = "usuarios.txt";

            using (StreamWriter sw = File.AppendText(arquivo))
            {
                sw.WriteLine("Nome: " + nome);
                sw.WriteLine("Idade: " + idade);
                sw.WriteLine("Peso: " + peso);
                sw.WriteLine("Altura: " + altura);
                sw.WriteLine("IMC: " + imc.ToString("0.00"));
                sw.WriteLine();
            }

            Console.WriteLine("\nCadastro realizado com sucesso!");
        }

        static void ConsultarCadastros()
        {
            string arquivo = "usuarios.txt";

            if (!File.Exists(arquivo))
            {
                Console.WriteLine("\nNão há cadastros disponíveis.");
                return;
            }

            Console.WriteLine("\nCadastros existentes:");

            using (StreamReader sr = File.OpenText(arquivo))
            {
                string linha;
                while ((linha = sr.ReadLine()) != null)
                {
                    Console.WriteLine(linha);
                }
            }
        }

        static double CalcularIMC(double peso, double altura)
        {
            return peso / (altura * altura);
        }
    }
}
