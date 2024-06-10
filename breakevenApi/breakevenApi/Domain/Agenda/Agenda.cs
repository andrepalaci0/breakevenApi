using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace breakevenApi.Domain.Agenda
{
    [Table("Agendas")]
    public class Agenda
    {
        [Key]
        [Required]
        public long Id { get; private set; }

        [Required]
        public long IdMedico { get; private set; }

        [Required]
        public DateOnly HoraInicio { get; private set; }

        [Required]
        public DateOnly HoraFim { get; private set; }

        [Required]
        public DayOfWeek DiaDaSemana { get; private set; }

        // Constructor to initialize properties
        public Agenda(long idMedico, DateOnly horaInicio, DateOnly horaFim, DayOfWeek diaDaSemana)
        {
            IdMedico = idMedico;
            HoraInicio = horaInicio;
            HoraFim = horaFim;
            DiaDaSemana = diaDaSemana;
        }
    }
}
