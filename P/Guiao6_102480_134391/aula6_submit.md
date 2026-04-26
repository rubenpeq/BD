# BD: Guião 6

## Problema 6.1

### *a)* Todos os tuplos da tabela autores (authors);

```
SELECT *
FROM authors;
```

### *b)* O primeiro nome, o último nome e o telefone dos autores;

```
SELECT au_fname, au_lname, phone
FROM authors;
```

### *c)* Consulta definida em b) mas ordenada pelo primeiro nome (ascendente) e depois o último nome (ascendente); 

```
SELECT au_fname, au_lname, phone
FROM authors
ORDER BY au_fname ASC, au_lname ASC;
```

### *d)* Consulta definida em c) mas renomeando os atributos para (first_name, last_name, telephone); 

```
SELECT au_fname AS first_name, au_lname AS last_name, phone AS telephone
FROM authors
ORDER BY au_fname, au_lname;
```

### *e)* Consulta definida em d) mas só os autores da Califórnia (CA) cujo último nome é diferente de ‘Ringer’; 

```
SELECT au_fname AS first_name, au_lname AS last_name, phone AS telephone
FROM authors
WHERE state = 'CA' AND au_lname <> 'Ringer'
ORDER BY au_fname, au_lname;
```

### *f)* Todas as editoras (publishers) que tenham ‘Bo’ em qualquer parte do nome; 

```
SELECT *
FROM publishers
WHERE pub_name LIKE '%Bo%';
```

### *g)* Nome das editoras que têm pelo menos uma publicação do tipo ‘Business’; 

```
SELECT DISTINCT pub_name
FROM (publishers AS p JOIN titles AS t ON p.pub_id = t.pub_id)
WHERE type = 'Business';
```

### *h)* Número total de vendas de cada editora; 

```
SELECT publishers.pub_name, SUM(sales.qty) as 'vendas'

FROM publishers
INNER JOIN titles ON publishers.pub_id = titles.pub_id
INNER JOIN sales ON titles.title_id = sales.title_id

GROUP BY publishers.pub_name;
```

### *i)* Número total de vendas de cada editora agrupado por título; 

```
SELECT publishers.pub_name, titles.title, SUM(sales.qty) as 'vendas'

FROM publishers
INNER JOIN titles ON publishers.pub_id = titles.pub_id
INNER JOIN sales ON titles.title_id = sales.title_id

GROUP BY publishers.pub_name, titles.title;
```

### *j)* Nome dos títulos vendidos pela loja ‘Bookbeat’; 

```
SELECT DISTINCT titles.title

FROM sales
INNER JOIN stores ON sales.stor_id = stores.stor_id
INNER JOIN titles ON titles.title_id = sales.title_id

WHERE stores.stor_name = 'Bookbeat';
```

### *k)* Nome de autores que tenham publicações de tipos diferentes; 

```
SELECT authors.au_fname, authors.au_lname

FROM authors
INNER JOIN titleauthor ON authors.au_id = titleauthor.au_id
INNER JOIN titles ON titleauthor.title_id = titles.title_id

GROUP BY authors.au_id, authors.au_fname, authors.au_lname

HAVING COUNT(DISTINCT titles.type) > 1;
```

### *l)* Para os títulos, obter o preço médio e o número total de vendas agrupado por tipo (type) e editora (pub_id);

```
SELECT titles.type, titles.pub_id, AVG(titles.price) AS 'preco_medio', SUM(sales.qty) AS 'vendas'

FROM titles
INNER JOIN sales ON titles.title_id = sales.title_id

GROUP BY titles.type, titles.pub_id;
```

### *m)* Obter o(s) tipo(s) de título(s) para o(s) qual(is) o máximo de dinheiro “à cabeça” (advance) é uma vez e meia superior à média do grupo (tipo);

```
SELECT type

FROM titles

GROUP BY type

HAVING MAX(advance) > 1.5 * AVG(advance);
```

### *n)* Obter, para cada título, nome dos autores e valor arrecadado por estes com a sua venda;

```
SELECT titles.title, authors.au_fname, authors.au_lname,
       SUM(sales.qty * titles.price * titleauthor.royaltyper / 100) AS 'valor_arrecadado'

FROM titles
INNER JOIN titleauthor ON titles.title_id = titleauthor.title_id
INNER JOIN authors ON titleauthor.au_id = authors.au_id
INNER JOIN sales ON titles.title_id = sales.title_id

GROUP BY titles.title, authors.au_fname, authors.au_lname;
```

### *o)* Obter uma lista que incluía o número de vendas de um título (ytd_sales), o seu nome, a faturação total, o valor da faturação relativa aos autores e o valor da faturação relativa à editora;

```
SELECT titles.ytd_sales, titles.title,
       SUM(sales.qty * titles.price) AS 'faturacao_total',
       SUM(sales.qty * titles.price * titles.royalty / 100) AS 'faturacao_autores',
       SUM(sales.qty * titles.price * (100 - titles.royalty) / 100) AS 'faturacao_editora'

FROM titles
INNER JOIN sales ON titles.title_id = sales.title_id

GROUP BY titles.ytd_sales, titles.title, titles.royalty;
```

### *p)* Obter uma lista que incluía o número de vendas de um título (ytd_sales), o seu nome, o nome de cada autor, o valor da faturação de cada autor e o valor da faturação relativa à editora;

```
SELECT titles.ytd_sales, titles.title,
       authors.au_fname, authors.au_lname,
       SUM(sales.qty * titles.price * titleauthor.royaltyper / 100) AS 'faturacao_autor',
       SUM(sales.qty * titles.price * (100 - titles.royalty) / 100) AS 'faturacao_editora'

FROM titles
INNER JOIN titleauthor ON titles.title_id = titleauthor.title_id
INNER JOIN authors ON titleauthor.au_id = authors.au_id
INNER JOIN sales ON titles.title_id = sales.title_id

GROUP BY titles.ytd_sales, titles.title, authors.au_fname, authors.au_lname, titles.royalty;
```

### *q)* Lista de lojas que venderam pelo menos um exemplar de todos os livros;

```
... Write here your answer ...
```

### *r)* Lista de lojas que venderam mais livros do que a média de todas as lojas;

```
... Write here your answer ...
```

### *s)* Nome dos títulos que nunca foram vendidos na loja “Bookbeat”;

```
SELECT titles.title

FROM titles

WHERE titles.title_id NOT IN (
    SELECT sales.title_id

    FROM sales
    INNER JOIN stores ON sales.stor_id = stores.stor_id

    WHERE stores.stor_name = 'Bookbeat'
);
```

### *t)* Para cada editora, a lista de todas as lojas que nunca venderam títulos dessa editora; 

```
SELECT publishers.pub_name, stores.stor_name

FROM publishers
CROSS JOIN stores

WHERE NOT EXISTS (
    SELECT *

    FROM titles
    INNER JOIN sales ON titles.title_id = sales.title_id

    WHERE titles.pub_id = publishers.pub_id
      AND sales.stor_id = stores.stor_id
);
```

## Problema 6.2

### ​5.1

#### a) SQL DDL Script
 
[a) SQL DDL File](ex_6_2_1_ddl.sql "SQLFileQuestion")

#### b) Data Insertion Script

[b) SQL Data Insertion File](ex_6_2_1_data.sql "SQLFileQuestion")

#### c) Queries

##### *a)*

```
SELECT PROJECT.Pname, EMPLOYEE.Ssn, EMPLOYEE.Fname, EMPLOYEE.Minit, EMPLOYEE.Lname

FROM EMPLOYEE
INNER JOIN WORKS_ON ON EMPLOYEE.Ssn = WORKS_ON.Essn
INNER JOIN PROJECT ON WORKS_ON.Pno = PROJECT.Pnumber;
```

##### *b)* 

```
SELECT Subordinado.Fname, Subordinado.Lname

FROM EMPLOYEE AS Subordinado
INNER JOIN EMPLOYEE AS Chefe ON Subordinado.Super_ssn = Chefe.Ssn

WHERE Chefe.Fname = 'Carlos'
  AND Chefe.Minit = 'D'
  AND Chefe.Lname = 'Gomes';
```

##### *c)* 

```
SELECT PROJECT.Pname, SUM(WORKS_ON.Hours) AS Total_Horas_Semanais

FROM PROJECT
INNER JOIN WORKS_ON ON PROJECT.Pnumber = WORKS_ON.Pno

GROUP BY PROJECT.Pname;
```

##### *d)* 

```
SELECT EMPLOYEE.Fname, EMPLOYEE.Lname

FROM EMPLOYEE
INNER JOIN WORKS_ON ON EMPLOYEE.Ssn = WORKS_ON.Essn
INNER JOIN PROJECT ON WORKS_ON.Pno = PROJECT.Pnumber

WHERE EMPLOYEE.Dno = 3
  AND PROJECT.Pname = 'Aveiro Digital'
  AND WORKS_ON.Hours > 20;
```

##### *e)* 

```
SELECT EMPLOYEE.Fname, EMPLOYEE.Lname

FROM EMPLOYEE

WHERE EMPLOYEE.Ssn NOT IN (
    SELECT WORKS_ON.Essn
    FROM WORKS_ON
);
```

##### *f)* 

```
SELECT DEPARTMENT.Dname, AVG(EMPLOYEE.Salary) AS media_feminina

FROM DEPARTMENT
INNER JOIN EMPLOYEE ON DEPARTMENT.Dnumber = EMPLOYEE.Dno

WHERE EMPLOYEE.Sex = 'F'

GROUP BY DEPARTMENT.Dname;
```

##### *g)* 

```
SELECT EMPLOYEE.Ssn, EMPLOYEE.Fname, EMPLOYEE.Lname, COUNT(DEPENDENT.Dependent_name) AS soma

FROM EMPLOYEE
INNER JOIN DEPENDENT ON EMPLOYEE.Ssn = DEPENDENT.Essn

GROUP BY EMPLOYEE.Ssn, EMPLOYEE.Fname, EMPLOYEE.Lname

HAVING COUNT(DEPENDENT.Dependent_name) > 2;
```

##### *h)* 

```
SELECT EMPLOYEE.Fname, EMPLOYEE.Lname, EMPLOYEE.Ssn

FROM EMPLOYEE
INNER JOIN DEPARTMENT ON EMPLOYEE.Ssn = DEPARTMENT.Mgr_ssn

WHERE EMPLOYEE.Ssn NOT IN (
    SELECT DEPENDENT.Essn
    FROM DEPENDENT
);
```

##### *i)* 

```
SELECT DISTINCT EMPLOYEE.Fname, EMPLOYEE.Lname, EMPLOYEE.Address

FROM EMPLOYEE
INNER JOIN WORKS_ON ON EMPLOYEE.Ssn = WORKS_ON.Essn
INNER JOIN PROJECT ON WORKS_ON.Pno = PROJECT.Pnumber

WHERE PROJECT.Plocation = 'Aveiro'
  AND EMPLOYEE.Dno NOT IN (
      SELECT DEPT_LOCATIONS.Dnumber
      FROM DEPT_LOCATIONS
      WHERE DEPT_LOCATIONS.Dlocation = 'Aveiro'
  );
```

### 5.2

#### a) SQL DDL Script
 
[a) SQL DDL File](ex_6_2_2_ddl.sql "SQLFileQuestion")

#### b) Data Insertion Script

[b) SQL Data Insertion File](ex_6_2_2_data.sql "SQLFileQuestion")

#### c) Queries

##### *a)*

```
... Write here your answer ...
```

##### *b)* 

```
... Write here your answer ...
```


##### *c)* 

```
... Write here your answer ...
```


##### *d)* 

```
... Write here your answer ...
```

### 5.3

#### a) SQL DDL Script
 
[a) SQL DDL File](ex_6_2_3_ddl.sql "SQLFileQuestion")

#### b) Data Insertion Script

[b) SQL Data Insertion File](ex_6_2_3_data.sql "SQLFileQuestion")

#### c) Queries

##### *a)*

```
... Write here your answer ...
```

##### *b)* 

```
... Write here your answer ...
```


##### *c)* 

```
... Write here your answer ...
```


##### *d)* 

```
... Write here your answer ...
```

##### *e)* 

```
... Write here your answer ...
```

##### *f)* 

```
... Write here your answer ...
```
