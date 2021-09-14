using System;

namespace DIO.Ligas
{
    public class Liga : EntidadeBase
    {
        // Atributos
		private Modalidade Modalidade { get; set; }
		private string Nome { get; set; }
		private string Divisao { get; set; }
		private int Ano { get; set; }
        private bool Excluido {get; set;}

        // Métodos
		public Liga(int id, Modalidade modalidade, string nome, string divisao, int ano)
		{
			this.Id = id;
			this.Modalidade = modalidade;
			this.Nome = nome;
			this.Divisao = divisao;
			this.Ano = ano;
            this.Excluido = false;
		}

        public override string ToString()
		{
			
            string retorno = "";
            retorno += "Modalidade: " + this.Modalidade + Environment.NewLine;
            retorno += "Nome: " + this.Nome + Environment.NewLine;
            retorno += "Divisão: " + this.Divisao + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
			return retorno;
		}

        public string retornaNome()
		{
			return this.Nome;
		}

		public int retornaId()
		{
			return this.Id;
		}
        public bool retornaExcluido()
		{
			return this.Excluido;
		}
        public void Excluir() {
            this.Excluido = true;
        }
    }
}