using System.Collections.Generic;
using System;
using SoundTrackFilm.Interfaces;

namespace SoundTrackFilm
{
    public class BandaRepositorio : IRepositorio<BandaSonora>
    {
        private List<BandaSonora> listaBanda = new List<BandaSonora>();


        public void Atualiza(int id, BandaSonora entidade)
        {
            listaBanda[id] = entidade;
        }

        public void Exclui(int id)
        {
            listaBanda[id].Excluir();
        }

        public void Insere(BandaSonora entidade)
        {
            listaBanda.Add(entidade);
        }

        public List<BandaSonora> Lista()
        {
            return listaBanda;
        }

        public int ProximoId()
        {
            return listaBanda.Count;
        }

        public BandaSonora RetornaPorId(int id)
        {
            return listaBanda[id];
        }
    }
}