using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackatonPWGS.Models.Entity.JSON
{
    public class LocalAtendimento
    {
        public int id { get; set; }
        public string nome { get; set; }
        public int contato_1 { get; set; }
        public int contato_2 { get; set; }
        
        public string endereco { get; set; }
        public string complemento { get; set; }
        
        public string numero { get; set; }
        
        public string bairro { get; set; }
        public string uf { get; set; }
        public string municipio { get; set; }
        public int cep { get; set; }
    }
}
