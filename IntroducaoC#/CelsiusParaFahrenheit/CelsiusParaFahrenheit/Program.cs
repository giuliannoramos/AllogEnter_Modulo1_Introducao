using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelsiusParaFahrenheit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double celsius;

            Console.Write("Digite a temperatura em graus Celsius: ");

            while (!double.TryParse(Console.ReadLine().Replace(".", ","), out celsius))
            {
                Console.WriteLine("Por favor, digite um número válido.");
            }

            double fahrenheit = (9 * celsius + 160) / 5;
            Console.WriteLine($"\nA temperatura de {celsius} °C é equivalente a: {fahrenheit} °F");
            Console.Read();

        }
    }
}
