using LojaCD.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaCD.Services.ViewModels
{
    public class CDViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O Titulo é obrigatório!")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O Artista é obrigatório!")]
        public int ArtistaId { get; set; }
        public ArtistaViewModel? Artista { get; set; }

        [Required(ErrorMessage = "O Genero Musical é obrigatório!")]
        public int? GeneroMusicalId { get; set; }
        public GeneroMusicalViewModel? GeneroMusical { get; set; }

        public IEnumerable<MusicaViewModel>? Musicas { get; set; }


    }
}
