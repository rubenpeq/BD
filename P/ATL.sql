-- Tabela de Professores
CREATE TABLE PROFESSOR (
    num_funcionario INT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    cc_numero VARCHAR(20) UNIQUE NOT NULL,
    morada VARCHAR(200),
    data_nascimento DATE,
    contacto_telefonico VARCHAR(15),
    email VARCHAR(100)
);

-- Tabela de Encarregados e Pessoas Autorizadas
-- Nota: Como o registo é similar, usamos uma tabela para ambos com um campo de distinção
CREATE TABLE RESPONSAVEL (
    cc_numero VARCHAR(20) PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    morada VARCHAR(200),
    contacto_telefonico VARCHAR(15),
    email VARCHAR(100),
    tipo_responsavel VARCHAR(20) -- 'Encarregado' ou 'Autorizado'
);

-- Tabela de Alunos
CREATE TABLE ALUNO (
    cc_numero VARCHAR(20) PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    morada VARCHAR(200),
    data_nascimento DATE,
    cc_encarregado VARCHAR(20) NOT NULL,
    parentesco_encarregado VARCHAR(20), -- pai, mãe, avô, etc.
    CONSTRAINT FK_ALUNO_ENCARREGADO FOREIGN KEY (cc_encarregado) REFERENCES RESPONSAVEL(cc_numero)
);

-- Tabela de Turmas
CREATE TABLE TURMA (
    id_turma INT PRIMARY KEY,
    ano_letivo VARCHAR(9) NOT NULL, -- Ex: '2025/2026'
    designacao VARCHAR(50),
    escolaridade_classe INT NOT NULL,
    max_alunos INT,
    id_professor INT NOT NULL,
    -- Restrição para as 5 classes: 0, 1, 2, 3 e 4
    CONSTRAINT CK_CLASSE CHECK (escolaridade_classe BETWEEN 0 AND 4),
    CONSTRAINT FK_TURMA_PROF FOREIGN KEY (id_professor) REFERENCES PROFESSOR(num_funcionario)
);

-- Tabela de Atividades
CREATE TABLE ATIVIDADE (
    id_atividade INT PRIMARY KEY,
    designacao VARCHAR(100) NOT NULL,
    custo DECIMAL(10,2) NOT NULL
);

-- Ligação entre Alunos e Turmas (Um aluno pertence a uma turma por ano letivo)
CREATE TABLE MATRICULA (
    cc_aluno VARCHAR(20),
    id_turma INT,
    PRIMARY KEY (cc_aluno, id_turma),
    CONSTRAINT FK_MATRICULA_ALUNO FOREIGN KEY (cc_aluno) REFERENCES ALUNO(cc_numero),
    CONSTRAINT FK_MATRICULA_TURMA FOREIGN KEY (id_turma) REFERENCES TURMA(id_turma)
);

-- Ligação entre Atividades e Turmas (Disponibilidade)
CREATE TABLE ATIVIDADE_TURMA (
    id_atividade INT,
    id_turma INT,
    PRIMARY KEY (id_atividade, id_turma),
    FOREIGN KEY (id_atividade) REFERENCES ATIVIDADE(id_atividade),
    FOREIGN KEY (id_turma) REFERENCES TURMA(id_turma)
);

-- Frequência de Atividade por Aluno (Facultativa)
CREATE TABLE FREQUENCIA_ATIVIDADE (
    cc_aluno VARCHAR(20),
    id_atividade INT,
    PRIMARY KEY (cc_aluno, id_atividade),
    FOREIGN KEY (cc_aluno) REFERENCES ALUNO(cc_numero),
    FOREIGN KEY (id_atividade) REFERENCES ATIVIDADE(id_atividade)
);

-- Lista de pessoas autorizadas para levantar o aluno
CREATE TABLE AUTORIZACAO_LEVANTAMENTO (
    cc_aluno VARCHAR(20),
    cc_responsavel VARCHAR(20),
    PRIMARY KEY (cc_aluno, cc_responsavel),
    FOREIGN KEY (cc_aluno) REFERENCES ALUNO(cc_numero),
    FOREIGN KEY (cc_responsavel) REFERENCES RESPONSAVEL(cc_numero)
);