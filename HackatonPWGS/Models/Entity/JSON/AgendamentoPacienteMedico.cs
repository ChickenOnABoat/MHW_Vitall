using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackatonPWGS.Models.Entity.JSON
{
    public class AgendamentoPacienteMedico
    {
        public int id_medico { get; set; }
        public string data { get; set; }
        public string hora { get; set; }
    }
}
