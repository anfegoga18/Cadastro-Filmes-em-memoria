using System;

namespace SoundTrackFilm
{
    public class BandaSonora : EntidadeBase
    {
        //Atributos
        private string NomeFilme { get; set; }
        private string DescricaoFilme { get; set; }

        private int Ano { get; set; }

        private string AutorBanda { get; set; }

        private Genero GeneroFilme { get; set; }
        private GeneroB GeneroBanda { get; set; }
        private bool Excluido { get; set; }  

        //Métodos

        public BandaSonora(int id, 
                           string nomeFilme, 
                           string descricaoFilme, 
                           int ano,
                           string autorBanda,
                           Genero genero, 
                           GeneroB generoB,
                           bool excluido)
        {
            this.Id = id;
            this.NomeFilme = nomeFilme;
            this.DescricaoFilme = descricaoFilme;
            this.Ano = ano;
            this.AutorBanda = autorBanda;
            this.GeneroFilme = genero;
            this.GeneroBanda = generoB;
            this.Excluido = false;
        }

        public override string ToString()
        {
            //Environment.Newline Property ver: https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=net-5.0
            string Retorno = "";
            Retorno += "Nome do Filme: " + this.NomeFilme + Environment.NewLine;
            Retorno += "Descrição do Filme: " + this.DescricaoFilme + Environment.NewLine;
            Retorno += "Ano do Filme: " + this.Ano + Environment.NewLine;
            Retorno += "Autor da Banda Sonora: " + this.AutorBanda + Environment.NewLine;
            Retorno += "Gênero do Filme: " + this.GeneroFilme + Environment.NewLine;
            Retorno += "Gênero da Banda Sonora: " + this.GeneroBanda + Environment.NewLine;
            Retorno += "Filme excluido?: " + this.Excluido;
            return Retorno;
        }

        public string retornaBandaS()
        {
            return this.AutorBanda + " fez/fizeram a banda sonora do filme " + 
                this.NomeFilme + "(Gênero: " + this.GeneroBanda + ")";
        }

        public int retonaId()
        {
            return this.Id;
        }

        public bool retornaExcluido()
        {
            return this.Excluido;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }

    }
}