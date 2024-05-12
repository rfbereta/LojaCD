using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LojaCD.Domain.Entity
{
    public class Artista
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Artista()
        {
                
        }
        public Artista(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

    }
}
