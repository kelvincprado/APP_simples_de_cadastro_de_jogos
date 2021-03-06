using System;
using System.Collections.Generic;
namespace APP_simples_de_cadastro_de_jogos
{
    public class JogosRepositorio : IRepositorio<Jogos>
    {
        private List<Jogos> listaJogos = new List<Jogos>();
        public void Atualiza(int id, Jogos objeto)
        {
            listaJogos[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaJogos[id].Excluir();
        }

        public void Insere(Jogos objeto)
        {
            listaJogos.Add(objeto);
        }

        public List<Jogos> Lista()
        {
            return listaJogos;
        }

        public int ProximoId()
        {
            return listaJogos.Count;
        }

        public Jogos RetornaPorId(int id)
        {
            return listaJogos[id];
        }
    }
}