using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HackatonPWGS.Models.Entity
{
    public class agenda_acompanhante
    {
        [Key]
        public int id { get; set; }
        public int id_acompanhante { get; set; }
        [ForeignKey("id_acompanhante")]
        public acompanhante acompanhante { get; set; }
        public List<horarios_atendimento_acompanhante> horarios_atendimento { get; set; }
        public List<agendamento_acompanhante> agendamentos { get; set; }
    }
}
