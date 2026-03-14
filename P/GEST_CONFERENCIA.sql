CREATE TABLE INSTITUICAO (
    nome VARCHAR(100) PRIMARY KEY,
    endereco VARCHAR(200) NOT NULL
);

CREATE TABLE ARTIGO (
    num_registo INT PRIMARY KEY,
    titulo VARCHAR(255) NOT NULL
);

CREATE TABLE AUTOR (
    email VARCHAR(100) PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    nome_instituicao VARCHAR(100),
    CONSTRAINT FK_AUTOR_INST FOREIGN KEY (nome_instituicao) REFERENCES INSTITUICAO(nome)
);

-- Tabela de ligação N:M entre Autor e Artigo
CREATE TABLE AUTORIA (
    email_autor VARCHAR(100),
    num_registo_artigo INT,
    PRIMARY KEY (email_autor, num_registo_artigo),
    CONSTRAINT FK_AUTORIA_AUTOR FOREIGN KEY (email_autor) REFERENCES AUTOR(email),
    CONSTRAINT FK_AUTORIA_ARTIGO FOREIGN KEY (num_registo_artigo) REFERENCES ARTIGO(num_registo)
);

-- Tabela "Pai"
CREATE TABLE PARTICIPANTE (
    email VARCHAR(100) PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    morada VARCHAR(200),
    data_inscricao DATE NOT NULL,
    nome_instituicao VARCHAR(100),
    CONSTRAINT FK_PARTICIPANTE_INST FOREIGN KEY (nome_instituicao) REFERENCES INSTITUICAO(nome)
);

-- Tabela "Filha": Estudante
CREATE TABLE ESTUDANTE (
    email_participante VARCHAR(100) PRIMARY KEY,
    comprovativo_url VARCHAR(255) NOT NULL, -- "Localização eletrónica"
    CONSTRAINT FK_ESTUDANTE_PART FOREIGN KEY (email_participante) REFERENCES PARTICIPANTE(email)
);

-- Tabela "Filha": Não Estudante
CREATE TABLE NAO_ESTUDANTE (
    email_participante VARCHAR(100) PRIMARY KEY,
    ref_transacao VARCHAR(50) NOT NULL,
    CONSTRAINT FK_NAO_EST_PART FOREIGN KEY (email_participante) REFERENCES PARTICIPANTE(email)
);
