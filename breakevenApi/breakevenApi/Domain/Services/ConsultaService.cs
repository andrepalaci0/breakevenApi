using breakevenApi.Domain.Entities.Consulta;
using breakevenApi.Domain.Entities.Diagnostico;
using breakevenApi.Domain.Entities.Enums;
using breakevenApi.Domain.Entities.Especialidade;
using breakevenApi.Domain.Entities.Historico;
using breakevenApi.Domain.Entities.Medic;
using breakevenApi.Domain.Entities.Paciente;
using breakevenApi.Domain.Services.DTOs.Consulta;
using Microsoft.IdentityModel.Tokens;

namespace breakevenApi.Domain.Services
{
    public class ConsultaService
    {
        private readonly IConsultaRepository _consultaRepository;
        private readonly IMedicRepository _medicoRepository;
        private readonly IDiagnosticoRepository _diagnosticoRepository;
        private readonly IHistoricoPacienteRepository _historicoPacienteRepository;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IEspecialidadeRepository _especialidadeRepository;
        private readonly ILogger<ConsultaService> _logger;

        public ConsultaService(IConsultaRepository consultaRepository,
            IMedicRepository medicRepository,
            IDiagnosticoRepository diagnosticoRepository,
            IHistoricoPacienteRepository historicoPacienteRepository,
            IPacienteRepository pacienteRepository,
            IEspecialidadeRepository especialidadeRepository,
            ILogger<ConsultaService> logger)
        {
            _consultaRepository = consultaRepository;
            _medicoRepository = medicRepository;
            _diagnosticoRepository = diagnosticoRepository;
            _historicoPacienteRepository = historicoPacienteRepository;
            _pacienteRepository = pacienteRepository;
            _especialidadeRepository = especialidadeRepository;
            _logger = logger;
        }

        public List<Consulta> GetByMedicName(string name)
        {

            var medic = _medicoRepository.GetByName(name);
            if (medic == null)
            {
                return null;
            }
            return _consultaRepository.GetAllByIdMedico(medic.Crm);
        }

        public bool FinishesConsulta(FinishesConsultaDTO finishesConsultaDTO)
        {
            DateOnly formatteddata = DateOnly.Parse(finishesConsultaDTO.Data);

            var consulta = _consultaRepository.GetById(finishesConsultaDTO.IdEsp, finishesConsultaDTO.IdPaciente, finishesConsultaDTO.IdMedico, formatteddata);

            if (finishesConsultaDTO.HoraFimConsulta.IsNullOrEmpty()) consulta.HoraFimConsulta = DateTime.Now;

            if (consulta == null)
            {
                _logger.LogError("Consulta não encontrada");
                return false;
            }
            consulta.HoraFimConsulta = DateTime.Parse(finishesConsultaDTO.HoraFimConsulta);

            var diagnostico = finishesConsultaDTO.Diagnostico;
            Diagnostico newDiagnostico = new Diagnostico(
                diagnostico.Message,
                diagnostico.RemediosReceitados,
                diagnostico.TratamentosRecomendados,
                consulta.GetId()
                );
            consulta.IdDiagnostico = newDiagnostico.DiagnosticoId;
            if (finishesConsultaDTO.FormaPagamento.IsNullOrEmpty())
            {
                consulta.Paga = false;
                consulta.FormaPagamento = null;
                consulta.ValorPagamento = null;
                try
                {
                    _diagnosticoRepository.Create(newDiagnostico);
                    _consultaRepository.Update(consulta);
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message);
                    return false;
                }
                AddHistorico(consulta);
                return true;
            }
            consulta.Paga = true;
            consulta.FormaPagamento = (MetodosPagamento)Enum.Parse(typeof(MetodosPagamento), finishesConsultaDTO.FormaPagamento);
            consulta.ValorPagamento = finishesConsultaDTO.ValorPagamento;
            AddHistorico(consulta);
            try
            {
                _diagnosticoRepository.Create(newDiagnostico);
                _consultaRepository.Update(consulta);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return false;
            }
            return true;
        }

        public List<RelatorioCronogramaConsultaDTO> GetDayCronogram(DateOnly day)
        {
            var todayConsults = _consultaRepository.GetAllByDay(day);

            if (todayConsults == null)
            {
                _logger.LogError("Nenhuma consulta encontrada para o dia");
                return null;
            }
            List<RelatorioCronogramaConsultaDTO> todayCronogram = new List<RelatorioCronogramaConsultaDTO>();
            foreach (var consult in todayConsults)
            {
                var cronogram = new RelatorioCronogramaConsultaDTO(
                    _medicoRepository.GetByCrm(consult.IdMedico).NomeMedico,
                    consult.Data,
                    consult.HoraInicioConsulta,
                    _especialidadeRepository.GetByCodigo(consult.IdEspecialidade).ToString(),
                    _pacienteRepository.GetByCodigo(consult.IdPaciente).NomePaciente,
                    _pacienteRepository.GetByCodigo(consult.IdPaciente).Telefone,
                    _historicoPacienteRepository.GetByPaciente(consult.IdPaciente)
                    );
                todayCronogram.Add(cronogram);
            }
            return todayCronogram;
        }

        public List<Horario> GetHorariosLivres(DateOnly day, long idMedico)
        {
            var consultas = _consultaRepository.GetByCrmAndDate(idMedico, day);
            var horarios = GenerateHorarios(day);
            if (consultas == null)
                return horarios;

            foreach (var consulta in consultas)
            {
                foreach (var horario in horarios)
                {

                    if (IsOverlapping(consulta.HoraInicioConsulta, consulta.HoraFimConsulta, horario.HoraInicio, horario.HoraFim))
                    {
                        horario.Livre = false;
                    }
                }
            }
            return horarios;
        }

        public bool AddHistorico(Consulta consulta)
        {
            var historico = _historicoPacienteRepository.GetById(consulta.IdPaciente, consulta.GetId());
            if (historico == null)
            {
                HistoricoPaciente newHistorico = new HistoricoPaciente(consulta.IdPaciente, consulta.GetId(),
                    _diagnosticoRepository.GetById(consulta.IdDiagnostico).Message,
                    consulta.Data,
                    _medicoRepository.GetByCrm(consulta.IdMedico).NomeMedico);

                try
                {
                    _historicoPacienteRepository.Add(newHistorico);
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message);
                    return false;
                }
                return true;
            }
            _logger.LogError("Historico já existe");
            return false;
        }

        public List<Horario> GenerateHorarios(DateOnly date)
        {
            var horarios = new List<Horario>();
            var startTime = new DateTime(date.Year, date.Month, date.Day, 8, 0, 0); // Starting at 8:00 
            var endTime = new DateTime(date.Year, date.Month, date.Day, 17, 0, 0); // Ending at 17:00

            while (startTime < endTime)
            {
                var fim = startTime.AddMinutes(30); // 30 minutes
                horarios.Add(new Horario(startTime, fim, true));
                startTime = fim;
            }

            return horarios;
        }

        private bool IsOverlapping(DateTime consultaStart, DateTime consultaEnd, DateTime slotStart, DateTime slotEnd)
        {
            return consultaStart < slotEnd && consultaEnd > slotStart;
        }
    }
}
