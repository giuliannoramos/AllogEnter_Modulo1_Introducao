using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubstituicaoCaracteres
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite uma frase: ");
            string frase = Console.ReadLine();

            char[] caracteres = frase.ToLower().ToCharArray();

            for (int i = 0; i < caracteres.Length; i++)
            {
                if (caracteres[i] == 'a' || caracteres[i] == 'á' || caracteres[i] == 'ã' || caracteres[i] == 'à' || caracteres[i] == 'â')
                {
                    caracteres[i] = '&';
                }
            }

            string novaFrase = new string(caracteres);
            Console.WriteLine($"\nNova frase: {novaFrase}");
            Console.Read();
        }
    }
}
