using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HackatonPWGS.Models.Entity
{
    public class agendamento_medico
    {
        [Key]
        public int id { get; set; }
        public int id_agenda_medico { get; set; }
        [ForeignKey("id_agenda_medico")]
        public agenda_medico agenda_medico { get; set; }
        public int? id_paciente { get; set; }
        [ForeignKey("id_paciente")]
        public virtual paciente paciente { get; set; }
        [Required]
        public DateTime dt_hr_inicio { get; set; }
        [Required]
        public DateTime dt_ht_fim { get; set; }

    }
}
