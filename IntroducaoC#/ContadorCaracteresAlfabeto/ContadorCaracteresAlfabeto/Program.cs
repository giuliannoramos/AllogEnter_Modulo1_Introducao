using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContadorCaracteresAlfabeto
{
    internal class Program
    {
        static void Main()
        {
            bool valido = false;
            char char1 = '\0';
            char char2 = '\0';

            while (!valido)
            {
                Console.WriteLine("Digite dois caracteres de A a Z (em ordem alfabética):");
                string input = Console.ReadLine();

                if (input.Length == 2)
                {
                    char1 = char.ToUpper(input[0]);
                    char2 = char.ToUpper(input[1]);

                    if (char1 >= 'A' && char1 <= 'Z' && char2 >= 'A' && char2 <= 'Z' && char1 < char2)
                    {
                        valido = true;
                    }
                }

                if (!valido)
                {
                    Console.WriteLine("Erro: Os caracteres não estão em ordem alfabética ou não são válidos.");
                }
            }

            int numCaracteres = char2 - char1 - 1;

            Console.WriteLine($"O número de caracteres entre '{char1}' e '{char2}' é: {numCaracteres}");
            Console.Read();
        }
    }
}
