-- 1. Tabelas Independentes
CREATE TABLE MEDICO (
    num_id INT PRIMARY KEY,
    nome VARCHAR(30) NOT NULL,
    especialidade VARCHAR(30)
);

CREATE TABLE PACIENTE (
    num_utente INT PRIMARY KEY,
    nome VARCHAR(30) NOT NULL,
    nascimento DATE,
    endereco VARCHAR(100)
);

CREATE TABLE FARMACEUTICA (
    num_registo INT PRIMARY KEY,
    nome VARCHAR(30) NOT NULL,
    endereco VARCHAR(100),
    telefone INT
);

-- 2. Entidade Fraca: FARMACO (Depende da Farmacêutica)
CREATE TABLE FARMACO (
    num_registo_farmaceutica INT NOT NULL, -- FK para o ID da empresa
    nome_comercial VARCHAR(30) NOT NULL,
    formula VARCHAR(100) NOT NULL,
    CONSTRAINT PK_FARMACO PRIMARY KEY (num_registo_farmaceutica, nome_comercial),
    CONSTRAINT FK_FARMACO_EMPRESA FOREIGN KEY (num_registo_farmaceutica) 
        REFERENCES FARMACEUTICA(num_registo)
);

-- 3. Entidade: PRESCRICAO
CREATE TABLE PRESCRICAO (
    num_prescricao INT PRIMARY KEY,
    dia DATE NOT NULL
);

-- 4. Tabela de Ligação: CONTEM (N:M entre Prescrição e Fármaco)
CREATE TABLE CONTEM (
    num_prescricao INT NOT NULL,
    num_registo_farmaceutica INT NOT NULL,
    nome_comercial_farmaco VARCHAR(30) NOT NULL,
    CONSTRAINT PK_CONTEM PRIMARY KEY (num_prescricao, num_registo_farmaceutica, nome_comercial_farmaco),
    CONSTRAINT FK_CONTEM_PRES FOREIGN KEY (num_prescricao) 
        REFERENCES PRESCRICAO(num_prescricao),
    -- Nota: A FK para Fármaco PRECISA das duas colunas da PK de Fármaco
    CONSTRAINT FK_CONTEM_FARMACO FOREIGN KEY (num_registo_farmaceutica, nome_comercial_farmaco) 
        REFERENCES FARMACO(num_registo_farmaceutica, nome_comercial)
);

-- 5. Tabela CONSULTA (Entidade Associativa M:N)
CREATE TABLE CONSULTA (
    id_medico INT NOT NULL,
    utente_paciente INT NOT NULL,
    num_prescricao INT, -- Pode ser NULL se a consulta não gerar prescrição
    data_consulta DATE,
    CONSTRAINT PK_CONSULTA PRIMARY KEY (id_medico, utente_paciente, data_consulta),
    CONSTRAINT FK_CONSULTA_MED FOREIGN KEY (id_medico) REFERENCES MEDICO(num_id),
    CONSTRAINT FK_CONSULTA_PAC FOREIGN KEY (utente_paciente) REFERENCES PACIENTE(num_utente),
    CONSTRAINT FK_CONSULTA_PRES FOREIGN KEY (num_prescricao) REFERENCES PRESCRICAO(num_prescricao)
);