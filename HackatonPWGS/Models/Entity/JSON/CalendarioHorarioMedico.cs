using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackatonPWGS.Models.Entity.JSON
{
    public class CalendarioHorarioMedico
    {
        public int id_medico { get; set; }
        public string nome_medico { get; set; }
        public List<string> dias_atendimento { get; set; }
    }
}
