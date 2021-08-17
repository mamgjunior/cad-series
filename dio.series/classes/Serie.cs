namespace dio.series
{
    public class Serie : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }

        private bool Excluido { get; set; }

        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            return "Gênero: " + this.Genero + "\nTitulo: " + this.Titulo + "\nDescrição: " + this.Descricao + "\nAno: " + this.Ano + "\nExcluido: " + this.Excluido;
        }

        public string retornarTitulo()
        {
            return this.Titulo;
        }

        public int retornarId()
        {
            return this.Id;
        }

        public void excluir()
        {
            this.Excluido = true;
        }
    }
}