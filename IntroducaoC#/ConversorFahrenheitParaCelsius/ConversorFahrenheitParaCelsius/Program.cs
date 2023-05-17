using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversorFahrenheitParaCelsius
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double fahrenheit;

            Console.Write("Digite a temperatura em graus Fahrenheit: ");

            while (!double.TryParse(Console.ReadLine().Replace(".", ","), out fahrenheit))
            {
                Console.WriteLine("Por favor, digite um número válido.");
            }

            double celsius = (fahrenheit - 32) * 5 / 9;
            Console.WriteLine($"\nA temperatura de {fahrenheit} °F é equivalente a: {celsius:F2} °C");
            Console.Read();

        }
    }
}
