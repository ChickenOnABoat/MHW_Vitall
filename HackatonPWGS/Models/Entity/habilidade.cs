using HackatonPWGS.Models.Entity.Relationship;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HackatonPWGS.Models.Entity
{
    public class habilidade
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string nome_habilidade { get; set; }
        [Required]
        public string descricao_habilidade { get; set; }
        public List<medico_habilidade> medicos_habilidade { get; set; }
    }
}
