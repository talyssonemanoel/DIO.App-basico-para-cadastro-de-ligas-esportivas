using System;
using System.Collections.Generic;
using DIO.Ligas.Interfaces;

namespace DIO.Ligas
{
	public class LigaRepositorio : IRepositorio<Liga>
	{
        private List<Liga> listaLiga = new List<Liga>();
		public void Atualiza(int id, Liga objeto)
		{
			listaLiga[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaLiga[id].Excluir();
		}

		public void Insere(Liga objeto)
		{
			listaLiga.Add(objeto);
		}

		public List<Liga> Lista()
		{
			return listaLiga;
		}

		public int ProximoId()
		{
			return listaLiga.Count;
		}

		public Liga RetornaPorId(int id)
		{
			return listaLiga[id];
		}
	}
}