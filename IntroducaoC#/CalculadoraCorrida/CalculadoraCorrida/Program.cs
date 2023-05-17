using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraCorrida
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Informe o número de voltas:");
            int numVoltas = int.Parse(Console.ReadLine());

            double melhorTempo = double.MaxValue;
            int voltaMelhorTempo = 0;
            double somaTempos = 0;

            for (int i = 1; i <= numVoltas; i++)
            {
                Console.WriteLine($"Informe o tempo da volta {i}:");
                double tempoVolta = double.Parse(Console.ReadLine());

                somaTempos += tempoVolta;

                if (tempoVolta < melhorTempo)
                {
                    melhorTempo = tempoVolta;
                    voltaMelhorTempo = i;
                }
            }

            double tempoMedio = somaTempos / numVoltas;

            Console.WriteLine($"Melhor tempo: {melhorTempo}");
            Console.WriteLine($"Volta do melhor tempo: {voltaMelhorTempo}");
            Console.WriteLine($"Tempo médio das voltas: {tempoMedio}");
            Console.Read();
        }
    }
}
