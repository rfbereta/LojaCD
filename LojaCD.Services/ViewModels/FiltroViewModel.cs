using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaCD.Services.ViewModels
{
    public class FiltroViewModel
    {
        [DisplayName("Titulo do CD")]
        public string? TituloCD { get; set; }
        [DisplayName("Nome do artista")]
        public int? ArtistaID { get; set; }
        [DisplayName("Nome do genero musical")]
        public int? GeneroMusicalID { get; set; }
        [DisplayName("Nome da musica")]
        public string? NomeMusica { get; set; }

    }
}
