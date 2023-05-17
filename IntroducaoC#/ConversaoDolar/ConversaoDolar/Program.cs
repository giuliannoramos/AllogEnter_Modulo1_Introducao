using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversaoDolar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double cotacaoDolar = 5;
            double valor;
            double conversaoReal;

            Console.Write("Digite a quantia em dólares: ");

            while (!double.TryParse(Console.ReadLine().Replace(".", ","), out valor))
            {
                Console.WriteLine("Por favor, digite um número válido.");
            }

            conversaoReal = valor * cotacaoDolar;

            Console.WriteLine($"\nO valor de {valor:$#,##0.00} convertido para real na cotação atual é: {conversaoReal:R$#,##0.00}.");
            Console.Read();

        }
    }
}
