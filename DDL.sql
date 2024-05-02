CREATE TABLE Agenda (
    IdAgenda INT PRIMARY KEY AUTO_INCREMENT,
    DiaSemana VARCHAR(20) NOT NULL,
    HoraInicio TIME NOT NULL,
    HoraFim TIME NOT NULL,
    CRM VARCHAR(50) NOT NULL
);

CREATE TABLE Medic (
    CRM VARCHAR(50) PRIMARY KEY,
    NomeM VARCHAR(100) NOT NULL,
    TelefoneM VARCHAR(20) NOT NULL,
    Percentual DECIMAL(5, 2) NOT NULL
);

CREATE TABLE ExerceEsp (
    CRM VARCHAR(50),
    IdEsp INT,
    FOREIGN KEY (CRM) REFERENCES Medic(CRM)
);

CREATE TABLE Especialidade (
    IdEsp INT PRIMARY KEY AUTO_INCREMENT,
    NomeEsp VARCHAR(100) NOT NULL,
    Indice INT
);

CREATE TABLE Consulta (
    IdCon INT PRIMARY KEY AUTO_INCREMENT,
    CRM VARCHAR(50),
    IdEsp INT,
    IdPac INT,
    Data DATE,
    HoraInicCon TIME,
    HoraFimCon TIME,
    Pagou BOOLEAN,
    ValorPago DECIMAL(10, 2),
    FormaPagamento VARCHAR(50),
    FOREIGN KEY (CRM) REFERENCES Medic(CRM),
    FOREIGN KEY (IdEsp) REFERENCES Especialidade(IdEsp),
    FOREIGN KEY (IdPac) REFERENCES Paciente(IdPac),
    FOREIGN KEY (Data) REFERENCES Calendario(Data)
);

CREATE TABLE Diagnostica (
    IdDiagnostica INT PRIMARY KEY AUTO_INCREMENT,
    IdDoenca INT,
    FOREIGN KEY (IdDoenca) REFERENCES Doenca(IdDoenca)
);

CREATE TABLE Doenca (
    IdDoenca INT PRIMARY KEY AUTO_INCREMENT,
    NomeDoenca VARCHAR(100) NOT NULL
);

CREATE TABLE Paciente (
    IdPac INT PRIMARY KEY AUTO_INCREMENT,
    CPF VARCHAR(11) UNIQUE NOT NULL,
    NomeP VARCHAR(100) NOT NULL,
    TelefonePac VARCHAR(20) NOT NULL,
    Endereco VARCHAR(255),
    Idade INT,
    Sexo CHAR(1)
);

CREATE TABLE Diagnostico (
    IdDiagnostico INT PRIMARY KEY AUTO_INCREMENT,
    TratamentoRecomendado TEXT,
    RemediosReceitados TEXT,
    Observacoes TEXT,
    IdCon INT,
    FOREIGN KEY (IdDiagnostico) REFERENCES Diagnostica(IdDiagnostica),
    FOREIGN KEY (IdCon) REFERENCES Consulta(IdCon)
);
