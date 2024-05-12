using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaCD.Services.ViewModels
{
    public class ArtistaViewModel
    {
        public int Id { get; set; }

        [DisplayName("Artista")]
        public string Nome { get; set; }
    }
}
