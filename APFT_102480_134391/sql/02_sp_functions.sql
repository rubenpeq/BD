-- FormMenu

CREATE PROCEDURE sp_Dashboard_GetAgendamentos
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        A.ID_Agendamento,
        C.Nome AS [Nome Cliente],
        B.Nome AS [Nome Barbeiro],
        A.Dia AS [Data],
        A.Hora AS [Horário],
        SUM(ASB.Preco_praticado) AS [Valor Total],
        A.Estado AS [Estado]
    FROM dbo.Agendamento A
    INNER JOIN dbo.Cliente C ON A.ID_Cliente = C.ID_Cliente
    INNER JOIN dbo.Agendamento_Servico_Barbeiro ASB ON A.ID_Agendamento = ASB.ID_Agendamento
    INNER JOIN dbo.Barbeiro B ON ASB.ID_Barbeiro = B.ID_Barbeiro
    GROUP BY A.ID_Agendamento, C.Nome, B.Nome, A.Dia, A.Hora, A.Estado
    ORDER BY A.Dia DESC, A.Hora ASC;
END

CREATE PROCEDURE sp_Agendamento_UpdateEstado
    @ID_Agendamento INT,
    @NovoEstado NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRANSACTION;
    
    BEGIN TRY
        -- verificar se o agendamento existe
        IF NOT EXISTS (SELECT 1 FROM dbo.Agendamento WHERE ID_Agendamento = @ID_Agendamento)
        BEGIN
            RAISERROR('Agendamento não encontrado.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Actualização do estado
        UPDATE dbo.Agendamento
        SET Estado = @NovoEstado
        WHERE ID_Agendamento = @ID_Agendamento;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;  -- manda erro para a aplicação
    END CATCH
END

-- Form1

CREATE PROCEDURE sp_Clientes_GetActive
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT ID_Cliente, Nome, Apelido, NIF, Telefone, Data_Cadastro
    FROM dbo.Cliente
    WHERE Ativo = 1
    ORDER BY Nome, Apelido;
END

CREATE PROCEDURE sp_Cliente_Insert
    @Nome NVARCHAR(100),
    @Apelido NVARCHAR(100),
    @NIF NVARCHAR(20) = NULL,
    @Telefone NVARCHAR(20) = NULL,
    @DataCadastro DATE
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRANSACTION;
    
    BEGIN TRY
        INSERT INTO dbo.Cliente (Nome, Apelido, NIF, Telefone, Data_Cadastro, Ativo)
        VALUES (@Nome, @Apelido, @NIF, @Telefone, @DataCadastro, 1);
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END

-- Form_Despesas_Fixas

CREATE PROCEDURE sp_DespesasFixas_GetAll
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT ID_Despesa, Nome_despesa, Valor, Dia_vencimento
    FROM dbo.Despesas_fixas
    ORDER BY Dia_vencimento, Nome_despesa;
END

CREATE PROCEDURE sp_DespesasFixas_Insert
    @NomeDespesa NVARCHAR(100),
    @Valor DECIMAL(10,2),
    @DiaVencimento DATE
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRANSACTION;
    
    BEGIN TRY
        INSERT INTO dbo.Despesas_fixas (Nome_despesa, Valor, Dia_vencimento)
        VALUES (@NomeDespesa, @Valor, @DiaVencimento);
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END

CREATE PROCEDURE sp_DespesasFixas_Delete
    @ID_Despesa INT
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRANSACTION;
    
    BEGIN TRY
        -- Verifica se a despesa existe
        IF NOT EXISTS (SELECT 1 FROM dbo.Despesas_fixas WHERE ID_Despesa = @ID_Despesa)
        BEGIN
            RAISERROR('Despesa não encontrada.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END
        
        DELETE FROM dbo.Despesas_fixas
        WHERE ID_Despesa = @ID_Despesa;
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;	-- erro para a app
    END CATCH
END

-- Form_Folha_Pagamento

CREATE PROCEDURE sp_Barbeiros_GetActive
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ID_Barbeiro, Nome, Apelido
    FROM dbo.Barbeiro
    WHERE Ativo = 1
    ORDER BY Nome, Apelido;
END

CREATE PROCEDURE sp_FolhaPagamento_GetAll
AS
BEGIN
    SET NOCOUNT ON;
    SELECT F.ID_folha, B.Nome, F.Mes_Ano, F.Salario
    FROM dbo.Folha_pagamento F
    INNER JOIN dbo.Barbeiro B ON F.ID_Barbeiro = B.ID_Barbeiro
    ORDER BY F.Mes_Ano DESC, B.Nome;
END

CREATE PROCEDURE sp_FolhaPagamento_Insert
    @ID_Barbeiro INT,
    @Mes_Ano DATE,
    @Salario DECIMAL(10,2)
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRANSACTION;
    
    BEGIN TRY
        -- 1. Inserir na tabela Folha_pagamento
        DECLARE @ID_folha INT;
        
        INSERT INTO dbo.Folha_pagamento (ID_Barbeiro, Mes_Ano, Salario)
        VALUES (@ID_Barbeiro, @Mes_Ano, @Salario);
        
        SET @ID_folha = SCOPE_IDENTITY();
        
        -- 2. Inserir movimentação de caixa (despesa)
        DECLARE @Descricao NVARCHAR(255);
        DECLARE @NomeBarbeiro NVARCHAR(100);
        
        SELECT @NomeBarbeiro = Nome + ' ' + Apelido
        FROM dbo.Barbeiro
        WHERE ID_Barbeiro = @ID_Barbeiro;
        
        SET @Descricao = 'Pagamento de salário - Barbeiro ' + ISNULL(@NomeBarbeiro, 'ID ' + CAST(@ID_Barbeiro AS VARCHAR));
        
        INSERT INTO dbo.Movimentacao_CAIXA (Tipo, Valor_Real_No_Momento, Data_Hora, Descricao, ID_folha)
        VALUES ('Despesa', @Salario, GETDATE(), @Descricao, @ID_folha);
        
        COMMIT TRANSACTION;
        
        -- Retorna o ID da nova folha
        SELECT @ID_folha AS ID_folha;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END

-- FormAgendamento

CREATE PROCEDURE sp_Servicos_GetActive
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ID_Servico, Nome_Servico, Preco_base
    FROM dbo.Servico
    WHERE Ativo = 1
    ORDER BY Nome_Servico;
END

CREATE PROCEDURE sp_Barbeiros_GetByDiaSemana
    @DiaSemana NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT DISTINCT B.ID_Barbeiro, B.Nome
    FROM dbo.Barbeiro B
    INNER JOIN dbo.Escala_Semanal E ON B.ID_Barbeiro = E.ID_Barbeiro
    WHERE B.Ativo = 1 AND E.Dia_Semana = @DiaSemana
    ORDER BY B.Nome;
END

CREATE PROCEDURE sp_Escala_GetHorario
    @ID_Barbeiro INT,
    @DiaSemana NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Hora_Inicio, Hora_Fim
    FROM dbo.Escala_Semanal
    WHERE ID_Barbeiro = @ID_Barbeiro AND Dia_Semana = @DiaSemana;
END

CREATE PROCEDURE sp_Agendamento_InsertCabecalho
    @ID_Cliente INT,
    @Dia DATE,
    @Hora TIME(7),
    @Estado NVARCHAR(20),
    @Observacoes NVARCHAR(MAX) = NULL,
    @ID_Agendamento INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO dbo.Agendamento (ID_Cliente, Dia, Hora, Estado, Observacoes)
    VALUES (@ID_Cliente, @Dia, @Hora, @Estado, @Observacoes);
    
    SET @ID_Agendamento = SCOPE_IDENTITY();
END

CREATE PROCEDURE sp_Agendamento_InsertServico
    @ID_Agendamento INT,
    @ID_Servico INT,
    @ID_Barbeiro INT,
    @Preco_Praticado DECIMAL(10,2)
AS
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO dbo.Agendamento_Servico_Barbeiro (ID_Agendamento, ID_Servico, ID_Barbeiro, Preco_praticado)
    VALUES (@ID_Agendamento, @ID_Servico, @ID_Barbeiro, @Preco_Praticado);
END

-- FormBarbeiro

CREATE PROCEDURE sp_Barbeiros_GetActive
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ID_Barbeiro, Nome, Apelido, NIF, Telefone, Especialidade
    FROM dbo.Barbeiro
    WHERE Ativo = 1
    ORDER BY Nome, Apelido;
END

CREATE PROCEDURE sp_Escala_GetByBarbeiro
    @ID_Barbeiro INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Dia_Semana, Hora_Inicio, Hora_Fim
    FROM dbo.Escala_Semanal
    WHERE ID_Barbeiro = @ID_Barbeiro
    ORDER BY CASE Dia_Semana 
        WHEN 'Segunda-feira' THEN 1 
        WHEN 'Terça-feira' THEN 2 
        WHEN 'Quarta-feira' THEN 3 
        WHEN 'Quinta-feira' THEN 4 
        WHEN 'Sexta-feira' THEN 5 
        WHEN 'Sábado' THEN 6 
        ELSE 7 END;
END

CREATE PROCEDURE sp_Barbeiro_Insert
    @Nome VARCHAR(50),
    @Apelido VARCHAR(50),
    @NIF CHAR(9) = NULL,
    @Telefone VARCHAR(20) = NULL,
    @Especialidade VARCHAR(100) = NULL,
    @NovoID INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO dbo.Barbeiro (Nome, Apelido, NIF, Telefone, Especialidade, Ativo)
    VALUES (@Nome, @Apelido, @NIF, @Telefone, @Especialidade, 1);
    
    SET @NovoID = SCOPE_IDENTITY();
END

CREATE PROCEDURE sp_Escala_Insert
    @ID_Barbeiro INT,
    @DiaSemana VARCHAR(20),
    @HoraInicio TIME,
    @HoraFim TIME
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.Escala_Semanal (ID_Barbeiro, Dia_Semana, Hora_Inicio, Hora_Fim)
    VALUES (@ID_Barbeiro, @DiaSemana, @HoraInicio, @HoraFim);
END

CREATE PROCEDURE sp_Barbeiro_Update
    @ID_Barbeiro INT,
    @Nome VARCHAR(50),
    @Apelido VARCHAR(50),
    @NIF CHAR(9) = NULL,
    @Telefone VARCHAR(20) = NULL,
    @Especialidade VARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE dbo.Barbeiro
    SET Nome = @Nome,
        Apelido = @Apelido,
        NIF = @NIF,
        Telefone = @Telefone,
        Especialidade = @Especialidade
    WHERE ID_Barbeiro = @ID_Barbeiro;
END

CREATE PROCEDURE sp_Barbeiro_SoftDelete
    @ID_Barbeiro INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.Barbeiro SET Ativo = 0 WHERE ID_Barbeiro = @ID_Barbeiro;
END

--FormFornecedor

CREATE PROCEDURE sp_Fornecedores_GetActive
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ID_Fornecedor, Nome, NIF, Telefone
    FROM dbo.Fornecedor
    WHERE Ativo = 1
    ORDER BY Nome;
END

CREATE PROCEDURE sp_Fornecedor_Insert
    @Nome VARCHAR(100),
    @NIF CHAR(9) = NULL,
    @Telefone VARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.Fornecedor (Nome, NIF, Telefone, Ativo)
    VALUES (@Nome, @NIF, @Telefone, 1);
END

CREATE PROCEDURE sp_Fornecedor_SoftDelete
    @ID_Fornecedor INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.Fornecedor
    SET Ativo = 0
    WHERE ID_Fornecedor = @ID_Fornecedor;
END

-- FormMovimentacao

CREATE PROCEDURE sp_Movimentacao_GetSaldo
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        ISNULL(SUM(CASE WHEN Tipo = 'Receita' THEN Valor_Real_No_Momento ELSE 0 END), 0) - 
        ISNULL(SUM(CASE WHEN Tipo = 'Despesa' THEN Valor_Real_No_Momento ELSE 0 END), 0) AS SaldoAtual
    FROM dbo.Movimentacao_CAIXA;
END

CREATE PROCEDURE sp_Movimentacao_GetFiltered
    @DataInicio DATETIME,
    @DataFim DATETIME,
    @Tipo VARCHAR(20) = NULL,
    @Subtipo VARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        Tipo, 
        Valor_Real_No_Momento AS [Valor (€)], 
        Data_Hora AS [Data/Hora], 
        Descricao AS [Descrição]
    FROM dbo.Movimentacao_CAIXA
    WHERE Data_Hora >= @DataInicio 
      AND Data_Hora <= @DataFim
      AND (@Tipo IS NULL OR LTRIM(RTRIM(Tipo)) = @Tipo)
      AND (@Subtipo IS NULL OR Descricao LIKE '%' + @Subtipo + '%')
    ORDER BY Data_Hora DESC;
END

-- FormServico

CREATE PROCEDURE sp_Servicos_GetActive
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ID_Servico, Nome_Servico, Preco_base, Unidades
    FROM dbo.Servico
    WHERE Ativo = 1
    ORDER BY Nome_Servico;
END

CREATE PROCEDURE sp_Produtos_GetConsumo
AS
BEGIN
    SET NOCOUNT ON;
    SELECT P.ID_Produto, P.Nome
    FROM dbo.Produto P
    INNER JOIN dbo.Produto_consumo PC ON P.ID_Produto = PC.ID_Produto
    ORDER BY P.Nome;
END

CREATE PROCEDURE sp_Servico_Insert
    @Nome_Servico VARCHAR(100),
    @Preco_base DECIMAL(10,2),
    @Unidades INT = NULL,
    @ID_Servico INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.Servico (Nome_Servico, Preco_base, Unidades, Ativo)
    VALUES (@Nome_Servico, @Preco_base, @Unidades, 1);
    SET @ID_Servico = SCOPE_IDENTITY();
END

CREATE PROCEDURE sp_Servico_Consumo_Insert
    @ID_Servico INT,
    @ID_Produto INT,
    @Unidades INT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.Servico_Consome_Produto (ID_Servico, ID_Produto, Unidades)
    VALUES (@ID_Servico, @ID_Produto, @Unidades);
END

CREATE PROCEDURE sp_Servico_SoftDelete
    @ID_Servico INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.Servico SET Ativo = 0 WHERE ID_Servico = @ID_Servico;
END

--FormStock

CREATE PROCEDURE sp_Stock_GetConsumo
AS
BEGIN
    SET NOCOUNT ON;
    SELECT P.ID_Produto, P.Nome, PC.Stock
    FROM dbo.Produto P
    INNER JOIN dbo.Produto_consumo PC ON P.ID_Produto = PC.ID_Produto
    ORDER BY P.Nome;
END

CREATE PROCEDURE sp_Stock_GetVenda
AS
BEGIN
    SET NOCOUNT ON;
    SELECT P.ID_Produto, P.Nome, PV.Stock
    FROM dbo.Produto P
    INNER JOIN dbo.Produto_venda PV ON P.ID_Produto = PV.ID_Produto
    ORDER BY P.Nome;
END

CREATE PROCEDURE sp_Fornecedores_GetActive
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ID_Fornecedor, Nome
    FROM dbo.Fornecedor
    WHERE Ativo = 1
    ORDER BY Nome;
END

CREATE PROCEDURE sp_Produtos_GetAll
AS
BEGIN
    SET NOCOUNT ON;
    SELECT DISTINCT ID_Produto, Nome
    FROM dbo.Produto
    ORDER BY Nome;
END

CREATE OR ALTER PROCEDURE sp_Produto_Insert
    @Nome VARCHAR(100),
    @ID_Produto INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.Produto (Nome) VALUES (@Nome);
    SET @ID_Produto = SCOPE_IDENTITY();
END

CREATE OR ALTER PROCEDURE sp_Fornecimento_Registrar
    @ID_Fornecedor INT,
    @ID_Produto INT = NULL,
    @NomeProduto VARCHAR(100) = NULL,
    @Quantidade INT,
    @PrecoUnidade DECIMAL(10,2),
    @TipoStock VARCHAR(10),
    @PrecoVenda DECIMAL(10,2) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;
    BEGIN TRY
        DECLARE @ID_ProdutoFinal INT = @ID_Produto;

        IF @ID_ProdutoFinal IS NULL
        BEGIN
            INSERT INTO dbo.Produto (Nome) VALUES (@NomeProduto);
            SET @ID_ProdutoFinal = SCOPE_IDENTITY();
        END

        IF @TipoStock = 'Consumo'
        BEGIN
            IF NOT EXISTS (SELECT 1 FROM dbo.Produto_consumo WHERE ID_Produto = @ID_ProdutoFinal)
                INSERT INTO dbo.Produto_consumo (ID_Produto, Stock) VALUES (@ID_ProdutoFinal, 0);
        END
        ELSE
        BEGIN
            IF NOT EXISTS (SELECT 1 FROM dbo.Produto_venda WHERE ID_Produto = @ID_ProdutoFinal)
                INSERT INTO dbo.Produto_venda (ID_Produto, Stock, Preco_unidade) VALUES (@ID_ProdutoFinal, 0, 0);
            
            IF @PrecoVenda IS NOT NULL
                UPDATE dbo.Produto_venda SET Preco_unidade = @PrecoVenda WHERE ID_Produto = @ID_ProdutoFinal;
        END

        INSERT INTO dbo.Fornece_Produto (ID_Fornecedor, ID_Produto, Quantidade, Preco_unidade, Data_Compra, Tipo_Stock)
        VALUES (@ID_Fornecedor, @ID_ProdutoFinal, @Quantidade, @PrecoUnidade, GETDATE(), @TipoStock);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END

--FormVenda

CREATE PROCEDURE sp_Clientes_GetActiveForVenda
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ID_Cliente, Nome + ' ' + Apelido AS NomeCompleto
    FROM dbo.Cliente
    WHERE Ativo = 1
    ORDER BY Nome, Apelido;
END

CREATE PROCEDURE sp_ProdutosVenda_GetWithStock
AS
BEGIN
    SET NOCOUNT ON;
    SELECT pv.ID_Produto, p.Nome
    FROM dbo.Produto_venda pv
    INNER JOIN dbo.Produto p ON pv.ID_Produto = p.ID_Produto
    WHERE pv.Stock > 0
    ORDER BY p.Nome;
END

CREATE PROCEDURE sp_ProdutoVenda_GetStockAndPrice
    @ID_Produto INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Stock, Preco_unidade
    FROM dbo.Produto_venda
    WHERE ID_Produto = @ID_Produto;
END

CREATE PROCEDURE sp_Venda_InsertItem
    @ID_Cliente INT,
    @ID_Produto_Venda INT,
    @Unidades INT,
    @Preco_Unidade_Momento DECIMAL(10,2)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.Compra_Produto_Cliente (ID_Cliente, ID_Produto_Venda, Unidades, Data_Hora, Preco_Unidade_Momento)
    VALUES (@ID_Cliente, @ID_Produto_Venda, @Unidades, GETDATE(), @Preco_Unidade_Momento);
END