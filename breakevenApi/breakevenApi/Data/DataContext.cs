using breakevenApi.Domain.Agenda;
using breakevenApi.Domain.Consulta;
using breakevenApi.Domain.Diagnostica;
using breakevenApi.Domain.Diagnostico;
using breakevenApi.Domain.Doenca;
using breakevenApi.Domain.Especialidade;
using breakevenApi.Domain.ExerceEsp;
using breakevenApi.Domain.Medic;
using breakevenApi.Domain.Paciente;
using Microsoft.EntityFrameworkCore;

namespace breakevenApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Medic>? Medics { get; set; }
        public DbSet<Agenda>? Agendas { get; set; }
        public DbSet<Consulta>? Consultas { get; set; }
        public DbSet<Diagnostica>? Diagnostica { get; set; }
        public DbSet<Diagnostico>? Diagnosticos { get; set; }
        public DbSet<Doenca>? Doencas { get; set; }
        public DbSet<Especialidade>? Especialidades { get; set; }
        public DbSet<ExerceEsp>? ExerceEsp { get; set; }
        public DbSet<Paciente>? Pacientes { get; set; }
    }
}
