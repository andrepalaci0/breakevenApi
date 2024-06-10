using breakevenApi.Data;
using breakevenApi.Domain.Medic;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace breakevenApi.Queries
{
    public class MedicQuery

    {
        private readonly DataContext _context;   
        private readonly IMedicRepository _medicRepository;
        public MedicQuery(DataContext context, IMedicRepository medicRepository)
        {
            _context = context;
            _medicRepository = medicRepository;
        }

        public Medic findMedicByCrm(long crm)
        {
            return _medicRepository.GetByCrm(crm);
        }   


    }
}
