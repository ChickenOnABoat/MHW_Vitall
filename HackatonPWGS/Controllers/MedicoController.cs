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
    public class MedicoController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly AppDbContext _localDB;

        public MedicoController(IConfiguration config, AppDbContext localDB)
        {
            _config = config;
            _localDB = localDB;
        }
        // GET: api/<MedicoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            agenda_medico agenda = _localDB.agenda_medico.FirstOrDefault();
            horarios_atendimento_medico horarios = _localDB.horarios_atendimento_medico.FirstOrDefault();
            IEnumerable<Tuple<DateTime, DateTime>> teste = this.SplitDateRange(horarios.hr_inicio, horarios.hr_fim, 30);
            Dictionary<DateTime, DateTime> aaa = teste.ToDictionary(l => l.Item1, l => l.Item2);
            return new string[] { "value1", "value2" };
        }

        /*[HttpGet("Calendario/{id}")]
        public JsonResult GetDiasDisponiveis(int id)
        {
            medico medico = _localDB.medico.Find(id);
            agenda_medico agenda = _localDB.agenda_medico.Where(a => a.id_medico == id).FirstOrDefault();
            List<int> dias_semana = new List<int>();
            if(agenda != null)
            {
                //Pegar os dias que tem atendimento = 
                List<horarios_atendimento_medico> horarios = _localDB.horarios_atendimento_medico.Where(h => h.id_agenda_medico == agenda.id).ToList();
                foreach(horarios_atendimento_medico H in horarios)
                {
                    if (!dias_semana.Contains(H.id_dia_semana))
                    {
                        dias_semana.Add(H.id_dia_semana);
                    }
                }
            }
            CalendarioHorarioMedico calendarioHorario = new CalendarioHorarioMedico();
            calendarioHorario.id_medico = medico.id;
            calendarioHorario.nome_medico = medico.nome_medico;
            calendarioHorario.dias_atendimento = dias_semana;

            return new JsonResult(calendarioHorario);
        }*/

        [HttpGet("Calendario/{id}")]
        public JsonResult GetProximasDatasLivres(int id)
        {
            medico medico = _localDB.medico.Find(id);
            agenda_medico agenda = _localDB.agenda_medico.Where(a => a.id_medico == id).FirstOrDefault();
            List<int> dias_semana = new List<int>();
            if (agenda != null)
            {
                //Pegar os dias que tem atendimento = 
                List<horarios_atendimento_medico> horarios = _localDB.horarios_atendimento_medico.Where(h => h.id_agenda_medico == agenda.id).ToList();
                foreach (horarios_atendimento_medico H in horarios)
                {
                    if (!dias_semana.Contains(H.id_dia_semana - 1))
                    {
                        dias_semana.Add(H.id_dia_semana - 1);
                    }
                }
            }
            dias_semana.Sort();
            List<DateTime> proximasDatas = new List<DateTime>();
            DateTime date = DateTime.Now; 
            DateTime datainicial = this.GetNextWeekday(date, dias_semana.First());
            //proximasDatas.Add(datainicial);
            while(proximasDatas.Count < 20)
            {
                foreach(int d in dias_semana)
                {
                    if(proximasDatas.Count == 0)
                    {
                        DateTime t = this.GetNextWeekday(date, d);
                        proximasDatas.Add(t);
                    }
                    else
                    {
                        DateTime t = this.GetNextWeekday(proximasDatas[proximasDatas.Count - 1], d);
                        proximasDatas.Add(t);
                    }
                    
                }
                
            }

            List<string> datasFormatadas = new List<string>();
            foreach(DateTime time in proximasDatas)
            {
                datasFormatadas.Add(time.ToString("dd/MM/yyyy"));
            }

            CalendarioHorarioMedico calendarioHorario = new CalendarioHorarioMedico();
            calendarioHorario.id_medico = medico.id;
            calendarioHorario.nome_medico = medico.nome_medico;
            calendarioHorario.dias_atendimento = datasFormatadas;

            return new JsonResult(calendarioHorario);
        }

        [HttpGet("Calendario/{id}/{data}")]
        public JsonResult GetHorariosLivres(int id, string data)
        {
            agenda_medico agenda = _localDB.agenda_medico.Where(a => a.id_medico == id).FirstOrDefault();
            DateTime oDate = DateTime.ParseExact(data, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            int diasemana = (int)oDate.DayOfWeek;
            horarios_atendimento_medico horarios = _localDB.horarios_atendimento_medico.Where(h => h.id_dia_semana == (diasemana + 1)).FirstOrDefault();
            List<agendamento_medico> agendamentos = _localDB.agendamento_medico.Where(am => am.id_agenda_medico == agenda.id).ToList();
            
            IEnumerable<Tuple<DateTime, DateTime>> teste = this.SplitDateRange(horarios.hr_inicio, horarios.hr_fim, 30);
            Dictionary<DateTime, DateTime> filtrar = teste.ToDictionary(l => l.Item1, l => l.Item2);

            foreach (agendamento_medico agendamento in agendamentos)
            {
                if (filtrar.ContainsKey(agendamento.dt_hr_inicio))
                {
                    filtrar.Remove(agendamento.dt_hr_inicio);
                }
            }
            Dictionary<string, string> res = filtrar.ToDictionary(l => l.Key.ToString("HH:mm"), l => l.Value.ToString("HH:mm"));
            
            List<string> horarios_disponiveis = new List<string>();
            foreach(KeyValuePair<string, string> d in res)
            {
                string aux = String.Concat(d.Key, " até ", d.Value);
                horarios_disponiveis.Add(aux);
            }

            Horario calendarioHorario = new Horario();
            calendarioHorario.horarios = horarios_disponiveis;

            return new JsonResult(calendarioHorario);
        }

        [HttpGet("Agendamento/{id}")]
        public JsonResult GetAgendamentoMedico(int id)
        {
            agendamento_medico agendamento = _localDB.agendamento_medico.Find(id);
            agenda_medico agenda = _localDB.agenda_medico.Where(a => a.id == agendamento.id_agenda_medico).FirstOrDefault();
            medico medico = _localDB.medico.Where(m => m.id == agenda.id_medico).FirstOrDefault();
            AgendamentoMedico agendamentoMedico = new AgendamentoMedico();
            agendamentoMedico.id = agendamento.id;
            agendamentoMedico.nome_medico = medico.nome_medico;
            agendamentoMedico.data = agendamento.dt_hr_inicio.ToString("dd/MM/yyyy");
            agendamentoMedico.hora_inicio = agendamento.dt_hr_inicio.ToString("HH:mm");
            agendamentoMedico.hora_fim = agendamento.dt_ht_fim.ToString("HH:mm");

            //Get Acompanhantes
            int dofweek = (int)agendamento.dt_hr_inicio.DayOfWeek + 1;
            List<horarios_atendimento_acompanhante> hrs = _localDB.horarios_atendimento_acompanhante.Where(h => h.id_dia_semana == dofweek).ToList();
            List<int> idagendasacompanhantes = new List<int>();
            if(hrs.Count > 0)
            {
                foreach(horarios_atendimento_acompanhante h in hrs)
                {
                    if (!idagendasacompanhantes.Contains(h.id_agenda_acompanhante))
                    {
                        idagendasacompanhantes.Add(h.id_agenda_acompanhante);
                    }
                }
            }


            List<Acompanhante> acompanhantes = new List<Acompanhante>();
            foreach(int idagenda in idagendasacompanhantes)
            {
                agenda_acompanhante agenda_acom = _localDB.agenda_acompanhante.Find(idagenda);
                acompanhante acompanhante = _localDB.acompanhante.Find(agenda_acom.id_acompanhante);
                Acompanhante acompanhanteJson = new Acompanhante();
                acompanhanteJson.id = acompanhante.id;
                acompanhanteJson.nome = acompanhante.nome_acompanhante;
                acompanhanteJson.descricao = acompanhante.descricao_acompanhante;
                acompanhanteJson.email = acompanhante.email_acompanhante;
                acompanhantes.Add(acompanhanteJson);
            }
            agendamentoMedico.acompanhantes = acompanhantes;
            return new JsonResult(agendamentoMedico);
        }

        public DateTime GetNextWeekday(DateTime start, int day)
        {
            // The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
            int daysToAdd = (day - (int)start.DayOfWeek + 7) % 7;
            return start.AddDays(daysToAdd);
        }

        // GET api/<MedicoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            
            return "value";
        }

        public IEnumerable<Tuple<DateTime, DateTime>> SplitDateRange(DateTime start, DateTime end, int minutesChunkSize)
        {
            DateTime chunkEnd;
            while ((chunkEnd = start.AddMinutes(minutesChunkSize)) < end)
            {
                yield return Tuple.Create(start, chunkEnd);
                start = chunkEnd;
            }
            yield return Tuple.Create(start, end);
        }

        [HttpGet("Agenda/{id}")]
        public string GetAgendaMedico(int id)
        {
            //Construir agenda aqui.....


            return "value";
        }

        // POST api/<MedicoController>
        [HttpPost]
        [Route("AgendarConsulta")]
        public JsonResult Post([FromBody] AgendamentoPacienteMedico request)
        {
            ResultAgendamento result = new ResultAgendamento();
            try
            {
                agenda_medico agenda = _localDB.agenda_medico.Where(a => a.id_medico == request.id_medico).FirstOrDefault();
                DateTime oDate = DateTime.ParseExact(request.data, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
                agendamento_medico agendamento = new agendamento_medico();
                string horainicio = request.hora.Substring(0, 5);
                string horafim = GetLast(request.hora, 5);
                DateTime datainicio = DateTime.ParseExact(request.data + " " + horainicio, "dd-MM-yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                DateTime datafim = DateTime.ParseExact(request.data + " " + horafim, "dd-MM-yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                agendamento.id_agenda_medico = agenda.id;
                agendamento.id_paciente = 1;
                agendamento.dt_hr_inicio = datainicio;
                agendamento.dt_ht_fim = datafim;

                _localDB.agendamento_medico.Add(agendamento);
                _localDB.SaveChanges();
                result.status = 0;
                result.mensagem = "Consulta Marcada com Sucesso!";
                result.id_agendamento = agendamento.id;
            }catch(Exception e)
            {
                result.status = 1;
                result.mensagem = "Não foi possível marcar a consulta!";
            }

            return new JsonResult(result);
        }

        public string GetLast(string source, int numberOfChars)
        {
            if (numberOfChars >= source.Length)
                return source;
            return source.Substring(source.Length - numberOfChars);
        }

        // PUT api/<MedicoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MedicoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
