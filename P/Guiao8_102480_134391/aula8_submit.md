# BD: Guião 8


## ​8.1
 
### *a)*

```
CREATE PROCEDURE DeleteEmployee
    @ssn INT
AS
BEGIN TRAN
    SET NOCOUNT ON;

    DELETE FROM works_on
    WHERE essn = @ssn;

    DELETE FROM dependent
    WHERE essn = @ssn;

    UPDATE department
    SET mgr_ssn = NULL, Mgr_start_date = NULL
    WHERE mgr_ssn = @ssn;

    DELETE FROM employee
    WHERE ssn = @ssn;
END TRAN;
```

### *b)* 

```
CREATE PROCEDURE GetManagerYears
AS
BEGIN
    SET NOCOUNT ON;

	BEGIN TRAN
	SELECT e.Ssn, e.Fname, e.Lname, d.Dname, d.Mgr_start_date
	FROM EMPLOYEE AS e INNER JOIN DEPARTMENT AS d ON e.Ssn = d.Mgr_ssn

	SELECT TOP 1 e.Ssn, e.Fname, e.Lname, DATEDIFF(YEAR, d.Mgr_start_date, GETDATE()) as years_as_manager
	FROM EMPLOYEE AS e INNER JOIN DEPARTMENT AS d ON e.Ssn = d.Mgr_ssn
	ORDER BY d.Mgr_start_date ASC

	COMMIT TRAN
END;
```

### *c)* 

```
CREATE TRIGGER trg_OneManagerPerDepartment
ON department
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT mgr_ssn
        FROM department
        WHERE mgr_ssn IS NOT NULL
        GROUP BY mgr_ssn
        HAVING COUNT(*) > 1
    )
    BEGIN
        PRINT 'An employee cannot manage more than one department.';
        ROLLBACK TRANSACTION;
    END
END;
```

### *d)* 

```
CREATE TRIGGER trg_CheckSalary
ON employee
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE e
    SET e.salary = m.salary - 1
    FROM employee AS e
    INNER JOIN inserted AS i ON e.ssn = i.ssn
    INNER JOIN department AS d ON e.dno = d.dnumber
    INNER JOIN employee AS m ON d.mgr_ssn = m.ssn
    WHERE e.salary > m.salary;
END;
```

### *e)* 

```
CREATE FUNCTION EmployeeProjects(@ssn INT)
RETURNS TABLE
AS
RETURN
(
    SELECT p.Pname, p.Plocation
    FROM project p
    INNER JOIN works_on w ON p.Pnumber = w.Pno
    WHERE w.Essn = @ssn
);
```

### *f)* 

```
CREATE FUNCTION EmployeeDeptHighAverage(@dno INT)
RETURNS TABLE
AS
RETURN
(
    SELECT fname, lname, salary
    FROM employee
    WHERE dno = @dno
    AND salary >
    (
        SELECT AVG(salary)
        FROM employee
        WHERE dno = @dno
    )
);
```

### *g)* 

```
... Write here your answer ...
```

### *h)* 

```
... Write here your answer ...
```

### *i)* 

```
... Write here your answer ...
```
