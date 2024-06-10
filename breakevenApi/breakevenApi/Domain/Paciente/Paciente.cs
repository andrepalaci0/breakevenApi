using breakevenApi.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace breakevenApi.Domain.Paciente
{
    [Table("Pacientes")]
    public class Paciente
    {
        [Key]
        [Required]
        public long CodigoPaciente { get; private set; }

        [Required]
        [MaxLength(11)]
        public string Cpf { get; private set; }

        [Required]
        [MaxLength(100)]
        public string NomePaciente { get; private set; }

        [Required]
        [MaxLength(15)]
        public string Telefone { get; private set; }

        [Required]
        public Sexo Sexo { get; private set; }

        [Required]
        [MaxLength(200)]
        public string Endereco { get; private set; }

        [Required]
        public int Idade { get; private set; }

        // Constructor to initialize properties
        public Paciente(long codigoPaciente, string cpf, string nomePaciente, string telefone, Sexo sexo, string endereco, int idade)
        {
            CodigoPaciente = codigoPaciente;
            Cpf = cpf;
            NomePaciente = nomePaciente;
            Telefone = telefone;
            Sexo = sexo;
            Endereco = endereco;
            Idade = idade;
        }
    }
}
