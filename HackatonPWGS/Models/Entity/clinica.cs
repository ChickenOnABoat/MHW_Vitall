using HackatonPWGS.Models.Entity.Relationship;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HackatonPWGS.Models.Entity
{
    public class clinica
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string nome_clinica { get; set; }
        [Required]
        public int contato_clinica_1 { get; set; }
        [Required]
        public long cnpj_clinica { get; set; }
        
        public int? id_local_atendimento_clinica { get; set; }
        [ForeignKey("id_local_atendimento_clinica")]
        public virtual local_atendimento local_atendimento_clinica { get; set; }
        public List<medico_clinica> medicos_clinica { get; set; }
    }
}
