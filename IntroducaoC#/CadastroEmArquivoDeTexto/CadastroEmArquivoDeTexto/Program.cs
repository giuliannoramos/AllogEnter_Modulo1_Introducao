using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroEmArquivoDeTexto
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Cadastro de Usuário");

            try
            {
                InserirInformacoesUsuario();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir informações do usuário: " + ex.Message);
            }

            try
            {
                LerInformacoesUsuario();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao ler informações do arquivo: " + ex.Message);
            }

            Console.Read();
        }

        static void InserirInformacoesUsuario()
        {
            Console.WriteLine("Digite o nome do usuário:");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o e-mail do usuário:");
            string email = Console.ReadLine();

            Console.WriteLine("Digite o telefone do usuário:");
            string telefone = Console.ReadLine();

            Console.WriteLine("Digite o RG do usuário:");
            string rg = Console.ReadLine();

            // Grava as informações em um arquivo de texto
            string arquivo = "usuarios.txt";
            using (StreamWriter sw = File.AppendText(arquivo))
            {
                sw.WriteLine("Nome: " + nome);
                sw.WriteLine("E-mail: " + email);
                sw.WriteLine("Telefone: " + telefone);
                sw.WriteLine("RG: " + rg);
                sw.WriteLine();
            }

            Console.WriteLine("\nInformações de usuários gravadas no arquivo.");
        }

        static void LerInformacoesUsuario()
        {
            string arquivo = "usuarios.txt";

            // Lê as informações do arquivo e exibe na tela
            Console.WriteLine("\nInformações do usuário:");
            using (StreamReader sr = File.OpenText(arquivo))
            {
                string linha;
                while ((linha = sr.ReadLine()) != null)
                {
                    Console.WriteLine(linha);
                }
            }
        }
    }
}
