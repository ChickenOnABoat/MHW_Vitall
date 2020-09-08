using HackatonPWGS.Models.Entity.Relationship;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HackatonPWGS.Models.Entity
{
    public class medico
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string nome_medico{ get; set; }
        [Required]
        public string crm_medico { get; set; }
        public string email_medico { get; set; }
        public int possui_agenda_medico { get; set; }
        public long numero_contato_medico_1 { get; set; }
        public long numero_contato_medico_2 { get; set; }
        public int? id_local_atendimento_medico { get; set; }
        [ForeignKey("id_local_atendimento_medico")]
        public virtual local_atendimento local_atendimento_medico { get; set; }
        public List<medico_especialidade> especialidade_medico { get; set; }
        public List<medico_habilidade> habilidade_medico { get; set; }
        public List<medico_clinica> clinica_medico { get; set; }
        public int? id_agenda_medico { get; set; }
        [ForeignKey("id_agenda_medico")]
        public agenda_medico agenda_medico { get; set; }

    }
}
