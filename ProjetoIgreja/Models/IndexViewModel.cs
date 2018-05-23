using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoIgreja.Models
{
    public class IndexViewModel
    {
        //Bloco para AGENDA SEMANAL
        public DateTime inicio { get; set; }

        public DateTime fim { get; set; }

        public agenda agenda { get; set; }

        public List<evento> eventos { get; set; }

        public List<int> hora { get; set; }

        public List<int> minutos { get; set; } 
        

        //FIM AGENDA SEMANAL
        
    }
}