-- Inserir dados na tabela Medic
INSERT INTO Medic (CRM, NomeM, TelefoneM, Percentual) VALUES
('CRM001', 'Dr. João Silva', '123-456-7890', 70.0),
('CRM002', 'Dra. Ana Souza', '987-654-3210', 75.0),
('CRM003', 'Dr. House', '555-555-5555', 80.0),
('CRM004', 'Dra. Emily Johnson', '111-222-3333', 72.0),
('CRM005', 'Dr. Miguel Pereira', '444-444-4444', 78.0);


-- Inserir dados na tabela Especialidade
INSERT INTO Especialidade (NomeEsp, Indice) VALUES
('Clínica Geral', 1),
('Neurologia', 2),
('Cardiologia', 3),
('Dermatologia', 4),
('Oncologia', 5);


-- Inserir dados na tabela ExerceEsp
INSERT INTO ExerceEsp (CRM, IdEsp) VALUES
('CRM001', 1),
('CRM002', 2),
('CRM003', 3),
('CRM004', 4),
('CRM005', 5);


-- Inserir dados na tabela Doenca
INSERT INTO Doenca (NomeDoenca) VALUES
('Gripe'),
('Enxaqueca'),
('Hipertensão'),
('Erupção Cutânea'),
('Câncer de Mama');

-- Inserir dados na tabela Paciente
INSERT INTO Paciente (CPF, NomeP, TelefonePac, Endereco, Idade, Sexo) VALUES
('12345678901', 'João Silva', '456-789-0123', 'Rua Principal, 123', 35, 'M'),
('98765432109', 'Ana Souza', '789-012-3456', 'Rua Elm, 456', 40, 'F'),
('11122233345', 'Alice Johnson', '111-222-3333', 'Rua Carvalho, 789', 50, 'F'),
('55566677780', 'Bob Pereira', '555-666-7777', 'Rua Pinheiro, 890', 45, 'M'),
('99988877760', 'Emily Davis', '999-888-7777', 'Rua Maple, 678', 55, 'F'),
('33333333333', 'Diego Pituca', '987-654-3210', 'Rua Elm, 789', 30, 'M'),
('77777777777', 'Maria Garcia', '222-333-4444', 'Rua Carvalho, 456', 60, 'F'),
('88888888888', 'Carlos Silva', '333-444-5555', 'Rua Pinheiro, 890', 25, 'M'),
('66666666666', 'Ana Oliveira', '666-777-8888', 'Rua Maple, 678', 35, 'F'),
('44444444444', 'Pedro Santos', '444-555-6666', 'Rua Principal, 123', 70, 'M');


-- Inserir dados na tabela Consulta
INSERT INTO Consulta (CRM, IdEsp, IdPac, Data, HoraInicCon, HoraFimCon, Pagou, ValorPago, FormaPagamento) VALUES
('CRM001', 1, 1, '2024-05-10', '09:00:00', '09:30:00', TRUE, 50.00, 'Dinheiro'),
('CRM002', 2, 2, '2024-05-15', '10:00:00', '10:30:00', TRUE, 60.00, 'Cartão de Crédito'),
('CRM003', 3, 6, '2024-05-20', '11:00:00', '11:30:00', TRUE, 70.00, 'Débito'),
('CRM004', 4, 7, '2024-05-25', '12:00:00', '12:30:00', TRUE, 80.00, 'Seguro'),
('CRM005', 5, 8, '2024-05-30', '13:00:00', '13:30:00', TRUE, 90.00, 'Dinheiro'),
('CRM001', 1, 9, '2024-06-05', '09:00:00', '09:30:00', TRUE, 50.00, 'Dinheiro'),
('CRM002', 2, 10, '2024-06-10', '10:00:00', '10:30:00', TRUE, 60.00, 'Cartão de Crédito'),
('CRM003', 3, 1, '2024-06-15', '11:00:00', '11:30:00', TRUE, 70.00, 'Débito'),
('CRM004', 4, 2, '2024-06-20', '12:00:00', '12:30:00', TRUE, 80.00, 'Seguro'),
('CRM005', 5, 3, '2024-06-25', '13:00:00', '13:30:00', TRUE, 90.00, 'Dinheiro');


-- Inserir dados na tabela Diagnostica
INSERT INTO Diagnostica (IdDoenca) VALUES
(1),
(2),
(3),
(4),
(5),
(1),
(2),
(3),
(4),
(5),
(1),
(2),
(3),
(4),
(5);


-- Inserir dados na tabela Diagnostico
INSERT INTO Diagnostico (TratamentoRecomendado, RemediosReceitados, Observacoes, IdCon) VALUES
('Repouso e muitos líquidos.', 'Paracetamol', 'O paciente deve evitar esforço físico.', 1),
('Prescrição de analgésicos.', 'Ibuprofeno', 'O paciente deve monitorar os sintomas.', 2),
('Prescrição de medicamentos para pressão arterial.', 'Amlodipina', 'O paciente deve evitar alimentos salgados.', 3),
('Prescrição de creme tópico.', 'Cortisona', 'O paciente deve evitar coçar a área afetada.', 4),
('Prescrição de quimioterapia.', 'Paclitaxel', 'O paciente deve se preparar para os efeitos colaterais do tratamento.', 5),
('Repouso e muitos líquidos.', 'Paracetamol', 'O paciente deve evitar esforço físico.', 6),
('Prescrição de analgésicos.', 'Ibuprofeno', 'O paciente deve monitorar os sintomas.', 7),
('Prescrição de medicamentos para pressão arterial.', 'Amlodipina', 'O paciente deve evitar alimentos salgados.', 8),
('Prescrição de creme tópico.', 'Cortisona', 'O paciente deve evitar coçar a área afetada.', 9),
('Prescrição de quimioterapia.', 'Paclitaxel', 'O paciente deve se preparar para os efeitos colaterais do tratamento.', 10),
('Repouso e muitos líquidos.', 'Paracetamol', 'O paciente deve evitar esforço físico.', 11),
('Prescrição de analgésicos.', 'Ibuprofeno', 'O paciente deve monitorar os sintomas.', 12),
('Prescrição de medicamentos para pressão arterial.', 'Amlodipina', 'O paciente deve evitar alimentos salgados.', 13),
('Prescrição de creme tópico.', 'Cortisona', 'O paciente deve evitar coçar a área afetada.', 14),
('Prescrição de quimioterapia.', 'Paclitaxel', 'O paciente deve se preparar para os efeitos colaterais do tratamento.', 15);
