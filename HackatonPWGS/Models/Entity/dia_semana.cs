using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HackatonPWGS.Models.Entity
{
    public class dia_semana
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string nome_dia { get; set; }
    }
}
