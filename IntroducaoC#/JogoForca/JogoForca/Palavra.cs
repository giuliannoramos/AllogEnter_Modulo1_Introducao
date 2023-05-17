using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JogoForca
{
    public class Palavra
    {
        public string Nome { get; }
        public CategoriaPalavra Categoria { get; }
        public int TentativasDisponiveis { get; set; }
        public int TentativasRealizadas { get; set; }

        public Palavra(string nome, CategoriaPalavra categoria)
        {
            Nome = nome;
            Categoria = categoria;
        }        

    }
}
