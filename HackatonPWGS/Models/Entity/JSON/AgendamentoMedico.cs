using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackatonPWGS.Models.Entity.JSON
{
    public class AgendamentoMedico
    {
        public int id { get; set; }
        public string nome_medico { get; set; }
        public string data { get; set; }
        public string  hora_inicio { get; set; }
        public string  hora_fim { get; set; }
        public List<Acompanhante> acompanhantes { get; set; }
    }
}
