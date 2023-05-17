using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double peso, altura, imc;

            // Pede e verifica o peso
            Console.Write("Digite o seu peso em kg: ");
            while (!double.TryParse(Console.ReadLine().Replace(".", ","), out peso))
            {
                Console.WriteLine("Por favor, digite um número válido.");
            }

            // Pede e verifica a altura
            Console.Write("Digite a sua altura em metros: ");
            while (!double.TryParse(Console.ReadLine().Replace(".", ","), out altura))
            {
                Console.WriteLine("Por favor, digite um número válido.");
            }

            // Calcula e mostra o IMC
            imc = peso / (altura * altura);
            Console.WriteLine($"\nSeu IMC é: {imc:F2}");

            // Exibe uma mensagem baseada no valor do IMC
            if (imc < 18.5)
            {
                Console.WriteLine("Você está abaixo do peso ideal.");
            }
            else if (imc < 25)
            {
                Console.WriteLine("Seu peso está dentro do normal.");
            }
            else if (imc < 30)
            {
                Console.WriteLine("Você está com sobrepeso.");
            }
            else if (imc < 35)
            {
                Console.WriteLine("Você está com obesidade grau I.");
            }
            else if (imc < 40)
            {
                Console.WriteLine("Você está com obesidade grau II.");
            }
            else
            {
                Console.WriteLine("Você está com obesidade grau III.");
            }

            Console.ReadLine();
        }
    }
}
