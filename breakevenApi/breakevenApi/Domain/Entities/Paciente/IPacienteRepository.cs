namespace breakevenApi.Domain.Entities.Paciente;

public interface IPacienteRepository
{
    Task Create(Paciente paciente);
    Paciente GetByCodigo(long codigoPaciente);
    List<Paciente> GetAll();
    void Update(Paciente paciente);
    void Delete(long codigoPaciente);
}
