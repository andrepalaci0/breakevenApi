using System.Collections.Generic;
using System.Threading.Tasks;
using breakevenApi.Domain.Medic;

namespace breakevenApi.Domain.Medic
{
    public interface IMedicRepository
    {
        Task Create(Medic medic);
        Medic? GetByCrm(long crm);
        List<Medic>? GetAll();
        void Update(Medic medic);
        void Delete(long crm);
    }
}
