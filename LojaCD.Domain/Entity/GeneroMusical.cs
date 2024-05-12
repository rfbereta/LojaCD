using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaCD.Domain.Entity
{
    public class GeneroMusical
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public GeneroMusical()
        {
                
        }
        public GeneroMusical(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

    }
}
