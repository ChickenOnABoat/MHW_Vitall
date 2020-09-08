using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HackatonPWGS.Models.Entity
{
    public class paciente
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string nome_paciente { get; set; }
        [Required]
        public long documento_paciente { get; set; }
        [Required]
        public string email_paciente { get; set; }
        public string celular_paciente { get; set; }
       
        public int id_acesso_paciente { get; set; } //ID que define limitação de acessos do paciente a medicos/procedimentos (?)
        public string endereco_paciente { get; set; }
        public string complemento_endereco_paciente { get; set; }
        public string numero_endereco_paciente { get; set; }
        public string bairro_endereco_paciente { get; set; }
        public string uf_endereco_paciente { get; set; }
        public string municipio_endereco_paciente { get; set; }
        public int cep_endereco_paciente { get; set; }
        public List<agendamento_medico> agendamentos { get; set; }
        public List<agendamento_acompanhante> agendamentos_acompanhantes { get; set; }

    }
}
