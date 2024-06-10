﻿
using breakevenApi.Data;
using breakevenApi.Domain.Medic;

namespace breakevenApi.Domain.Medic
{
    public class MedicRepository : IMedicRepository
    {
        private readonly DataContext _context;

        public MedicRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Create(Medic medic)
        {
            _context.Medics.Add(medic);
            await _context.SaveChangesAsync();
        }

        public Medic GetByCrm(long crm)
        {
            return _context.Medics.FirstOrDefault(m => m.Crm == crm);
        }

        public List<Medic> GetAll()
        {
            return _context.Medics.ToList();
        }

        public void Update(Medic medic)
        {
            _context.Medics.Update(medic);
            _context.SaveChanges();
        }

        public void Delete(long crm)
        {
            var medic = _context.Medics.FirstOrDefault(m => m.Crm == crm);
            if (medic != null)
            {
                _context.Medics.Remove(medic);
                _context.SaveChanges();
            }
        }
    }
}
