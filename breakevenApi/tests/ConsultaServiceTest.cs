using breakevenApi.Domain.Entities.Paciente;
using breakevenApi.Domain.Services.DTOs.Consulta;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using System;
using System.Collections.Generic;
using breakevenApi.Domain.Services.DTOs.Diagnostico;
using breakevenApi.Domain.Entities.Consulta;
using breakevenApi.Domain.Entities.Diagnostico;
using breakevenApi.Domain.Entities.Paciente;
using breakevenApi.Domain.Entities.Enums;
using breakevenApi.Domain.Entities.Medic;
using breakevenApi.Domain.Entities.Historico;
using breakevenApi.Domain.Entities.Especialidade;
using breakevenApi.Domain.Services;

namespace breakevenApi.Services.Tests
{
    public class ConsultaServiceTests
    {
        private readonly Mock<IConsultaRepository> _mockConsultaRepository;
        private readonly Mock<IMedicRepository> _mockMedicRepository;
        private readonly Mock<IDiagnosticoRepository> _mockDiagnosticoRepository;
        private readonly Mock<IHistoricoPacienteRepository> _mockHistoricoPacienteRepository;
        private readonly Mock<IPacienteRepository> _mockPacienteRepository;
        private readonly Mock<IEspecialidadeRepository> _mockEspecialidadeRepository;
        private readonly Mock<ILogger<ConsultaService>> _mockLogger;
        private readonly ConsultaService _consultaService;

        public ConsultaServiceTests()
        {
            _mockConsultaRepository = new Mock<IConsultaRepository>();
            _mockMedicRepository = new Mock<IMedicRepository>();
            _mockDiagnosticoRepository = new Mock<IDiagnosticoRepository>();
            _mockHistoricoPacienteRepository = new Mock<IHistoricoPacienteRepository>();
            _mockPacienteRepository = new Mock<IPacienteRepository>();
            _mockEspecialidadeRepository = new Mock<IEspecialidadeRepository>();
            _mockLogger = new Mock<ILogger<ConsultaService>>();
            
            _consultaService = new ConsultaService(
                _mockConsultaRepository.Object,
                _mockMedicRepository.Object,
                _mockDiagnosticoRepository.Object,
                _mockHistoricoPacienteRepository.Object,
                _mockPacienteRepository.Object,
                _mockEspecialidadeRepository.Object,
                _mockLogger.Object);
        }

        [Fact]
        public void GetByMedicName_MedicExists_ReturnsConsultas()
        {
            var medic = new Medic(123L, 1, "Phone", "Dr. House");
            var consultas = new List<Consulta> { new Consulta(1L, 2L, 123L, DateOnly.Parse("2023-01-01"), DateTime.Now, DateTime.Now.AddMinutes(30), true, MetodosPagamento.PIX, 100) };

            _mockMedicRepository.Setup(repo => repo.GetByName("Dr. House")).Returns(medic);
            _mockConsultaRepository.Setup(repo => repo.GetAllByIdMedico(123L)).Returns(consultas);

            var result = _consultaService.GetByMedicName("Dr. House");

            Assert.Equal(consultas, result);
        }

        [Fact]
        public void GetByMedicName_MedicNotExists_ReturnsNull()
        {
            _mockMedicRepository.Setup(repo => repo.GetByName("Dr. Strange")).Returns((Medic)null);

            var result = _consultaService.GetByMedicName("Dr. Strange");

            Assert.Null(result);
        }

        
        [Fact]
        public void FinishesConsulta_ValidData_ReturnsTrue()
        {
            var diagnosticoDTO = new DiagnosticoDTO(
                "Healthy",
                "None",
                "Rest",
                0
            );

            var finishesConsultaDTO = new FinishesConsultaDTO(
                1L,
                2L,
                3L,
                "2023-01-01",
                "14:30",
                "PIX",
                100,
                diagnosticoDTO
            );

            var consulta = new Consulta(
                1L,
                2L,
                3L,
                DateOnly.Parse("2023-01-01"),
                DateTime.Now,
                DateTime.Now.AddMinutes(30),
                false,
                MetodosPagamento.PIX,
                0
            );

            var diagnostico = new Diagnostico(
                "Healthy",
                "None",
                "Rest",
                0
            );

            _mockConsultaRepository.Setup(repo => repo.GetById(1L, 2L, 3L, DateOnly.Parse("2023-01-01"))).Returns(consulta);
            _mockDiagnosticoRepository.Setup(repo => repo.Create(It.IsAny<Diagnostico>())).Verifiable();
            _mockDiagnosticoRepository.Setup(repo => repo.GetById(It.IsAny<long>())).Returns(diagnostico);
            _mockMedicRepository.Setup(repo => repo.GetByCrm(It.IsAny<long>())).Returns(new Medic(3L, 1, "1234567890", "Dr. House"));
            _mockConsultaRepository.Setup(repo => repo.Update(consulta)).Verifiable();
            _mockHistoricoPacienteRepository.Setup(repo => repo.GetById(It.IsAny<long>(), It.IsAny<long>())).Returns((HistoricoPaciente)null);
            _mockHistoricoPacienteRepository.Setup(repo => repo.Add(It.IsAny<HistoricoPaciente>())).Verifiable();

            var result = _consultaService.FinishesConsulta(finishesConsultaDTO);

            Assert.True(result);
            _mockConsultaRepository.Verify(repo => repo.Update(consulta), Times.Once);
            _mockDiagnosticoRepository.Verify(repo => repo.Create(It.IsAny<Diagnostico>()), Times.Once);
            _mockHistoricoPacienteRepository.Verify(repo => repo.Add(It.IsAny<HistoricoPaciente>()), Times.Once);
        }

        [Fact]
        public void GetDayCronogram_ConsultasExist_ReturnsCronogram()
        {
            // Arrange
            var day = DateOnly.Parse("2023-01-01");
            var consultas = new List<Consulta>
            {
               new Consulta(1L, 2L, 3L, day, DateTime.Now, DateTime.Now.AddMinutes(30), true, MetodosPagamento.PIX, 100)
            };

            _mockConsultaRepository.Setup(repo => repo.GetAllByDay(day)).Returns(consultas);
            _mockMedicRepository.Setup(repo => repo.GetByCrm(3L)).Returns(new Medic(3L, 1,"1234567890", "Dr. House"));
            _mockEspecialidadeRepository.Setup(repo => repo.GetByCodigo(1L)).Returns(new Especialidade(1L, 1, "Cardiology"));
            _mockPacienteRepository.Setup(repo => repo.GetByCodigo(2L)).Returns(new Paciente(2L, "12345678901", "John Doe", "123-456-7890", Sexo.MASCULINO, "123 Main St", 30));
            _mockHistoricoPacienteRepository.Setup(repo => repo.GetByPaciente(2L)).Returns(new List<HistoricoPaciente>());

            // Act
            var result = _consultaService.GetDayCronogram(day);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            /*
            var cronogram = result.First();
            Assert.Equal("Dr. House", cronogram.NomeMedico);
            Assert.Equal(day, cronogram.DataConsulta);
            Assert.Equal(consultas[0].HoraInicioConsulta, cronogram.HoraInicioConsulta);
            Assert.Equal("Cardiology", cronogram.Especialidade);
            Assert.Equal("John Doe", cronogram.NomePaciente);
            Assert.Equal("123-456-7890", cronogram.TelefonePaciente);
            */
        }


        [Fact]
        public void GetHorariosLivres_NoConsultas_ReturnsAllHorariosAsLivres()
        {
            var day = DateOnly.Parse("2023-01-01");
            var idMedico = 123L;

            _mockConsultaRepository.Setup(repo => repo.GetByCrmAndDate(idMedico, day)).Returns((List<Consulta>)null);

            var result = _consultaService.GetHorariosLivres(day, idMedico);

            Assert.All(result, horario => Assert.True(horario.Livre));
        }

        [Fact]
        public void GetHorariosLivres_WithConsultas_ReturnsCorrectHorariosLivres()
        {
            var day = DateOnly.Parse("2023-01-01");
            var idMedico = 123L;
            var consultas = new List<Consulta>
            {
                new Consulta(1L, 2L, idMedico, day, new DateTime(day.Year, day.Month, day.Day, 9, 0, 0), new DateTime(day.Year, day.Month, day.Day, 9, 30, 0), true, MetodosPagamento.PIX, 100)
            };

            _mockConsultaRepository.Setup(repo => repo.GetByCrmAndDate(idMedico, day)).Returns(consultas);

            var result = _consultaService.GetHorariosLivres(day, idMedico);

            Assert.False(result.First(h => h.HoraInicio == new DateTime(day.Year, day.Month, day.Day, 9, 0, 0)).Livre);
            Assert.True(result.First(h => h.HoraInicio == new DateTime(day.Year, day.Month, day.Day, 8, 0, 0)).Livre);
        }
    }
}
