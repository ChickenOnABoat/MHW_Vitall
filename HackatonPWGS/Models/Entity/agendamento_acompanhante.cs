using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HackatonPWGS.Models.Entity
{
    public class agendamento_acompanhante
    {
        [Key]
        public int id { get; set; }
        public int id_agenda_acompanhante { get; set; }
        [ForeignKey("id_agenda_acompanhante")]
        public agenda_acompanhante agenda_acompanhante { get; set; }
        public int? id_paciente { get; set; }
        [ForeignKey("id_paciente")]
        public virtual paciente paciente { get; set; }
        [Required]
        public DateTime dt_hr_inicio { get; set; }
        [Required]
        public DateTime dt_ht_fim { get; set; }
    }
}
