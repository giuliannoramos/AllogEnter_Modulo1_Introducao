using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenciaInversa
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Digite uma sequência de números separados por espaço:");

            string input = Console.ReadLine();
            string[] numerosString = input.Split(' ');

            Array.Reverse(numerosString);

            Console.WriteLine("Sequência invertida:");

            foreach (string numeroString in numerosString)
            {
                Console.WriteLine(numeroString);
            }
            
            Console.Read();
        }
    }
}
