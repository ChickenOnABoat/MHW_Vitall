using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HackatonPWGS.Models.Entity
{
    public class acompanhante
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string nome_acompanhante { get; set; }
        public string email_acompanhante { get; set; }
        public long numero_contato_acompanhante { get; set; }
        public string descricao_acompanhante { get; set; }
        public int? id_agenda_acompanhante { get; set; }
        [ForeignKey("id_agenda_acompanhante")]
        public agenda_acompanhante agenda_acompanhante { get; set; }
    }
}
