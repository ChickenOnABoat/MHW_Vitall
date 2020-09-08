using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HackatonPWGS.Models.Entity.Relationship
{
    public class acompanhante_local_atendimento
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int id_acompanhante { get; set; }
        public acompanhante acompanhante { get; set; }
        [Required]
        public int id_local_atendimento { get; set; }
        public local_atendimento local_atendimento { get; set; }
    }
}
