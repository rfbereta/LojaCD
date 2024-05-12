using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaCD.Services.ViewModels
{
    public class GeneroMusicalViewModel
    {
        public int Id { get; set; }

        [DisplayName("Genero Musical")]
        public string Nome { get; set; }
    }
}
