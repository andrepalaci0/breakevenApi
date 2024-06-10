using breakevenApi.Data;
using breakevenApi.Domain.Consulta;

namespace breakevenApi.Queries
{
    public class ConsultaQuery
    {
        private readonly DataContext _context;
        private readonly IConsultaRepository _consultaRepository;

        public ConsultaQuery(DataContext context, IConsultaRepository consultaRepository)
        {
            _context = context;
            _consultaRepository = consultaRepository;
        }

        public List<Consulta> GetConsultasByMedic(long IdMedic) {
            return _consultaRepository.GetByIdMedico(IdMedic);
        }

        public List<Consulta> GetConsultasByPaciente(long IdPaciente)
        {
            return _consultaRepository.GetByIdPaciente(IdPaciente);
        }

    }
}
