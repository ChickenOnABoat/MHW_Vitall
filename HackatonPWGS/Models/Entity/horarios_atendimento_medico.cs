using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HackatonPWGS.Models.Entity
{
    public class horarios_atendimento_medico
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int id_dia_semana { get; set; }
        [ForeignKey("id_dia_semana")]
        public dia_semana dia_semana { get; set; }
        public int id_agenda_medico { get; set; }
        [ForeignKey("id_agenda_medico")]
        public agenda_medico agenda { get; set; }
        public int id_local_atendimento { get; set; }
        [ForeignKey("id_local_atendimento")]
        public local_atendimento local_atendimento_agendamento { get; set; }
        [Required]
        public DateTime hr_inicio { get; set; }
        [Required]
        public DateTime hr_fim { get; set; }
    }
}
