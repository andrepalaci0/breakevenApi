using System.Collections.Generic;
using System.Threading.Tasks;

namespace breakevenApi.Domain.Agenda
{
    public interface IAgendaRepository
    {
        Task Create(Agenda agenda);
        Agenda GetById(long id);
        List<Agenda> GetAll();
        void Update(Agenda agenda);
        void Delete(long id);
    }
}
