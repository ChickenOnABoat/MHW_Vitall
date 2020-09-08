using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HackatonPWGS.Models.Entity.Relationship
{
    public class medico_habilidade
    {
        
        [Required]
        public int id_medico { get; set; }
        public medico medico { get; set; }
        [Required]
        public int id_habilidade { get; set; }
        public habilidade habilidade { get; set; }
    }
}
