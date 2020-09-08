using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HackatonPWGS.Models.Entity
{
    public class agenda_medico
    {
        [Key]
        public int id { get; set; }
        public int id_medico { get; set; }
        [ForeignKey("id_medico")]
        public medico medico { get; set; }
        [Required]
        public int duracao_compromisso_minutos { get; set; }
        [Required]
        public int duracao_intervalo_minutos { get; set; }
        public List<horarios_atendimento_medico> horarios_atendimento { get; set; }
        public List<agendamento_medico> agendamentos { get; set; }
    }
}
