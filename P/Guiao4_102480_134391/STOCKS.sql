-- Tabela para os Tipos de Fornecedor
CREATE TABLE TIPO_FORNECEDOR (
    codigo_tipo INT PRIMARY KEY,
    designacao VARCHAR(50) NOT NULL
);

-- Tabela de Fornecedores
CREATE TABLE FORNECEDOR (
    NIF INT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    endereco VARCHAR(150),
    fax VARCHAR(20),
    condicoes_pagamento VARCHAR(50),
    codigo_tipo_fornecedor INT NOT NULL,
    CONSTRAINT FK_FORN_TIPO FOREIGN KEY (codigo_tipo_fornecedor) REFERENCES TIPO_FORNECEDOR(codigo_tipo)
);

-- Tabela de Produtos
CREATE TABLE PRODUTO (
    codigo INT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    preco DECIMAL(10,2) NOT NULL,
    taxa_iva DECIMAL(5,2) NOT NULL,
    stock_atual INT DEFAULT 0 -- "Saber a cada momento o número de unidades"
);
-- Cabeçalho da Encomenda
CREATE TABLE ENCOMENDA (
    numero_encomenda INT PRIMARY KEY,
    data_realizacao DATE NOT NULL,
    nif_fornecedor INT NOT NULL,
    CONSTRAINT FK_ENC_FORNECEDOR FOREIGN KEY (nif_fornecedor) REFERENCES FORNECEDOR(NIF)
);

-- Itens da Encomenda (Tabela de Ligação N:M)
-- Aqui resolvemos a premissa: "Uma encomenda contém um ou mais itens"
CREATE TABLE ITEM_ENCOMENDA (
    num_encomenda INT NOT NULL,
    cod_produto INT NOT NULL,
    quantidade INT NOT NULL CHECK (quantidade > 0),
    PRIMARY KEY (num_encomenda, cod_produto),
    CONSTRAINT FK_ITEM_ENC FOREIGN KEY (num_encomenda) REFERENCES ENCOMENDA(numero_encomenda),
    CONSTRAINT FK_ITEM_PROD FOREIGN KEY (cod_produto) REFERENCES PRODUTO(codigo)
);

