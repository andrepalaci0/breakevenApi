namespace breakevenApi.Domain.Services.DTOs.Consulta
{
    public class Horario
    {
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFim { get; set; }

        public bool Livre { get; set; }

        public Horario(DateTime inicio, DateTime fim, bool livre)
        {
            HoraInicio = inicio;
            HoraFim = fim;
            Livre = livre;
        }

        //será considerado que cada consulta tem em média 30 minutos de duração



    }
}
