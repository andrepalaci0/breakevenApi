using breakevenApi.Data;

namespace breakevenApi.Domain.Agenda;

public class AgendaRepository : IAgendaRepository
{
    private readonly DataContext _context;

    public AgendaRepository(DataContext context)
    {
        _context = context;
    }

    public async Task Create(Agenda agenda)
    {
        _context.Agendas.Add(agenda);
        await _context.SaveChangesAsync();
    }

    public Agenda GetById(long id)
    {
        return _context.Agendas.FirstOrDefault(a => a.Id == id);
    }

    public List<Agenda> GetAll()
    {
        return _context.Agendas.ToList();
    }

    public void Update(Agenda agenda)
    {
        _context.Agendas.Update(agenda);
        _context.SaveChanges();
    }

    public void Delete(long id)
    {
        var agenda = _context.Agendas.FirstOrDefault(a => a.Id == id);
        if (agenda != null)
        {
            _context.Agendas.Remove(agenda);
            _context.SaveChanges();
        }
    }
}
