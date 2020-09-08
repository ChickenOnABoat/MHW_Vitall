using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackatonPWGS.DatabaseContext;
using HackatonPWGS.Models.Entity;
using HackatonPWGS.Models.Entity.JSON;
using HackatonPWGS.Models.Entity.Relationship;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HackatonPWGS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadeMedicaController : ControllerBase
    {

        private readonly IConfiguration _config;
        private readonly AppDbContext _localDB;

        public EspecialidadeMedicaController(IConfiguration config, AppDbContext localDB)
        {
            _config = config;
            _localDB = localDB;
        }

        // GET: api/<EspecialidadeMedicaController>
        [HttpGet]
        public JsonResult Get()
        {

            List<especialidade_medica> especialidades = _localDB.especialidade_medica.OrderBy(e => e.nome_especialidade).ToList();

            return new JsonResult(especialidades);
        }

        [HttpGet("Medicos/{id}")]
        public JsonResult GetMedicosEspecialidade(int id)
        {

            List<medico_especialidade> medico_Especialidades = _localDB.medico_especialidade.Where(m => m.id_especialidade == id).OrderBy(m => m.medico.nome_medico).ToList();
            especialidade_medica especialidade = _localDB.especialidade_medica.Find(id);
            Especialidade especialidadeJson = new Especialidade();
            especialidadeJson.id = especialidade.id;
            especialidadeJson.nome = especialidade.nome_especialidade;


            List<Medico> medicos = new List<Medico>();
            foreach(medico_especialidade me in medico_Especialidades)
            {
                medico m = _localDB.medico.Find(me.id_medico);
                if(m != null)
                {
                    Medico medicoJson = new Medico();
                    medicoJson.id = m.id;
                    medicoJson.nome = m.nome_medico;
                    medicoJson.crm = m.crm_medico;
                    medicoJson.numero_contato_1 = m.numero_contato_medico_1;
                    medicoJson.numero_contato_2 = m.numero_contato_medico_2;
                    //Get local atendimento
                    if (m.id_local_atendimento_medico != null)
                    {
                        local_atendimento lA = _localDB.local_atendimento.Find(m.id_local_atendimento_medico);
                        LocalAtendimento localAtendimento = new LocalAtendimento();
                        localAtendimento.id = lA.id;
                        localAtendimento.nome = lA.nome_local_atendimento;
                        localAtendimento.contato_1 = lA.contato_local_atendimento_1;
                        localAtendimento.contato_2 = lA.contato_local_atendimento_2;
                        localAtendimento.endereco = lA.endereco_local_atendimento;
                        localAtendimento.complemento = lA.complemento_local_atendimento;
                        localAtendimento.numero = lA.numero_local_atendimento;
                        localAtendimento.bairro = lA.bairro_local_atendimento;
                        localAtendimento.uf = lA.uf_local_atendimento;
                        localAtendimento.municipio = lA.municipio_local_atendimento;
                        localAtendimento.cep = lA.cep_local_atendimento;
                        medicoJson.locaisAtendimento = new List<LocalAtendimento>();
                        medicoJson.locaisAtendimento.Add(localAtendimento);
                    }
                    else
                    {
                        List<medico_clinica> clinicas = _localDB.medico_clinica.Where(c => c.id_medico == m.id).ToList();
                        List<LocalAtendimento> locaisAtendimento = new List<LocalAtendimento>();
                        foreach (medico_clinica mc in clinicas)
                        {
                            clinica clinica = _localDB.clinica.Find(mc.id_clinica);
                            local_atendimento lA = _localDB.local_atendimento.Find(clinica.id);
                            LocalAtendimento localAtendimento = new LocalAtendimento();
                            localAtendimento.id = lA.id;
                            localAtendimento.nome = lA.nome_local_atendimento;
                            localAtendimento.contato_1 = lA.contato_local_atendimento_1;
                            localAtendimento.contato_2 = lA.contato_local_atendimento_2;
                            localAtendimento.endereco = lA.endereco_local_atendimento;
                            localAtendimento.complemento = lA.complemento_local_atendimento;
                            localAtendimento.numero = lA.numero_local_atendimento;
                            localAtendimento.bairro = lA.bairro_local_atendimento;
                            localAtendimento.uf = lA.uf_local_atendimento;
                            localAtendimento.municipio = lA.municipio_local_atendimento;
                            localAtendimento.cep = lA.cep_local_atendimento;
                            locaisAtendimento.Add(localAtendimento);
                        }
                        medicoJson.locaisAtendimento = locaisAtendimento;
                    }
                    //Get especialidades
                    List<medico_especialidade> medico_especialidades = _localDB.medico_especialidade.Where(em => em.id_medico == m.id).ToList();
                    List<string> especialidades = new List<string>();
                    foreach(medico_especialidade m_es in medico_especialidades)
                    {
                        especialidade_medica es_med = _localDB.especialidade_medica.Find(m_es.id_especialidade);
                        if(es_med != null)
                        {
                            especialidades.Add(es_med.nome_especialidade);
                        }
                    }
                    medicoJson.especialidades = especialidades;
                    //Get Habilidades
                    List<medico_habilidade> medico_habilidades = _localDB.medico_habilidade.Where(em => em.id_medico == m.id).ToList();
                    List<string> habilidades = new List<string>();
                    foreach (medico_habilidade m_ha in medico_habilidades)
                    {
                        habilidade ha_med = _localDB.habilidade.Find(m_ha.id_habilidade);
                        if (ha_med != null)
                        {
                            habilidades.Add(ha_med.nome_habilidade);
                        }
                    }
                    medicoJson.habilidades = habilidades;
                    medicos.Add(medicoJson);
                }   
            }
            EspecialidadeMedicos especialidadeMedicos = new EspecialidadeMedicos();
            especialidadeMedicos.especialidade = especialidadeJson;
            especialidadeMedicos.medicos = medicos;

            return new JsonResult(especialidadeMedicos);
        }

        // GET api/<EspecialidadeMedicaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EspecialidadeMedicaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EspecialidadeMedicaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EspecialidadeMedicaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
