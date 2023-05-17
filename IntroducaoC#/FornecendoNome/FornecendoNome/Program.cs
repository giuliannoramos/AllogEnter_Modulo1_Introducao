using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FornecendoNome
{
    internal class Program
    {      
        static void Main(string[] args)
        {
            Console.WriteLine("Digite um nome:");
            string nome = Console.ReadLine();
            ExibirNome(nome);
            Console.Read();
        }

        static void ExibirNome(string nome)
        {
            Console.WriteLine($"\nOlá meu nome é:{nome}");            
        }
    }
}
