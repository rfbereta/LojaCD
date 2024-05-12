using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaCD.Services.ViewModels
{
    public class MusicaViewModel
    {
        public int Id { get; set; }
        public int CDId { get; set; }

        [Required(ErrorMessage = "O nome da musica é obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Tempo é obrigatório!")]
        public int Tempo { get; set; }
    }
}
