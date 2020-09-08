using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackatonPWGS.Models.Entity.JSON
{
    public class EspecialidadeMedicos
    {
        public Especialidade especialidade { get; set; }
        public List<Medico> medicos { get; set; }
    }
}
