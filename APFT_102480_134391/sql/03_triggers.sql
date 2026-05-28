-- =============================================
-- TABELA: Agendamento
-- =============================================

-- Trigger 1/3: Baixa no stock ao concluir agendamento
CREATE TRIGGER TRG_Consome_Produto_No_Servico
ON dbo.Agendamento
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1 
        FROM inserted i
        INNER JOIN deleted d ON i.ID_Agendamento = d.ID_Agendamento
        WHERE i.Estado = 'Concluído' AND d.Estado <> 'Concluído'
    )
    BEGIN
        UPDATE PC
        SET PC.Stock = PC.Stock - SCP.Unidades
        FROM dbo.Produto_consumo PC
        INNER JOIN dbo.Servico_Consome_Produto SCP ON PC.ID_Produto = SCP.ID_Produto
        INNER JOIN dbo.Agendamento_Servico_Barbeiro ASB ON SCP.ID_Servico = ASB.ID_Servico
        INNER JOIN inserted i ON ASB.ID_Agendamento = i.ID_Agendamento
        INNER JOIN deleted d ON i.ID_Agendamento = d.ID_Agendamento
        WHERE i.Estado = 'Concluído' AND d.Estado <> 'Concluído';
    END
END;
GO


-- Trigger 2/3: Registo de receita no caixa ao concluir agendamento
CREATE TRIGGER TRG_Fatura_Servico_Caixa
ON dbo.Agendamento
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1 FROM inserted i 
        INNER JOIN deleted d ON i.ID_Agendamento = d.ID_Agendamento
        WHERE i.Estado = 'Concluído' AND d.Estado <> 'Concluído'
    )
    BEGIN
        INSERT INTO dbo.Movimentacao_CAIXA (Tipo, Valor_Real_No_Momento, Descricao, ID_Agendamento)
        SELECT 
            'Receita',
            SUM(ASB.Preco_praticado),
            'Serviço(s) prestado(s) no agendamento nº ' + CAST(i.ID_Agendamento AS VARCHAR),
            i.ID_Agendamento
        FROM inserted i
        INNER JOIN dbo.Agendamento_Servico_Barbeiro ASB ON i.ID_Agendamento = ASB.ID_Agendamento
        WHERE i.Estado = 'Concluído'
        GROUP BY i.ID_Agendamento;
    END
END;
GO


-- Trigger 3/3: Estorno de stock e caixa ao cancelar agendamento concluído
CREATE TRIGGER TRG_Cancelamento_Agendamento
ON dbo.Agendamento
AFTER UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1 FROM inserted i
        INNER JOIN deleted d ON i.ID_Agendamento = d.ID_Agendamento
        WHERE d.Estado = 'Concluído' AND i.Estado <> 'Concluído'
    )
    BEGIN
        -- Devolve produtos ao stock de consumo
        UPDATE PC
        SET PC.Stock = PC.Stock + SCP.Unidades
        FROM dbo.Produto_consumo PC
        INNER JOIN dbo.Servico_Consome_Produto SCP ON PC.ID_Produto = SCP.ID_Produto
        INNER JOIN dbo.Agendamento_Servico_Barbeiro ASB ON SCP.ID_Servico = ASB.ID_Servico
        INNER JOIN inserted i ON ASB.ID_Agendamento = i.ID_Agendamento
        INNER JOIN deleted d ON i.ID_Agendamento = d.ID_Agendamento
        WHERE d.Estado = 'Concluído' AND i.Estado <> 'Concluído';

        -- Regista estorno no caixa
        INSERT INTO dbo.Movimentacao_CAIXA (Tipo, Valor_Real_No_Momento, Descricao, ID_Agendamento)
        SELECT 
            'Despesa',
            SUM(ASB.Preco_praticado),
            'Estorno por Cancelamento de Agendamento nº ' + CAST(d.ID_Agendamento AS VARCHAR),
            d.ID_Agendamento
        FROM deleted d
        INNER JOIN dbo.Agendamento_Servico_Barbeiro ASB ON d.ID_Agendamento = ASB.ID_Agendamento
        INNER JOIN inserted i ON d.ID_Agendamento = i.ID_Agendamento
        WHERE d.Estado = 'Concluído' AND i.Estado <> 'Concluído'
        GROUP BY d.ID_Agendamento;
    END
END;
GO


-- =============================================
-- TABELA: Compra_Produto_Cliente
-- =============================================

-- Trigger 1/2: Baixa no stock e receita no caixa ao registar venda
CREATE TRIGGER TRG_Venda_Produto_Cliente
ON dbo.Compra_Produto_Cliente
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- Baixa no stock de venda
    UPDATE PV
    SET PV.Stock = PV.Stock - i.Unidades
    FROM dbo.Produto_venda PV
    INNER JOIN inserted i ON PV.ID_Produto = i.ID_Produto_Venda;

    -- Regista receita no caixa
    INSERT INTO dbo.Movimentacao_CAIXA (Tipo, Valor_Real_No_Momento, Descricao, ID_Compra_Produto)
    SELECT 
        'Receita', 
        i.Valor_Total, 
        'Venda ao Cliente ID: ' + CAST(i.ID_Cliente AS VARCHAR),
        i.ID_Compra
    FROM inserted i;
END;
GO


-- Trigger 2/2: Devolução de stock e estorno no caixa ao eliminar venda
CREATE TRIGGER TRG_Elimina_Venda_Cliente
ON dbo.Compra_Produto_Cliente
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- Devolve unidades ao stock de venda
    UPDATE PV
    SET PV.Stock = PV.Stock + d.Unidades
    FROM dbo.Produto_venda PV
    INNER JOIN deleted d ON PV.ID_Produto = d.ID_Produto_Venda;

    -- Regista estorno no caixa
    INSERT INTO dbo.Movimentacao_CAIXA (Tipo, Valor_Real_No_Momento, Descricao, ID_Compra_Produto)
    SELECT 
        'Despesa', 
        d.Valor_Total,
        'Estorno: Eliminação da Venda ID nº ' + CAST(d.ID_Compra AS VARCHAR),
        d.ID_Compra
    FROM deleted d;
END;
GO


-- =============================================
-- TABELA: Despesas_fixas
-- =============================================

-- Trigger 1/2: Registo de despesa no caixa ao inserir despesa fixa
CREATE TRIGGER TRG_Registrar_Despesa_No_Caixa
ON dbo.Despesas_fixas
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.Movimentacao_CAIXA (Tipo, Valor_Real_No_Momento, Descricao, ID_Despesa)
    SELECT 
        'Despesa', 
        i.Valor, 
        'Despesa Fixa: ' + i.Nome_despesa,
        i.ID_Despesa
    FROM inserted i;
END;
GO


-- Trigger 2/2: Estorno no caixa ao eliminar despesa fixa
CREATE TRIGGER TRG_Estornar_Despesa_No_Caixa
ON dbo.Despesas_fixas
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.Movimentacao_CAIXA (Tipo, Valor_Real_No_Momento, Descricao, Data_Hora)
    SELECT 
        'Receita',
        d.Valor, 
        'Estorno de Despesa: ' + d.Nome_despesa,
        GETDATE()
    FROM deleted d;
END;
GO


-- =============================================
-- TABELA: Folha_pagamento
-- =============================================

-- Trigger 1/1: Registo de salário no caixa ao lançar folha de pagamento
CREATE TRIGGER TRG_Folha_Pagamento_Caixa
ON dbo.Folha_pagamento
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.Movimentacao_CAIXA (Tipo, Valor_Real_No_Momento, Descricao, ID_folha)
    SELECT 
        'Despesa', 
        i.Salario,
        'Pagamento de salário - Barbeiro ID: ' + CAST(i.ID_Barbeiro AS VARCHAR) + 
        ' (Mês/Ano: ' + FORMAT(i.Mes_Ano, 'MM/yyyy') + ')',
        i.ID_folha
    FROM inserted i;
END;
GO


-- =============================================
-- TABELA: Fornece_Produto
-- =============================================

-- Trigger 1/2: Atualização de stock e despesa no caixa ao registar fornecimento
CREATE TRIGGER TRG_Atualiza_Stock_Fornecimento
ON dbo.Fornece_Produto
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- Regista despesa no caixa
    INSERT INTO dbo.Movimentacao_CAIXA (Tipo, Valor_Real_No_Momento, Descricao, ID_Fornece)
    SELECT 
        'Despesa', 
        i.Preco_unidade * i.Quantidade, 
        'Compra de produto (Fornecedor ID: ' + CAST(i.ID_Fornecedor AS VARCHAR) + ')', 
        i.ID_Fornece
    FROM inserted i;

    -- Atualiza stock de venda
    UPDATE PV
    SET PV.Stock = PV.Stock + i.Quantidade
    FROM dbo.Produto_venda PV
    INNER JOIN inserted i ON PV.ID_Produto = i.ID_Produto
    WHERE i.Tipo_Stock = 'Venda';

    -- Atualiza stock de consumo
    UPDATE PC
    SET PC.Stock = PC.Stock + i.Quantidade
    FROM dbo.Produto_consumo PC
    INNER JOIN inserted i ON PC.ID_Produto = i.ID_Produto
    WHERE i.Tipo_Stock = 'Consumo';
END;
GO


-- Trigger 2/2: Devolução de stock e estorno no caixa ao eliminar fornecimento
CREATE TRIGGER TRG_Elimina_Fornecimento
ON dbo.Fornece_Produto
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- Subtrai stock de venda
    UPDATE PV
    SET PV.Stock = PV.Stock - d.Quantidade
    FROM dbo.Produto_venda PV
    INNER JOIN deleted d ON PV.ID_Produto = d.ID_Produto
    WHERE d.Tipo_Stock = 'Venda';

    -- Subtrai stock de consumo
    UPDATE PC
    SET PC.Stock = PC.Stock - d.Quantidade
    FROM dbo.Produto_consumo PC
    INNER JOIN deleted d ON PC.ID_Produto = d.ID_Produto
    WHERE d.Tipo_Stock = 'Consumo';

    -- Regista estorno no caixa
    INSERT INTO dbo.Movimentacao_CAIXA (Tipo, Valor_Real_No_Momento, Descricao, ID_Fornece)
    SELECT 
        'Receita',
        d.Valor_compra,
        'Estorno/Devolução: Compra eliminada (ID Fornece: ' + CAST(d.ID_Fornece AS VARCHAR) + ')',
        d.ID_Fornece
    FROM deleted d;
END;
GO