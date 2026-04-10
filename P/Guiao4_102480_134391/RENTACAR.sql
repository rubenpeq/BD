-- Tabela de Tipos de Veículo
CREATE TABLE TIPO_VEICULO (
    codigo INT NOT NULL,
    designacao VARCHAR(50) NOT NULL,
    ar_condicionado BIT, -- 0 para Não, 1 para Sim
    CONSTRAINT PK_TIPO_VEICULO PRIMARY KEY (codigo)
);

-- Tabela de Balcões
CREATE TABLE BALCAO (
    numero INT NOT NULL,
    nome VARCHAR(50) NOT NULL,
    endereco VARCHAR(100),
    CONSTRAINT PK_BALCAO PRIMARY KEY (numero)
);

-- Tabela de Clientes
CREATE TABLE CLIENTE (
    NIF INT NOT NULL,
    nome VARCHAR(50) NOT NULL,
    endereco VARCHAR(100),
    num_carta VARCHAR(20) NOT NULL,
    CONSTRAINT PK_CLIENTE PRIMARY KEY (NIF)
);

CREATE TABLE LIGEIRO (
    codigo_tipo INT NOT NULL,
    num_lugares INT,
    portas INT,
    combustivel VARCHAR(20),
    CONSTRAINT PK_LIGEIRO PRIMARY KEY (codigo_tipo),
    CONSTRAINT FK_LIGEIRO_TIPO FOREIGN KEY (codigo_tipo) REFERENCES TIPO_VEICULO(codigo)
);

CREATE TABLE PESADO (
    codigo_tipo INT NOT NULL,
    peso INT,
    passageiros INT,
    CONSTRAINT PK_PESADO PRIMARY KEY (codigo_tipo),
    CONSTRAINT FK_PESADO_TIPO FOREIGN KEY (codigo_tipo) REFERENCES TIPO_VEICULO(codigo)
);

-- Tabela de Veículos
CREATE TABLE VEICULO (
    matricula VARCHAR(10) NOT NULL,
    marca VARCHAR(30),
    ano INT,
    codigo_tipo INT NOT NULL,
    CONSTRAINT PK_VEICULO PRIMARY KEY (matricula),
    CONSTRAINT FK_VEICULO_TIPO FOREIGN KEY (codigo_tipo) REFERENCES TIPO_VEICULO(codigo)
);

-- Tabela de Aluguer 
CREATE TABLE ALUGUER (
    numero INT NOT NULL,
    data_aluguer DATETIME NOT NULL,
    duracao INT, -- Duração em dias
    nif_cliente INT NOT NULL,
    matricula_veiculo VARCHAR(10) NOT NULL,
    num_balcao INT NOT NULL,
    CONSTRAINT PK_ALUGUER PRIMARY KEY (numero),
    CONSTRAINT FK_ALUGUER_CLIENTE FOREIGN KEY (nif_cliente) REFERENCES CLIENTE(NIF),
    CONSTRAINT FK_ALUGUER_VEICULO FOREIGN KEY (matricula_veiculo) REFERENCES VEICULO(matricula),
    CONSTRAINT FK_ALUGUER_BALCAO FOREIGN KEY (num_balcao) REFERENCES BALCAO(numero)
);

-- Tabela de Similaridade
CREATE TABLE SIMILARIDADE (
    codigo_1 INT NOT NULL,
    codigo_2 INT NOT NULL,
    CONSTRAINT PK_SIMILARIDADE PRIMARY KEY (codigo_1,codigo_2),
    CONSTRAINT FK_SIMILARIDADE1 FOREIGN KEY (codigo_1) REFERENCES TIPO_VEICULO(codigo),  
    CONSTRAINT FK_SIMILARIDADE2 FOREIGN KEY (codigo_2) REFERENCES TIPO_VEICULO(codigo),
    CONSTRAINT CK_NAO_IGUAL CHECK (codigo_1 <> codigo_2),
);