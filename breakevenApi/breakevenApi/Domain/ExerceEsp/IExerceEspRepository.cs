
namespace breakevenApi.Domain.ExerceEsp
{
    public interface IExerceEspRepository
    {
        Task Create(ExerceEsp exerceEsp);
        ExerceEsp GetById(long idEsp, long idMedico);
        List<ExerceEsp> GetAll();
        void Update(ExerceEsp exerceEsp);
        void Delete(long idEsp, long idMedico);
    }
}
