using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaCD.Domain.Entity
{
    public class CD
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public int GeneroMusicalId { get; set; }
        public GeneroMusical GeneroMusical { get; set; }

        public int ArtistaId { get; set; }
        public Artista Artista { get; set; }

        public IEnumerable<Musica> Musicas { get; set; }

        public CD()
        {

        }
        public CD(int id, string titulo, int generoMusicalId , GeneroMusical generoMusical, int artistaId, Artista artista)
        {
            Id = id;
            Titulo = titulo;
            GeneroMusicalId = generoMusicalId;
            this.GeneroMusical = generoMusical;
            ArtistaId = artistaId;
            this.Artista = artista;
        }
    }

}
