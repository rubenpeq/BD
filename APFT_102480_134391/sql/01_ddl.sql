CREATE TABLE Cliente (
    ID_Cliente      INT           IDENTITY(1,1) NOT NULL,
    Nome            VARCHAR(50)   NOT NULL,
    Apelido         VARCHAR(50)   NOT NULL,
    NIF             CHAR(9)       NULL,
    Telefone        VARCHAR(20)   NULL,
    Data_Cadastro   DATE          NULL DEFAULT GETDATE(),
    Ativo           BIT           NOT NULL DEFAULT 1,
    CONSTRAINT PK_Cliente PRIMARY KEY (ID_Cliente),
    CONSTRAINT UQ_Cliente_NIF UNIQUE (NIF)
);

CREATE TABLE Barbeiro (
    ID_Barbeiro     INT           IDENTITY(1,1) NOT NULL,
    Nome            VARCHAR(50)   NOT NULL,
    Apelido         VARCHAR(50)   NOT NULL,
    NIF             CHAR(9)       NULL,
    Telefone        VARCHAR(20)   NULL,
    Especialidade   VARCHAR(100)  NULL,
    Ativo           BIT           NOT NULL DEFAULT 1,
    CONSTRAINT PK_Barbeiro PRIMARY KEY (ID_Barbeiro),
    CONSTRAINT UQ_Barbeiro_NIF UNIQUE (NIF)
);

CREATE TABLE Fornecedor (
    ID_Fornecedor   INT           IDENTITY(1,1) NOT NULL,
    Nome            VARCHAR(100)  NOT NULL,
    NIF             CHAR(9)       NULL,
    Telefone        CHAR(9)       NULL,
    Ativo           BIT           NOT NULL DEFAULT 1,
    CONSTRAINT PK_Fornecedor PRIMARY KEY (ID_Fornecedor),
    CONSTRAINT UQ_Fornecedor_NIF UNIQUE (NIF)
);

CREATE TABLE Produto (
    ID_Produto      INT           IDENTITY(1,1) NOT NULL,
    Nome            VARCHAR(100)  NOT NULL,
    CONSTRAINT PK_Produto PRIMARY KEY (ID_Produto)
);

CREATE TABLE Produto_consumo (
    ID_Produto      INT           NOT NULL,
    Stock           INT           NULL DEFAULT 0,
    CONSTRAINT PK_Produto_consumo PRIMARY KEY (ID_Produto),
    CONSTRAINT FK_Produto_consumo_Produto FOREIGN KEY (ID_Produto)
        REFERENCES Produto (ID_Produto)
);

CREATE TABLE Produto_venda (
    ID_Produto          INT             NOT NULL,
    Stock               INT             NULL DEFAULT 0,
    Preco_unidade       DECIMAL(10,2)   NULL,
    CONSTRAINT PK_Produto_venda PRIMARY KEY (ID_Produto),
    CONSTRAINT FK_Produto_venda_Produto FOREIGN KEY (ID_Produto)
        REFERENCES Produto (ID_Produto)
);

CREATE TABLE Servico (
    ID_Servico      INT           IDENTITY(1,1) NOT NULL,
    Nome_Servico    VARCHAR(100)  NOT NULL,
    Preco_base      DECIMAL(10,2) NOT NULL,
    Unidades        INT           NULL DEFAULT 1,
    Ativo           BIT           NOT NULL DEFAULT 1,
    CONSTRAINT PK_Servico PRIMARY KEY (ID_Servico)
);

CREATE TABLE Servico_Consome_Produto (
    ID_Servico      INT   NOT NULL,
    ID_Produto      INT   NOT NULL,
    Unidades        INT   NOT NULL,
    CONSTRAINT PK_Servico_Consome_Produto PRIMARY KEY (ID_Servico, ID_Produto),
    CONSTRAINT FK_SCP_Servico FOREIGN KEY (ID_Servico)
        REFERENCES Servico (ID_Servico),
    CONSTRAINT FK_SCP_Produto FOREIGN KEY (ID_Produto)
        REFERENCES Produto_consumo (ID_Produto)
);

CREATE TABLE Agendamento (
    ID_Agendamento  INT           IDENTITY(1,1) NOT NULL,
    ID_Cliente      INT           NOT NULL,
    Dia             DATE          NOT NULL,
    Hora            TIME(7)       NOT NULL,
    Estado          VARCHAR(20)   NULL DEFAULT 'Pendente',
    Observacoes     TEXT          NULL,
    CONSTRAINT PK_Agendamento PRIMARY KEY (ID_Agendamento),
    CONSTRAINT FK_Agendamento_Cliente FOREIGN KEY (ID_Cliente)
        REFERENCES Cliente (ID_Cliente),
    CONSTRAINT CHK_Estado_Agendamento CHECK (
        Estado IN ('Pendente', 'Concluído', 'Cancelado')
    )
);

CREATE TABLE Agendamento_Servico_Barbeiro (
    ID_Agendamento      INT             NOT NULL,
    ID_Servico          INT             NOT NULL,
    ID_Barbeiro         INT             NOT NULL,
    Preco_praticado     DECIMAL(10,2)   NULL,
    CONSTRAINT PK_Agendamento_Servico_Barbeiro PRIMARY KEY (ID_Agendamento, ID_Servico, ID_Barbeiro),
    CONSTRAINT FK_ASB_Agendamento FOREIGN KEY (ID_Agendamento)
        REFERENCES Agendamento (ID_Agendamento),
    CONSTRAINT FK_ASB_Servico FOREIGN KEY (ID_Servico)
        REFERENCES Servico (ID_Servico),
    CONSTRAINT FK_ASB_Barbeiro FOREIGN KEY (ID_Barbeiro)
        REFERENCES Barbeiro (ID_Barbeiro)
);

CREATE TABLE Compra_Produto_Cliente (
    ID_Compra               INT             IDENTITY(1,1) NOT NULL,
    ID_Cliente              INT             NOT NULL,
    ID_Produto_Venda        INT             NOT NULL,
    Unidades                INT             NOT NULL,
    Preco_Unidade_Momento   DECIMAL(10,2)   NOT NULL,
    Valor_Total             AS (Unidades * Preco_Unidade_Momento),  -- coluna calculada
    Data_Hora               DATETIME        NULL DEFAULT GETDATE(),
    CONSTRAINT PK_Compra_Produto_Cliente PRIMARY KEY (ID_Compra),
    CONSTRAINT FK_CPC_Cliente FOREIGN KEY (ID_Cliente)
        REFERENCES Cliente (ID_Cliente),
    CONSTRAINT FK_CPC_Produto_venda FOREIGN KEY (ID_Produto_Venda)
        REFERENCES Produto_venda (ID_Produto)
);

CREATE TABLE Escala_Semanal (
    ID_Escala       INT           IDENTITY(1,1) NOT NULL,
    ID_Barbeiro     INT           NOT NULL,
    Dia_Semana      VARCHAR(20)   NOT NULL,
    Hora_Inicio     TIME(7)       NOT NULL,
    Hora_Fim        TIME(7)       NOT NULL,
    CONSTRAINT PK_Escala_Semanal PRIMARY KEY (ID_Escala),
    CONSTRAINT FK_Escala_Barbeiro FOREIGN KEY (ID_Barbeiro)
        REFERENCES Barbeiro (ID_Barbeiro),
    CONSTRAINT CHK_Dia_Semana CHECK (
        Dia_Semana IN ('Segunda-feira', 'Terça-feira', 'Quarta-feira',
                       'Quinta-feira', 'Sexta-feira', 'Sábado', 'Domingo')
    )
);

CREATE TABLE Folha_pagamento (
    ID_folha        INT             IDENTITY(1,1) NOT NULL,
    ID_Barbeiro     INT             NOT NULL,
    Mes_Ano         DATE            NOT NULL,
    Salario         DECIMAL(10,2)   NOT NULL,
    CONSTRAINT PK_Folha_pagamento PRIMARY KEY (ID_folha),
    CONSTRAINT FK_Folha_Barbeiro FOREIGN KEY (ID_Barbeiro)
        REFERENCES Barbeiro (ID_Barbeiro)
);

CREATE TABLE Despesas_fixas (
    ID_Despesa      INT             IDENTITY(1,1) NOT NULL,
    Nome_despesa    NVARCHAR(100)   NOT NULL,
    Valor           DECIMAL(10,2)   NOT NULL,
    Dia_vencimento  DATE            NOT NULL,
    CONSTRAINT PK_Despesas_fixas PRIMARY KEY (ID_Despesa)
);

CREATE TABLE Fornece_Produto (
    ID_Fornece      INT             IDENTITY(1,1) NOT NULL,
    ID_Fornecedor   INT             NOT NULL,
    ID_Produto      INT             NOT NULL,
    Quantidade      INT             NOT NULL,
    Preco_unidade   DECIMAL(10,2)   NOT NULL,
    Valor_compra    AS (Quantidade * Preco_unidade),  -- coluna calculada
    Data_Compra     DATE            NULL DEFAULT GETDATE(),
    Tipo_Stock      VARCHAR(10)     NOT NULL,
    CONSTRAINT PK_Fornece_Produto PRIMARY KEY (ID_Fornece),
    CONSTRAINT FK_FP_Fornecedor FOREIGN KEY (ID_Fornecedor)
        REFERENCES Fornecedor (ID_Fornecedor),
    CONSTRAINT FK_FP_Produto FOREIGN KEY (ID_Produto)
        REFERENCES Produto (ID_Produto),
    CONSTRAINT CHK_Tipo_Stock CHECK (
        Tipo_Stock IN ('Venda', 'Consumo')
    )
);

CREATE TABLE Movimentacao_CAIXA (
    ID_Mov                  INT             IDENTITY(1,1) NOT NULL,
    Tipo                    VARCHAR(20)     NOT NULL,
    Valor_Real_No_Momento   DECIMAL(10,2)   NOT NULL,
    Data_Hora               DATETIME        NULL DEFAULT GETDATE(),
    Descricao               VARCHAR(255)    NULL,
    ID_Agendamento          INT             NULL,
    ID_Compra_Produto       INT             NULL,
    ID_folha                INT             NULL,
    ID_Despesa              INT             NULL,
    ID_Fornece              INT             NULL,
    CONSTRAINT PK_Movimentacao_CAIXA PRIMARY KEY (ID_Mov),
    CONSTRAINT FK_MOV_Agendamento FOREIGN KEY (ID_Agendamento)
        REFERENCES Agendamento (ID_Agendamento),
    CONSTRAINT FK_MOV_Compra FOREIGN KEY (ID_Compra_Produto)
        REFERENCES Compra_Produto_Cliente (ID_Compra),
    CONSTRAINT FK_MOV_Folha FOREIGN KEY (ID_folha)
        REFERENCES Folha_pagamento (ID_folha),
    CONSTRAINT FK_MOV_Despesa FOREIGN KEY (ID_Despesa)
        REFERENCES Despesas_fixas (ID_Despesa),
    CONSTRAINT FK_MOV_Fornece FOREIGN KEY (ID_Fornece)
        REFERENCES Fornece_Produto (ID_Fornece),
    CONSTRAINT CHK_Tipo_Movimentacao CHECK (
        Tipo IN ('Receita', 'Despesa')
    )
);