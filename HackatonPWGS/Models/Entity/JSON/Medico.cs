using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackatonPWGS.Models.Entity.JSON
{
    public class Medico
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string crm { get; set; }
        public long numero_contato_1 { get; set; }
        public long numero_contato_2 { get; set; }
        public List<LocalAtendimento> locaisAtendimento { get; set; }
        public List<string> especialidades { get; set; }
        public List<string> habilidades { get; set; }

    }
}
