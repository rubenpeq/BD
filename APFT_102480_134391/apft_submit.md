# BD: Trabalho Prático APF-T

**Grupo**: P3G1
- Rúben Pequeno, MEC: 102480
- Eduardo Assis, MEC: 134391

## Introdução / Introduction
 
Este trabalho propõe o desenvolvimento de um sistema de gestão para uma barbearia onde são os próprios barbeiros que gerem os seus horários, atendem os clientes e realizam as vendas de produtos. O sistema permite o agendamento de serviços com um barbeiro específico, controla o stock de produtos para o cabelo e regista todas as receitas e despesas do negócio. Através de uma estrutura simples mas completa, pretende-se oferecer uma ferramenta que facilite a gestão deste tipo de negócios.

## ​Análise de Requisitos / Requirements

## DER - Diagrama Entidade Relacionamento/Entity Relationship Diagram

### Versão final/Final version

![DER Diagram!](der.jpg "AnImage")

### Melhorias/Improvements 

Descreva sumariamente as melhorias sobre a entrega anterior.
Describe briefly the improvements made since the previous delivery.

## ER - Esquema Relacional/Relational Schema

### Versão final/Final Version

![ER Diagram!](er.jpg "AnImage")

### Melhorias/Improvements

Descreva sumariamente as melhorias sobre a entrega anterior.
Describe briefly the improvements made since the previous delivery.

## ​SQL DDL - Data Definition Language

[SQL DDL File](sql/01_ddl.sql "SQLFileQuestion")

## SQL DML - Data Manipulation Language

Uma secção por formulário.
A section for each form.

### Formulario exemplo/Example Form

![Exemplo Screenshot!](screenshots/customer_details_form.jpg "AnImage")

```sql
-- Show data on the form
SELECT * FROM MY_TABLE ....;

-- Insert new element
INSERT INTO MY_TABLE ....;
```

...

## Normalização/Normalization

Descreva os passos utilizados para minimizar a duplicação de dados / redução de espaço.
Justifique as opções tomadas.
Describe the steps used to minimize data duplication / space reduction.
Justify the choices made.

## Índices/Indexes

Descreva os indices criados. Junte uma cópia do SQL de criação do indice.
Describe the indexes created. Attach a copy of the SQL to create the index.

```sql
-- Create an index to speed queries by XYZ in form A.
CREATE INDEX index_name ON table_name (column1, column2, ...);
```

## SQL Programming: Stored Procedures, Triggers, UDF

[SQL SPs and Functions File](sql/02_sp_functions.sql "SQLFileQuestion")

[SQL Triggers File](sql/03_triggers.sql "SQLFileQuestion")

## Outras notas/Other notes

### Dados iniciais da dabase de dados/Database init data

[SQL DB Init File](sql/04_db_init.sql "SQLFileQuestion")

### Apresentação

[Slides](slides.pdf "Sildes")

[Video](https://elearning.ua.pt/pluginfile.php/55992/mod_label/intro/VideoTrabalho2013.mp4)




 