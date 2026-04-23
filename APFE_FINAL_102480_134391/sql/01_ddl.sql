CREATE TABLE Cliente (
    Cadastro      int NOT NULL,
    Nome          varchar(100) NOT NULL,
    Apelido       varchar(100),
    No_tel        varchar(15),
    NIF           varchar(9),
    PRIMARY KEY (Cadastro),
    UNIQUE (NIF)
);

CREATE TABLE Barbeiro (
    ID_Barbeiro   int NOT NULL,
    Nome          varchar(100) NOT NULL,
    Apelido       varchar(100),
    Especialidade varchar(100),
    NIF           varchar(9),
    No_tel        varchar(15),
    PRIMARY KEY (ID_Barbeiro),
    UNIQUE (NIF)
);

CREATE TABLE Servico (
    ID_Servico    int NOT NULL,
    Nome_Servico  varchar(120) NOT NULL,
    Unidades      int NOT NULL,
    Preco_base    numeric(10,2) NOT NULL,
    PRIMARY KEY (ID_Servico)
);

CREATE TABLE Fornecedor (
    NIF           varchar(9) NOT NULL,
    Nome          varchar(100) NOT NULL,
    No_Tel        varchar(15),
    PRIMARY KEY (NIF)
);

CREATE TABLE Produto (
    ID_Produto    int NOT NULL,
    Nome          varchar(120) NOT NULL,
    PRIMARY KEY (ID_Produto)
);

CREATE TABLE Produto_Venda (
    ID_Produto    int NOT NULL,
    Stock         int NOT NULL,
    Preco_unidade numeric(10,2) NOT NULL,
    PRIMARY KEY (ID_Produto),
    FOREIGN KEY (ID_Produto) REFERENCES Produto(ID_Produto)
);

CREATE TABLE Produto_Consumo (
    ID_Produto    int NOT NULL,
    Stock         int NOT NULL,
    PRIMARY KEY (ID_Produto),
    FOREIGN KEY (ID_Produto) REFERENCES Produto(ID_Produto)
);

CREATE TABLE Despesas_Fixas (
    Nome_despesa   varchar(120) NOT NULL,
    Valor          numeric(10,2) NOT NULL,
    Dia_vencimento int NOT NULL,
    PRIMARY KEY (Nome_despesa),
    CHECK (Dia_vencimento >= 1 AND Dia_vencimento <= 31)
);

CREATE TABLE Movimentacao_Caixa (
    ID_Mov        int NOT NULL,
    Valor         numeric(10,2) NOT NULL,
    Data_Hora     timestamp NOT NULL,
    Tipo          varchar(20) NOT NULL,
    PRIMARY KEY (ID_Mov),
    CHECK (Tipo = 'Receita' OR Tipo = 'Despesa')
);

CREATE TABLE Agendamento (
    ID_agendamento int NOT NULL,
    Data           date NOT NULL,
    Hora           time NOT NULL,
    Status         varchar(20) NOT NULL,
    Cadastro       int NOT NULL,
    PRIMARY KEY (ID_agendamento),
    FOREIGN KEY (Cadastro) REFERENCES Cliente(Cadastro),
    CHECK (Status = 'Pendente' OR Status = 'Concluido' OR Status = 'Cancelado')
);

CREATE TABLE Folha_Pagamento (
    ID_folha      int NOT NULL,
    Salario       numeric(10,2) NOT NULL,
    Mes_Ano       varchar(7) NOT NULL,
    ID_Barbeiro   int NOT NULL,
    PRIMARY KEY (ID_folha),
    FOREIGN KEY (ID_Barbeiro) REFERENCES Barbeiro(ID_Barbeiro)
);

CREATE TABLE Escala_Semanal (
    ID_Barbeiro   int NOT NULL,
    Dia_semana    varchar(15) NOT NULL,
    Hora_inicio   time NOT NULL,
    Hora_fim      time NOT NULL,
    PRIMARY KEY (ID_Barbeiro, Dia_semana, Hora_inicio),
    FOREIGN KEY (ID_Barbeiro) REFERENCES Barbeiro(ID_Barbeiro),
    CHECK (Hora_fim > Hora_inicio)
);

CREATE TABLE Inclui (
    ID_agendamento  int NOT NULL,
    ID_Servico      int NOT NULL,
    ID_Barbeiro     int NOT NULL,
    Observacoes     varchar(500),
    Preco_praticado numeric(10,2) NOT NULL,
    PRIMARY KEY (ID_agendamento, ID_Servico, ID_Barbeiro),
    FOREIGN KEY (ID_agendamento) REFERENCES Agendamento(ID_agendamento),
    FOREIGN KEY (ID_Servico) REFERENCES Servico(ID_Servico),
    FOREIGN KEY (ID_Barbeiro) REFERENCES Barbeiro(ID_Barbeiro)
);

CREATE TABLE Consome (
    ID_Servico   int NOT NULL,
    ID_Produto   int NOT NULL,
    Unidades     int NOT NULL,
    PRIMARY KEY (ID_Servico, ID_Produto),
    FOREIGN KEY (ID_Servico) REFERENCES Servico(ID_Servico),
    FOREIGN KEY (ID_Produto) REFERENCES Produto_Consumo(ID_Produto)
);

CREATE TABLE Fornece (
    NIF            varchar(9) NOT NULL,
    ID_Produto     int NOT NULL,
    Preco_unidade  numeric(10,2) NOT NULL,
    Quantidade     int NOT NULL,
    Data_da_compra date NOT NULL,
    PRIMARY KEY (NIF, ID_Produto, Data_da_compra),
    FOREIGN KEY (NIF) REFERENCES Fornecedor(NIF),
    FOREIGN KEY (ID_Produto) REFERENCES Produto(ID_Produto)
);

CREATE TABLE Compra (
    Cadastro      int NOT NULL,
    ID_Produto    int NOT NULL,
    Data_hora     timestamp NOT NULL,
    Unidades      int NOT NULL,
    Valor_total   numeric(10,2) NOT NULL,
    PRIMARY KEY (Cadastro, ID_Produto, Data_hora),
    FOREIGN KEY (Cadastro) REFERENCES Cliente(Cadastro),
    FOREIGN KEY (ID_Produto) REFERENCES Produto_Venda(ID_Produto)
);