# BD: Trabalho Prático APF-T

**Grupo**: P3G1
- Rúben Pequeno, MEC: 102480
- Eduardo Assis, MEC: 134391

## Introdução
 
Este trabalho propõe o desenvolvimento de um sistema de gestão para uma barbearia onde são os próprios barbeiros que gerem os seus horários, atendem os clientes e realizam as vendas de produtos. O sistema permite o agendamento de serviços com um barbeiro específico, controla o stock de produtos para o cabelo e regista todas as receitas e despesas do negócio. Através de uma estrutura simples mas completa, pretende-se oferecer uma ferramenta que facilite a gestão deste tipo de negócios.

## ​Análise de Requisitos

### 1. Requisitos Funcionais

#### A. Gestão de Clientes e Agendamentos
- **Cadastro de Clientes**: O sistema deve permitir registar nome, apelido, telefone, NIF e numero de cadastro.
- **Controlo de Agenda**: Deve ser possível marcar horários associando um Cliente a um Barbeiro e a um ou mais Serviços.
- **Status de Agendamento**: O sistema deve gerir o ciclo de vida do agendamento (Pendente, Concluído ou Cancelado).

#### B. Gestão de Recursos Humanos (Barbeiros)
- **Perfil do Barbeiro**: Registo de dados pessoais, NIF e especialidade.
- **Escala de Trabalho**: O sistema deve controlar os dias da semana e horários (início/fim) em que cada barbeiro está disponível.
- **Folha de Pagamento**: Deve calcular ou registar o salário mensal/anual de cada colaborador.

#### C. Gestão de Serviços e Vendas
- **Catálogo de Serviços**: Definição de serviços com preço base.
- **Venda de Produtos**: O sistema deve permitir a venda direta de produtos ao cliente (ex: ceras, shampoos), calculando o valor total (`Unidades x Preco_unidade`).
- **Consumo Interno**: Deve registar quais produtos de consumo (ex: golas descartáveis, loções) são utilizados em cada serviço para baixar o stock automaticamente.

#### D. Gestão de Stock e Fornecedores
- **Diferenciação de Produtos**: O sistema deve distinguir entre "Produto de Venda" e "Produto de Consumo" (Herança/Especialização Total e Disjunta).
- **Compras**: Registo de entrada de mercadoria com controlo de preço de custo, quantidade e data da compra junto aos fornecedores.

#### E. Gestão Financeira (Fluxo de Caixa)
- **Movimentação de Caixa**: Centralização de todas as entradas (receitas de serviços e vendas) e saídas (pagamento de salários e despesas fixas).
- **Controlo de Despesas**: Gestão de custos fixos (renda, luz, água) com data de vencimento.

### 2. Regras de Negócio
- **Herança de Produtos**: Um produto tem de ser obrigatoriamente ou de venda ou de consumo (Restrição `t` - total), mas nunca os dois simultaneamente (Restrição `d` - disjoint).
- **Cálculo de Receita**: Toda a conclusão de um Agendamento ou uma Compra (venda para o cliente) deve gerar automaticamente um registo de "Receita" na tabela de `Movimentacao_CAIXA`.
- **Atualização de Stock**:
	- Uma Compra (venda ao cliente) deve subtrair do stock de `Produto_venda`.
	- Um Serviço realizado deve subtrair do stock de `Produto_consumo` com base na quantidade por unidade (ml/un).
- **Pagamentos**: A `Folha_pagamento` e as `Despesas_fixas` devem estar vinculadas a uma saída na `Movimentacao_CAIXA`.

## DER - Diagrama Entidade Relacionamento

### Versão final

![DER Diagram!](der.jpg "AnImage")

### Melhorias

Não houveram alterações em relação à entrega anterior.

## ER - Esquema Relacional

### Versão final

![ER Diagram!](er2.jpeg "AnImage")

### Melhorias

Não houveram alterações em relação à entrega anterior.

## ​SQL DDL - Data Definition Language

[SQL DDL File](sql/01_ddl.sql "SQLFileQuestion")

## SQL DML - Data Manipulation Language

```
-- Form1.cs
INSERT INTO dbo.Cliente (Nome, Apelido, NIF, Telefone, Data_Cadastro, Ativo)
VALUES ('Carlos', 'Silva', '123456789', '912345678', GETDATE(), 1);

-- FormBarbeiro.cs
INSERT INTO dbo.Barbeiro (Nome, Apelido, NIF, Telefone, Especialidade, Ativo)
VALUES ('Ricardo', 'Santos', '987654321', '967654321', 'Degradê', 1);

-- FormStock.cs
INSERT INTO dbo.Fornecedor (Nome, NIF, Telefone, Ativo)
VALUES ('Distribuidora Beleza', '500123456', '234123456', 1);

INSERT INTO dbo.Produto (Nome) VALUES ('Gel Fixador');
-- Assumindo que o ID do Produto criado foi 1 e Fornecedor 1
INSERT INTO dbo.Fornece_Produto (ID_Fornecedor, ID_Produto, Quantidade, Preco_Compra, Data_Fornecimento, Tipo_Stock)
VALUES (1, 1, 50, 5.00, GETDATE(), 'Venda');

-- FormMenu.cs
INSERT INTO dbo.Agendamento (ID_Cliente, Dia, Hora, Estado, Observacoes)
VALUES (1, '2026-06-10', '14:30:00', 'Pendente', 'Corte simples');

-- FormServico.cs
-- INSERT INTO dbo.Servico (Nome_Servico, Preco_base) VALUES ('Corte', 15.00);
INSERT INTO dbo.Agendamento_Servico_Barbeiro (ID_Agendamento, ID_Servico, ID_Barbeiro, Preco_praticado)
VALUES (1, 1, 1, 15.00);

-- FormVenda.cs
INSERT INTO dbo.Produto_venda (ID_Cliente, Data_Venda, Valor_Total)
VALUES (1, GETDATE(), 10.00);

-- Form_Despesas_Fixas.cs
INSERT INTO dbo.Despesas_fixas (Nome_despesa, Valor, Dia_vencimento)
VALUES ('Aluguel', 500.00, '2026-06-05');

-- Form_Folha_Pagamento.cs
INSERT INTO dbo.Folha_Pagamento (ID_Barbeiro, Mes_Ano, Salario)
VALUES (1, '2026-06-01', 1200.00);
```

### Formulario exemplo

![Exemplo Screenshot!](screenshots/dashboard.png "AnImage")

```sql
-- Show data on the form
SELECT ​

        A.ID_Agendamento,​

        C.Nome AS [Nome Cliente],​

        B.Nome AS [Nome Barbeiro],​

        A.Dia AS [Data],​

        A.Hora AS [Horário],​

        SUM(ASB.Preco_praticado) AS [Valor Total],​

        A.Estado AS [Estado]​

    FROM dbo.Agendamento A​

    INNER JOIN dbo.Cliente C ON A.ID_Cliente = C.ID_Cliente​

    INNER JOIN dbo.Agendamento_Servico_Barbeiro ASB ON A.ID_Agendamento = ASB.ID_Agendamento​

    INNER JOIN dbo.Barbeiro B ON ASB.ID_Barbeiro = B.ID_Barbeiro​

    GROUP BY A.ID_Agendamento, C.Nome, B.Nome, A.Dia, A.Hora, A.Estado​

    ORDER BY A.Dia DESC, A.Hora ASC;​

-- Insert new element
DECLARE @NovoID_Agendamento INT;

EXEC sp_Agendamento_InsertCabecalho
    @ID_Cliente = 12,
    @Dia = '2026-06-03',
    @Hora = '14:30:00',
    @Estado = 'Pendente',
    @Observacoes = 'Primeira marcação',
    @ID_Agendamento = @NovoID_Agendamento OUTPUT;

EXEC sp_Agendamento_InsertServico
    @ID_Agendamento = @NovoID_Agendamento,
    @ID_Servico = 3,
    @ID_Barbeiro = 5,
    @Preco_Praticado = 12.50;
```

## Normalização

O esquema está normalizado até à 3.ª Forma Normal (3NF): atributos atómicos, sem grupos repetidos e sem dependências transitivas entre atributos não-chave. Essa normalização reduz duplicação, facilita manutenção e garante integridade referencial (associações N:M e especializações em tabelas separadas).

## Índices

Não foram utilizados nenhum tipo de índices.

## SQL Programming: Stored Procedures, Triggers, UDF

[SQL SPs and Functions File](sql/02_sp_functions.sql "SQLFileQuestion")

[SQL Triggers File](sql/03_triggers.sql "SQLFileQuestion")

## Outras notas

### Dados iniciais da dabase de dados

[SQL DB Init File](sql/04_db_init.sql "SQLFileQuestion")

### User Defined Functions

[SQL UDFs](sql/05_udfs.sql "SQLFileQuestion")

### Apresentação

[Slides](slides.pdf "Sildes")

[Video](https://youtu.be/Rt6E7eiSwtw)
