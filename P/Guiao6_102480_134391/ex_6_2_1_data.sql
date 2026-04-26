USE Company;
GO

INSERT INTO DEPARTMENT (Dnumber, Dname, Mgr_ssn, Mgr_start_date) VALUES
(1, 'Investigacao', NULL, '2010-08-02'),
(2, 'Comercial', NULL, '2013-05-16'),
(3, 'Logistica', NULL, '2013-05-16'),
(4, 'Recursos Humanos', NULL, '2014-04-02'),
(5, 'Desporto', NULL, NULL);

INSERT INTO EMPLOYEE (Fname, Minit, Lname, Ssn, Bdate, Address, Sex, Salary, Super_ssn, Dno) VALUES
('Paula', 'A', 'Sousa', '183623612', '2001-08-11', 'Rua da FRENTE', 'F', 1450.00, NULL, 3),
('Carlos', 'D', 'Gomes', '21312332', '2000-01-01', 'Rua XPTO', 'M', 1200.00, NULL, 1),
('Juliana', 'A', 'Amaral', '321233765', '1980-08-11', 'Rua BZZZZ', 'F', 1350.00, NULL, 3),
('Maria', 'I', 'Pereira', '342343434', '2001-05-01', 'Rua JANOTA', 'F', 1250.00, '21312332', 2),
('Joao', 'G', 'Costa', '41124234', '2001-01-01', 'Rua YGZ', 'M', 1300.00, '21312332', 2),
('Ana', 'L', 'Silva', '12652121', '1990-03-03', 'Rua ZIG ZAG', 'F', 1400.00, '21312332', 2);

UPDATE DEPARTMENT SET Mgr_ssn = '21312332' WHERE Dnumber = 1;
UPDATE DEPARTMENT SET Mgr_ssn = '321233765' WHERE Dnumber = 2;
UPDATE DEPARTMENT SET Mgr_ssn = '41124234' WHERE Dnumber = 3;
UPDATE DEPARTMENT SET Mgr_ssn = '12652121' WHERE Dnumber = 4;

INSERT INTO DEPT_LOCATIONS (Dnumber, Dlocation) VALUES
(2, 'Aveiro'),
(3, 'Coimbra');

INSERT INTO PROJECT (Pnumber, Pname, Plocation, Dnum) VALUES
(1, 'Aveiro Digital', 'Aveiro', 3),
(2, 'BD Open Day', 'Espinho', 2),
(3, 'Dicoogle', 'Aveiro', 3),
(4, 'GOPACS', 'Aveiro', 3);

INSERT INTO WORKS_ON (Essn, Pno, Hours) VALUES
('183623612', 1, 20.0),
('183623612', 3, 10.0),
('21312332', 1, 20.0),
('321233765', 1, 25.0),
('342343434', 1, 20.0),
('342343434', 4, 25.0),
('41124234', 2, 20.0),
('41124234', 3, 30.0);

INSERT INTO DEPENDENT (Essn, Dependent_name, Sex, Bdate, Relationship) VALUES
('21312332', 'Joana Costa', 'F', '2008-04-01', 'Filho'),
('21312332', 'Maria Costa', 'F', '1990-10-05', 'Neto'),
('21312332', 'Rui Costa', 'M', '2000-08-04', 'Neto'),
('321233765', 'Filho Lindo', 'M', '2001-02-22', 'Filho'),
('342343434', 'Rosa Lima', 'F', '2006-03-11', 'Filho'),
('41124234', 'Ana Sousa', 'F', '2007-04-13', 'Neto'),
('41124234', 'Gaspar Pinto', 'M', '2006-02-08', 'Sobrinho');