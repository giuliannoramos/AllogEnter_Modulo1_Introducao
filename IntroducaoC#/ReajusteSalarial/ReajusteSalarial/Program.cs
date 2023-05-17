using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReajusteSalarial
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Calculadora de Reajuste Salarial");

            Console.WriteLine("Digite o valor do salário:");
            double salario = double.Parse(Console.ReadLine());

            double reajuste;

            if (salario < 1850)
            {
                reajuste = 320.00;
            }
            else
            {
                reajuste = 180.00;
            }

            double novoSalario = salario + reajuste;

            Console.WriteLine("\nResultado:");
            Console.WriteLine($"Novo salário: {novoSalario:R$#,##0.00}");
            Console.Read();
        }
    }
}
