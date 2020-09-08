using HackatonPWGS.Models.Entity.Relationship;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HackatonPWGS.Models.Entity
{
    public class especialidade_medica
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string nome_especialidade { get; set; }
        [Required]
        public string descricao_especialidade { get; set; }

        public List<medico_especialidade> medico_especialidade { get; set; }
    }
}
