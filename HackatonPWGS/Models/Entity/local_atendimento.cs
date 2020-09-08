using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HackatonPWGS.Models.Entity
{
    public class local_atendimento
    {
        [Key]
        public int id { get; set; }
        public string nome_local_atendimento { get; set; }
        public int contato_local_atendimento_1 { get; set; }
        public int contato_local_atendimento_2 { get; set; }
        [Required]
        public string endereco_local_atendimento { get; set; }
        public string complemento_local_atendimento { get; set; }
        [Required]
        public string numero_local_atendimento { get; set; }
        [Required]
        public string bairro_local_atendimento { get; set; }
        [Required]
        public string uf_local_atendimento { get; set; }
        [Required]
        public string municipio_local_atendimento { get; set; }
        [Required]
        public int cep_local_atendimento { get; set; }
        public List<medico> medicos { get; set; }

    }
}
