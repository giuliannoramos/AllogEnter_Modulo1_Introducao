using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImprimirVogais
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite uma frase: ");
            string frase = Console.ReadLine();

            // Array de vogais, incluindo as vogais com acentos
            char[] vogais = { 'a', 'e', 'i', 'o', 'u', 'á', 'é', 'í', 'ó', 'ú', 'â', 'ê', 'î', 'ô', 'û', 'à', 'è', 'ì', 'ò', 'ù', 'ä', 'ë', 'ï', 'ö', 'ü', 'ã', 'õ' };

            int totalVogais = 0;
            string vogaisEncontradas = "";

            //// Usando LINQ para filtrar os caracteres da frase que estão no array de vogais
            //var vogaisEncontradas = frase.ToLower().Where(c => vogais.Contains(c)).ToArray();
            //Console.WriteLine($"\nAs vogais na frase são: {new string(vogaisEncontradas)}");
            //Console.WriteLine($"Total de vogais: {vogaisEncontradas.Length}");

            for (int i = 0; i < frase.Length; i++)
            {
                char letra = frase[i];

                if (Array.IndexOf(vogais, Char.ToLower(letra)) >= 0)
                {
                    vogaisEncontradas += letra;
                    totalVogais++;
                }
            }

            Console.WriteLine($"\nAs vogais na frase são: {vogaisEncontradas}");
            Console.WriteLine($"Total de vogais: {totalVogais}");

            Console.Read();
        }
    }
}
