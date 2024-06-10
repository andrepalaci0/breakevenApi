namespace breakevenApi.Domain.Consulta
{
    public interface IConsultaRepository
    {
        Task Create(Consulta consulta);
        Consulta GetById(int idEspecialidade, int idPaciente, int idMedico, DateOnly data);
        List<Consulta> GetAll();
        public List<Consulta> GetByIdMedico(long idMedico);
        public List<Consulta> GetByIdPaciente(long idPaciente);
        void Update(Consulta consulta);
        void Delete(int idEspecialidade, int idPaciente, int idMedico, DateOnly data);
    }
}
