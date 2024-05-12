using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaCD.Domain.Entity
{
    public class Musica
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int Tempo { get; set; }

        public int CDId { get; set; }

        public CD CD { get; set; }

    }
}
