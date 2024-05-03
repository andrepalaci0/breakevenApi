INSERT INTO Especialidade (NomeEsp, Indice) VALUES
('Clínica Geral', 1),
('Neurologia', 2),
('Cardiologia', 3),
('Dermatologia', 4),
('Oncologia', 5),
('Pediatria', 6),
('Dermatologia', 7);

INSERT INTO Medic (CRM, NomeM, TelefoneM, Percentual) VALUES
('CRM001', 'Dr. João Silva', '123-456-7890', 70.0),
('CRM002', 'Dra. Ana Souza', '987-654-3210', 75.0),
('CRM003', 'Dr. House', '555-555-5555', 80.0),  -- Dr. House included
('CRM004', 'Dra. Emily Johnson', '111-222-3333', 72.0),
('CRM005', 'Dr. Miguel Pereira', '444-444-4444', 78.0),
('CRM006', 'Dr. Kildare', '123-456-7890', 85.0);

INSERT INTO Paciente (CPF, NomeP, TelefonePac, Endereco, Idade, Sexo) VALUES
('12345678901', 'João Silva', '456-789-0123', 'Rua Principal, 123', 35, 'M'),
('98765432109', 'Ana Souza', '789-012-3456', 'Rua Elm, 456', 40, 'F'),
('11122233345', 'Alice Johnson', '111-222-3333', 'Rua Carvalho, 789', 50, 'F'),
('55566677780', 'Bob Pereira', '555-666-7777', 'Rua Pinheiro, 890', 45, 'M'),
('99988877760', 'Emily Davis', '999-888-7777', 'Rua Maple, 678', 55, 'F'),
('33333333333', 'Diego Pituca', '987-654-3210', 'Rua Elm, 789', 30, 'M'),  -- Diego Pituca included
('77777777777', 'Maria Garcia', '222-333-4444', 'Rua Carvalho, 456', 60, 'F'),
('88888888888', 'Carlos Silva', '333-444-5555', 'Rua Pinheiro, 890', 25, 'M'),
('66666666666', 'Ana Oliveira', '666-777-8888', 'Rua Maple, 678', 35, 'F'),
('44444444444', 'Pedro Santos', '444-555-6666', 'Rua Principal, 123', 70, 'M');

INSERT INTO Doenca (NomeDoenca) VALUES
('Gripe'),
('Enxaqueca'),
('Hipertensão'),
('Erupção Cutânea'),
('Câncer de Mama');

INSERT INTO ExerceEsp (CRM, IdEsp) VALUES
('CRM001', 2),  -- Dr. João Silva - Clínica Geral
('CRM002', 2),  -- Dra. Ana Souza - Neurologia
('CRM003', 3),  -- Dr. House - Cardiologia (assigned here)
('CRM004', 4),  -- Dra. Emily Johnson - Dermatologia
('CRM004', 7),
('CRM001', 7),
('CRM005', 5),
('CRM006', 4),  -- Dermatology
('CRM006', 6);

INSERT INTO Consulta (CRM, IdEsp, IdPac, Data, HoraInicCon)
VALUES ('CRM003', -- Dr. House's CRM (assuming you assigned it earlier)
        3,        -- Assuming 'IdEsp' is 3 for Cardiology (modify if different)
        -- Find Diego Pituca's IdPac (replace with actual ID if known)
        (SELECT IdPac FROM Paciente WHERE NomeP = 'Diego Pituca'),
        '2024-05-06', -- Date of consultation
        '10:00:00'); -- Time of consultation (modify if needed)


 



