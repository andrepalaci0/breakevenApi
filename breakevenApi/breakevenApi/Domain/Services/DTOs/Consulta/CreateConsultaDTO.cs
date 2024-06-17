namespace breakevenApi.Domain.Services.DTOs.Consulta
{
    public class CreateConsultaDTO
    {
        public string NomePaciente { get; set; }

        public string TelefonePaciente { get; set; }

        public string CPFPaciente { get; set; }

        public long CodigoEspecialidade { get; set; }

        public DateOnly DataConsulta { get; set; }

        public DateTime HoraInicio { get; set; }
        public DateTime HoraFim { get; set; }
        public string? NomeMedicoPreferencia { get; set; }

    }
}
