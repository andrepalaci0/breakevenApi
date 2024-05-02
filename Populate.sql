-- Insert data into Agenda table
INSERT INTO Agenda (DiaSemana, HoraInicio, HoraFim, CRM) VALUES
('Segunda', '08:00:00', '12:00:00', 'CRM001'),
('Terça', '09:00:00', '13:00:00', 'CRM002'),
('Quarta', '10:00:00', '14:00:00', 'CRM003');

-- Insert data into Medic table
INSERT INTO Medic (CRM, NomeM, TelefoneM, Percentual) VALUES
('CRM001', 'Dr. House', '123-456-7890', 70.0),
('CRM002', 'Dr. Kildare', '234-567-8901', 75.0),
('CRM003', 'Dr. Smith', '345-678-9012', 80.0);

-- Insert data into ExerceEsp table
INSERT INTO ExerceEsp (CRM, IdEsp) VALUES
('CRM001', 1),
('CRM002', 2),
('CRM003', 3);

-- Insert data into Especialidade table
INSERT INTO Especialidade (NomeEsp, Indice) VALUES
('Dermatologia', 1),
('Cardiologia', 2),
('Ortopedia', 3);

-- Insert data into Consulta table
INSERT INTO Consulta (CRM, IdEsp, IdPac, Data, HoraInicCon, HoraFimCon, Pagou, ValorPago, FormaPagamento) VALUES
('CRM001', 1, 1, '2024-05-10', '10:00:00', '11:00:00', TRUE, 100.00, 'Cartão'),
('CRM002', 2, 2, '2024-05-15', '11:00:00', '12:00:00', TRUE, 120.00, 'Dinheiro'),
('CRM003', 3, 3, '2024-05-20', '12:00:00', '13:00:00', TRUE, 150.00, 'Transferência');

-- Insert data into Diagnostica table
INSERT INTO Diagnostica (IdDoenca) VALUES
(1),
(2),
(3);

-- Insert data into Doenca table
INSERT INTO Doenca (NomeDoenca) VALUES
('Doença1'),
('Doença2'),
('Doença3');

-- Insert data into Paciente table
INSERT INTO Paciente (CPF, NomeP, TelefonePac, Endereco, Idade, Sexo) VALUES
('12345678901', 'Diego Pituca', '456-789-0123', '123 Street, City', 30, 'M'),
('23456789012', 'Maria Silva', '567-890-1234', '456 Avenue, Town', 35, 'F'),
('34567890123', 'João Santos', '678-901-2345', '789 Road, Village', 40, 'M');
