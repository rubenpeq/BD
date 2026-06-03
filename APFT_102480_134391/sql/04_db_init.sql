-- CLIENTES
INSERT INTO Cliente (Nome, Apelido, NIF, Telefone)
VALUES
('João', 'Silva', '123456789', '912345678'),
('Pedro', 'Costa', '234567890', '923456789'),
('Miguel', 'Santos', '345678901', '934567890'),
('Ricardo', 'Ferreira', '456789012', '945678901'),
('André', 'Oliveira', '567890123', '956789012');


-- BARBEIROS
INSERT INTO Barbeiro (Nome, Apelido, NIF, Telefone, Especialidade)
VALUES
('Carlos', 'Pereira', '111111111', '911111111', 'Fade e cortes modernos'),
('Bruno', 'Martins', '222222222', '922222222', 'Barba tradicional'),
('Tiago', 'Almeida', '333333333', '933333333', 'Cortes clássicos');


-- FORNECEDORES
INSERT INTO Fornecedor (Nome, NIF, Telefone)
VALUES
('Barber Supply Portugal', '444444444', '944444444'),
('Cosmetics Pro', '555555555', '955555555');


-- PRODUTOS
INSERT INTO Produto (Nome)
VALUES
('Shampoo Profissional'),
('Gel Modelador'),
('Cera Matte'),
('Lâmina de Barbear'),
('Óleo para Barba'),
('Pomada Capilar');


-- PRODUTOS DE CONSUMO
INSERT INTO Produto_consumo (ID_Produto, Stock)
VALUES
(1, 50),
(4, 200);


-- PRODUTOS DE VENDA
INSERT INTO Produto_venda (ID_Produto, Stock, Preco_unidade)
VALUES
(2, 40, 8.50),
(3, 30, 12.90),
(5, 20, 15.00),
(6, 25, 10.50);


-- SERVIÇOS
INSERT INTO Servico (Nome_Servico, Preco_base, Unidades)
VALUES
('Corte Masculino', 12.00, 1),
('Barba', 8.00, 1),
('Corte + Barba', 18.00, 1),
('Corte Premium', 20.00, 1);


-- PRODUTOS CONSUMIDOS PELOS SERVIÇOS
INSERT INTO Servico_Consome_Produto (ID_Servico, ID_Produto, Unidades)
VALUES
(1, 1, 1),
(2, 4, 1),
(3, 1, 1),
(3, 4, 1),
(4, 1, 2),
(4, 4, 1);


-- ESCALAS SEMANAIS
INSERT INTO Escala_Semanal
(ID_Barbeiro, Dia_Semana, Hora_Inicio, Hora_Fim)
VALUES
(1, 'Segunda-feira', '09:00', '18:00'),
(1, 'Terça-feira', '09:00', '18:00'),
(1, 'Quarta-feira', '09:00', '18:00'),

(2, 'Quinta-feira', '09:00', '18:00'),
(2, 'Sexta-feira', '09:00', '18:00'),
(2, 'Sábado', '09:00', '17:00'),

(3, 'Segunda-feira', '10:00', '19:00'),
(3, 'Quarta-feira', '10:00', '19:00'),
(3, 'Sexta-feira', '10:00', '19:00');


-- AGENDAMENTOS
INSERT INTO Agendamento
(ID_Cliente, Dia, Hora, Estado, Observacoes)
VALUES
(1, '2026-06-05', '10:00', 'Pendente', 'Primeira visita'),
(2, '2026-06-05', '11:00', 'Concluído', NULL),
(3, '2026-06-06', '14:00', 'Pendente', NULL);


-- SERVIÇOS DOS AGENDAMENTOS
INSERT INTO Agendamento_Servico_Barbeiro
(ID_Agendamento, ID_Servico, ID_Barbeiro, Preco_praticado)
VALUES
(1, 1, 1, 12.00),
(2, 3, 2, 18.00),
(3, 4, 3, 20.00);


-- COMPRAS DE PRODUTOS
INSERT INTO Compra_Produto_Cliente
(ID_Cliente, ID_Produto_Venda, Unidades, Preco_Unidade_Momento)
VALUES
(1, 2, 1, 12.90),
(2, 4, 2, 10.50);


-- FOLHAS DE PAGAMENTO
INSERT INTO Folha_pagamento
(ID_Barbeiro, Mes_Ano, Salario)
VALUES
(1, '2026-06-01', 1200.00),
(2, '2026-06-01', 1300.00),
(3, '2026-06-01', 1250.00);


-- DESPESAS FIXAS
INSERT INTO Despesas_fixas
(Nome_despesa, Valor, Dia_vencimento)
VALUES
('Renda do Espaço', 800.00, '2026-06-08'),
('Eletricidade', 150.00, '2026-06-10'),
('Internet', 50.00, '2026-06-15');



-- FORNECIMENTO DE PRODUTOS

INSERT INTO Fornece_Produto
(ID_Fornecedor, ID_Produto, Quantidade,
 Preco_unidade, Tipo_Stock)
VALUES
(1, 1, 100, 3.00, 'Consumo'),
(1, 4, 300, 0.50, 'Consumo'),
(2, 2, 50, 4.50, 'Venda'),
(2, 3, 40, 7.00, 'Venda');


-- MOVIMENTAÇÕES DE CAIXA

INSERT INTO Movimentacao_CAIXA
(Tipo, Valor_Real_No_Momento, Descricao, ID_Agendamento)
VALUES
('Receita', 18.00, 'Serviço concluído', 2);

INSERT INTO Movimentacao_CAIXA
(Tipo, Valor_Real_No_Momento, Descricao, ID_Compra_Produto)
VALUES
('Receita', 21.00, 'Venda de produtos', 2);

INSERT INTO Movimentacao_CAIXA
(Tipo, Valor_Real_No_Momento, Descricao, ID_folha)
VALUES
('Despesa', 1200.00, 'Pagamento salário barbeiro', 1);

INSERT INTO Movimentacao_CAIXA
(Tipo, Valor_Real_No_Momento, Descricao, ID_Despesa)
VALUES
('Despesa', 800.00, 'Pagamento renda', 1);

INSERT INTO Movimentacao_CAIXA
(Tipo, Valor_Real_No_Momento, Descricao, ID_Fornece)
VALUES
('Despesa', 300.00, 'Compra de stock consumo', 1);