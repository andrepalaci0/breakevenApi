using breakevenApi.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace breakevenApi.Domain.Consulta
{
    [Table("Consultas")]
    [PrimaryKey(nameof(IdEspecialidade), nameof(IdPaciente), nameof(IdMedico), nameof(Data))]
    public class Consulta
    {
        public int IdEspecialidade { get; private set; }
        public int IdPaciente { get; private set; }
        public int IdMedico { get; private set; }
        public DateOnly Data { get; private set; }

        [Required]
        public DateOnly HoraInicioConsulta { get; private set; }

        public DateOnly HoraFimConsulta { get; private set; }

        public bool Paga { get; private set; }

        public MetodosPagamento FormaPagamento { get; private set; }

        public float ValorPagamento { get; private set; }

        // Constructor to initialize properties
        public Consulta(int idEspecialidade, int idPaciente, int idMedico, DateOnly data, DateOnly horaInicioConsulta, DateOnly horaFimConsulta, bool paga, MetodosPagamento formaPagamento, float valorPagamento)
        {
            IdEspecialidade = idEspecialidade;
            IdPaciente = idPaciente;
            IdMedico = idMedico;
            Data = data;
            HoraInicioConsulta = horaInicioConsulta;
            HoraFimConsulta = horaFimConsulta;
            Paga = paga;
            FormaPagamento = formaPagamento;
            ValorPagamento = valorPagamento;
        }
    }
}
