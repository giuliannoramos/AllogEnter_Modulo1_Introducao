using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumoCombustivel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double kmPorLitro = 12;
            double horas;
            double minutos;
            double velocidadeMedia;

            Console.Write("Digite o tempo gasto na viagem (em horas): ");
            while (!double.TryParse(Console.ReadLine().Replace(".", ","), out horas))
            {
                Console.WriteLine("Por favor, digite um número válido.");
            }

            Console.Write("Digite o tempo gasto na viagem (em minutos): ");
            while (!double.TryParse(Console.ReadLine().Replace(".", ","), out minutos))
            {
                Console.WriteLine("Por favor, digite um número válido.");
            }

            double tempo = horas + (minutos / 60.0);

            Console.Write("Digite a velocidade média durante a viagem (em km/h): ");
            while (!double.TryParse(Console.ReadLine().Replace(".", ","), out velocidadeMedia))
            {
                Console.WriteLine("Por favor, digite um número válido.");
            }

            double distancia = tempo * velocidadeMedia;

            double litrosUsados = distancia / kmPorLitro;

            Console.WriteLine($"\nVelocidade média: {velocidadeMedia:F2} km/h");
            Console.WriteLine($"Tempo gasto: {horas} horas e {minutos} minutos");
            Console.WriteLine($"Distância percorrida: {distancia:F2} km");
            Console.WriteLine($"Litros de combustível utilizados: {litrosUsados:F2}");

            Console.Write("\nDeseja saber o valor em reais gasto em combustível? (Digite 's' caso queira ou qualquer outra tecla caso não): ");
            string resposta = Console.ReadLine();

            if (resposta.ToLower() == "s")
            {
                double valorLitro;
                Console.Write("Digite o valor pago por litro de combustível: R$ ");
                while (!double.TryParse(Console.ReadLine().Replace(".", ","), out valorLitro))
                {
                    Console.WriteLine("Por favor, digite um número válido.");
                }

                double valorTotal = litrosUsados * valorLitro;
                Console.WriteLine($"\nO valor total gasto em combustível na viagem foi: {valorTotal:R$#,##0.00}");
            }
            else
            {
                Console.WriteLine("Programa encerrado.");
            }

            Console.Read();
        }
    }
}
