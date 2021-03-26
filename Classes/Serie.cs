namespace DIO.Series
{
    public class Serie : EntidadesBase
    {
        private Genero Genero {get; set;}
        private string Titulo {get; set;}
        private string Descricao {get; set;}
        private int Ano {get; set;}
        private bool Excluido {get; set;}
        //Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;
        
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
            string retorno = "";
            retorno += "Gênero: " + this.Genero + System.Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + System.Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + System.Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano + System.Environment.NewLine;
            retorno += "Está Excluído?: " + this.Excluido + System.Environment.NewLine;
            return retorno;
        }

        public string retornaTitulo(){
            return this.Titulo;
        }

        public int retornaId(){
            return this.Id;
        }

        public bool retornaExcluido(){
            return this.Excluido;
        }

        public void Excluir(){
            this.Excluido = true;
        }
    }

}