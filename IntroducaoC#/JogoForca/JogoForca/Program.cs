using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace JogoForca
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("========= Bem-vindo ao Jogo da Forca! =========");
            Console.ResetColor();            

            // Carregar palavras do arquivo CSV
            List<Palavra> palavras = CarregarPalavras("palavras.csv");

            // Sortear uma palavra
            Palavra palavraSorteada = SortearPalavra(palavras);
                      
            // Iniciar o jogo
            Jogar();
            
            Console.ReadLine();
        }        

        static List<Palavra> CarregarPalavras(string arquivo)
        {
            List<Palavra> palavras = new List<Palavra>();

            // Ler o arquivo CSV
            string[] linhas = File.ReadAllLines(@"C:\Users\giule\source\repos\AllogEnter_Modulo1_Introducao\IntroducaoC#\JogoForca\JogoForca\palavras.csv");

            foreach (string linha in linhas)
            {
                // Separar a linha em palavra e categoria
                string[] campos = linha.Split(';');
                string palavra = RemoverAcentos(campos[0]);
                CategoriaPalavra categoria = (CategoriaPalavra)Enum.Parse(typeof(CategoriaPalavra), campos[1]);

                // Adicionar a palavra à lista
                palavras.Add(new Palavra(palavra, categoria));
            }

            return palavras;
        }

        private static List<Palavra> LerPalavrasDoArquivo()
        {
            List<Palavra> palavras = new List<Palavra>();
            string[] linhas = File.ReadAllLines(@"C:\Users\giule\source\repos\AllogEnter_Modulo1_Introducao\IntroducaoC#\JogoForca\JogoForca\palavras.csv");

            foreach (string linha in linhas)
            {
                string[] campos = linha.Split(';');
                if (campos.Length == 3)
                {
                    string nome = campos[0];
                    CategoriaPalavra categoria = (CategoriaPalavra)int.Parse(campos[1]);
                    palavras.Add(new Palavra(nome, categoria));
                }
            }

            return palavras;
        }
        
        static Palavra SortearPalavra(List<Palavra> palavras)
        {
            // Sortear uma palavra aleatoriamente
            Random random = new Random();
            int indice = random.Next(palavras.Count);
            return palavras[indice];
        }

        static string RemoverAcentos(string texto)
        {
            string normalizedString = texto.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in normalizedString)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    stringBuilder.Append(c);
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        private static int EscolherDificuldade()
        {
            Console.WriteLine("\nEscolha a dificuldade do jogo:");
            Console.WriteLine("1. Fácil (7 tentativas)");
            Console.WriteLine("2. Normal (6 tentativas)");
            Console.WriteLine("3. Difícil (5 tentativas)");
            Console.Write("\nDigite o número da opção desejada: ");

            int opcao;
            while (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 1 || opcao > 3)
            {
                Console.WriteLine("Opção inválida. Digite novamente.");
                Console.Write("Digite o número da opção desejada: ");
            }

            switch (opcao)
            {
                case 1:
                    return 7;
                case 2:
                    return 6;
                case 3:
                    return 5;
                default:
                    return 6; // Valor padrão para caso ocorra algum erro
            }
        }

        private static Palavra GerarPalavraAleatoria(int tentativasDisponiveis)
        {
            Random random = new Random();
            int categoriaIndex = random.Next(0, 4); // Atualizado para incluir a nova categoria
            CategoriaPalavra categoria = (CategoriaPalavra)categoriaIndex;

            List<Palavra> palavras = LerPalavrasDoArquivo();
            List<Palavra> palavrasFiltradas = palavras.Where(p => p.Categoria == categoria).ToList();

            if (palavrasFiltradas.Count == 0)
            {
                // Caso não haja palavras na categoria selecionada, retorna null
                return null;
            }

            int palavraIndex = random.Next(0, palavrasFiltradas.Count);
            Palavra palavraSorteada = palavrasFiltradas[palavraIndex];
            palavraSorteada.TentativasDisponiveis = tentativasDisponiveis; // Define o número de tentativas disponíveis
            return palavraSorteada;
        }

        static void Jogar()
        {
            int tentativasDisponiveis = EscolherDificuldade();
            Palavra palavraSorteada = GerarPalavraAleatoria(tentativasDisponiveis);
            List<char> letrasUtilizadas = new List<char>();
            char[] palavraParcial;

            if (palavraSorteada != null)
            {
                palavraParcial = new char[palavraSorteada.Nome.Length];
            }
            else
            {
                // Tratar a situação em que palavraSorteada é null, por exemplo, lançar uma exceção ou definir um valor padrão para palavraParcial.
                throw new Exception("Não foi possível gerar uma palavra aleatória.");
            }
            for (int i = 0; i < palavraParcial.Length; i++)
            {
                if (char.IsLetter(palavraSorteada.Nome[i]) || char.IsDigit(palavraSorteada.Nome[i]))
                {
                    palavraParcial[i] = '_';
                }
                else
                {
                    palavraParcial[i] = palavraSorteada.Nome[i];
                }
            }

            while (palavraSorteada.TentativasDisponiveis > 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("==========Placar==========");
                Console.ResetColor();
                Console.WriteLine($"Tentativas disponíveis: {palavraSorteada.TentativasDisponiveis}");
                Console.WriteLine($"Tentativas realizadas: {palavraSorteada.TentativasRealizadas}");
                Console.WriteLine("Letras utilizadas: " + string.Join(", ", letrasUtilizadas));
                Console.WriteLine();
                Console.WriteLine("Categoria: " + palavraSorteada.Categoria);
                Console.WriteLine("Palavra: " + new string(palavraParcial));
                Console.WriteLine();

                Console.Write("\nDigite uma letra ou número: ");
                string letra = Console.ReadLine();

                if (letra.Length == 1 && char.IsLetterOrDigit(letra[0]))
                {
                    char letraDigitada = char.ToUpper(letra[0]);

                    // Verificar se a letra já foi utilizada
                    if (letrasUtilizadas.Contains(letraDigitada))
                    {
                        Console.WriteLine("Essa letra ou número já foi utilizado. Tente novamente.");
                        Console.WriteLine();
                    }
                    else
                    {
                        letrasUtilizadas.Add(letraDigitada);

                        bool letraEncontrada = false;

                        for (int i = 0; i < palavraSorteada.Nome.Length; i++)
                        {
                            if (char.ToUpper(palavraSorteada.Nome[i]) == letraDigitada)
                            {
                                palavraParcial[i] = palavraSorteada.Nome[i];
                                letraEncontrada = true;
                            }
                        }

                        if (!letraEncontrada)
                        {
                            palavraSorteada.TentativasDisponiveis--;
                        }                       

                        palavraSorteada.TentativasRealizadas++;
                    }
                }
                else
                {
                    Console.WriteLine("\nEntrada inválida. Tente novamente.");
                    Console.WriteLine();
                }

                if (new string(palavraParcial) == palavraSorteada.Nome)
                {
                    Console.Clear();
                    Console.WriteLine("Placar:");
                    Console.WriteLine($"Tentativas disponíveis: {palavraSorteada.TentativasDisponiveis}");
                    Console.WriteLine($"Tentativas realizadas: {palavraSorteada.TentativasRealizadas}");
                    Console.WriteLine("Letras utilizadas: " + string.Join(", ", letrasUtilizadas));
                    Console.WriteLine();
                    Console.WriteLine("Categoria: " + palavraSorteada.Categoria);
                    Console.WriteLine("Palavra: " + new string(palavraParcial));
                    Console.WriteLine();
                    Console.WriteLine("Fim de jogo, você venceu!");

                    Console.WriteLine();
                    Console.Write("Deseja jogar novamente? (S/N): ");
                    string novaJogada = Console.ReadLine();

                    while (!novaJogada.Equals("S", StringComparison.OrdinalIgnoreCase) && !novaJogada.Equals("N", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.Write("Opção inválida. Digite S para jogar novamente ou N para sair: ");
                        novaJogada = Console.ReadLine();
                    }

                    if (novaJogada.Equals("S", StringComparison.OrdinalIgnoreCase))
                    {
                        Jogar(); // Reinicia o jogo
                    }
                    else
                    {
                        Console.WriteLine("Obrigado por jogar! Até mais!");
                        // Encerra o programa
                    }

                    return;
                }
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==========Placar==========");
            Console.ResetColor();
            Console.WriteLine($"Tentativas disponíveis: {palavraSorteada.TentativasDisponiveis}");
            Console.WriteLine($"Tentativas realizadas: {palavraSorteada.TentativasRealizadas}");
            Console.WriteLine("Letras utilizadas: " + string.Join(", ", letrasUtilizadas));
            Console.WriteLine();
            Console.WriteLine("Categoria: " + palavraSorteada.Categoria);
            Console.WriteLine("Palavra: " + new string(palavraParcial));
            Console.WriteLine();
            Console.WriteLine("\nFim de jogo, você perdeu!");

            Console.WriteLine();
            Console.Write("\nDeseja jogar novamente? (S/N): ");
            string jogarNovamente = Console.ReadLine();

            while (!jogarNovamente.Equals("S", StringComparison.OrdinalIgnoreCase) && !jogarNovamente.Equals("N", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Opção inválida. Digite S para jogar novamente ou N para sair: ");
                jogarNovamente = Console.ReadLine();
            }

            if (jogarNovamente.Equals("S", StringComparison.OrdinalIgnoreCase))
            {
                Jogar(); // Reinicia o jogo
            }
            else
            {
                Console.WriteLine("Obrigado por jogar! Até mais!");
                // Encerra o programa
            }
        }

    }
}
