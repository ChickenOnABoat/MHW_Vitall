using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HackatonPWGS.Models.Entity
{
    public class horarios_atendimento_acompanhante
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int id_dia_semana { get; set; }
        [ForeignKey("id_dia_semana")]
        public dia_semana dia_semana { get; set; }
        public int id_agenda_acompanhante { get; set; }
        [ForeignKey("id_agenda_acompanhante")]
        public agenda_acompanhante agenda { get; set; }
        [Required]
        public DateTime hr_inicio { get; set; }
        [Required]
        public DateTime hr_fim { get; set; }
    }
}
