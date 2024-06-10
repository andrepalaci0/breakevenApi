

using breakevenApi.Data;
using breakevenApi.Domain.Agenda;
using breakevenApi.Domain.Consulta;
using breakevenApi.Domain.Diagnostica;
using breakevenApi.Domain.Diagnostico;
using breakevenApi.Domain.Doenca;
using breakevenApi.Domain.Especialidade;
using breakevenApi.Domain.ExerceEsp;
using breakevenApi.Domain.Medic;
using breakevenApi.Domain.Paciente;
using breakevenApi.Queries;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DataContext>(options =>
        options.UseSqlServer(connectionString));

builder.Services.AddScoped<IAgendaRepository, AgendaRepository>();
builder.Services.AddScoped<IConsultaRepository, ConsultaRepository>();
builder.Services.AddScoped<IDiagnosticaRepository, DiagnosticaRepository>();
builder.Services.AddScoped<IDiagnosticoRepository, DiagnosticoRepository>();
builder.Services.AddScoped<IDoencaRepository, DoencaRepository>();
builder.Services.AddScoped<IEspecialidadeRepository, EspecialidadeRepository>();
builder.Services.AddScoped<IExerceEspRepository, ExerceEspRepository>();
builder.Services.AddScoped<IMedicRepository, MedicRepository>();
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();

builder.Services.AddScoped<MedicQuery>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
