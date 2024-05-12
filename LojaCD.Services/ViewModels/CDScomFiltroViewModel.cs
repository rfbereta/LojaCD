using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaCD.Services.ViewModels
{
    public class CDScomFiltroViewModel
    {
        public FiltroViewModel Filtro { get; set; }
        public IEnumerable<CDViewModel> CDSViewModel { get; set; }

    }
}
