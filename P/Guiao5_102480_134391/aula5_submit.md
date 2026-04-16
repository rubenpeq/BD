# BD: Guião 5


## ​Problema 5.1
 
### *a)*

```
π Fname, Minit, Lname, Ssn, Pname (EMPLOYEE ⨝ Ssn=Esan (WORKS_ON ⨝ Pno=Pnumber PROJECT))  
```


### *b)* 

```
Chefe ← σ Fname='Carlos' ∧ Minit='D' ∧ Lname='Gomes' (EMPLOYEE) Resultado ← π Subordinado.Fname, Subordinado.Lname (EMPLOYEE_Subordinado ⨝ Subordinado.Super_ssn=Chefe.Ssn Chefe) 

```


### *c)* 

```
γ Pname, SUM(Hours) → Total_Horas_Semanais (PROJECT ⨝ Pnumber=Pno WORKS_ON) 

```


### *d)* 

```
π Fname, Lname (σ Dno=3 ∧ Pname='Aveiro Digital' ∧ Hours>20 (EMPLOYEE ⨝ Ssn=Esan (WORKS_ON ⨝ Pno=Pnumber PROJECT)))
```


### *e)* 

```
π Fname, Lname (EMPLOYEE) − π Fname, Lname (EMPLOYEE ⨝ Ssn=Esan WORKS_ON)
```


### *f)* 

```
Fem_Emp ← σ Sex='F' (EMPLOYEE) γ Dname, AVG(Salary) → media_feminina (DEPARTMENT ⨝ Dnumber=Dno Fem_Emp)
```


### *g)* 

```
Contagem ← γ Ssn, Fname, Lname, COUNT(Dependent_name) → soma (EMPLOYEE ⨝ Ssn=Essn DEPENDENT) σ soma > 2 (Contagem) 
```


### *h)* 

```
Gestores ← π Fname, Lname, Ssn (EMPLOYEE ⨝ Ssn=Mgr_ssn DEPARTMENT) ComDep ← π Fname, Lname, Ssn (Gestores ⨝ Ssn=Essn DEPENDENT) Resultado ← Gestores − ComDep 
```


### *i)* 

```
ProjAveiro ← π Fname, Address (σ Plocation='Aveiro' (EMPLOYEE ⨝ Dno=Dnum PROJECT)) DeptAveiro ← π Fname, Address (σ Dlocation='Aveiro' (EMPLOYEE ⨝ Dno=Dnumber DEPT_LOCATIONS)) Resultado ← ProjAveiro − DeptAveiro
```


## ​Problema 5.2

### *a)*

```
π nome (FORNECEDOR) − π nome (FORNECEDOR ⨝ NIF=nif_fornecedor ENCOMENDA)
```

### *b)* 

```
 γ designacao, AVG(preco) → preco_medio (TIPO_FORNECEDOR ⨝ FORNECEDOR ⨝ ENCOMENDA ⨝ ITEM_ENCOMENDA ⨝ PRODUTO)
```


### *c)* 

```
γ nome, COUNT(numero_encomenda) → total_encomendas (FORNECEDOR ⟝ NIF=nif_fornecedor ENCOMENDA) 
```


### *d)* 

```
Produtos ← γ codigo, nome, COUNT(num_encomenda) → total (PRODUTO ⨝ codigo=cod_produto ITEM_ENCOMENDA) σ total > 2 (Produtos)
```


## ​Problema 5.3

### *a)*

```
π nome (PACIENTE) − π nome (PACIENTE ⨝ num_utente=utente_paciente CONSULTA) 
```

### *b)* 

```
Prescricoes ← σ num_prescricao ≠ NULL (CONSULTA) γ especialidade, COUNT(num_prescricao) → total_prescricoes (MEDICO ⨝ num_id=id_medico Prescricoes) 


```


### *c)* 

```
γ num_prescricao, dia (PRESCRICAO)
```


### *d)* 

```
π nome_comercial (σ num_registo_farmaceutica=906 FARMACO) − π nome_comercial_farmaco (σ num_registo_farmaceutica=906 CONTEM)
```

### *e)* 

```
γ F.nome, COUNT(C.nome_comercial_farmaco) → total_vendido ((RENAME F FARMACEUTICA) ⨝ num_registo=num_registo_farmaceutica (RENAME C CONTEM))
```

### *f)* 

```
 MedicosDistintos ← γ num_utente, nome, COUNT_DISTINCT(id_medico) → qtd (PACIENTE ⨝ num_utente=utente_paciente (σ num_prescricao ≠ NULL CONSULTA)) π nome (σ qtd > 1 (MedicosDistintos))
```
