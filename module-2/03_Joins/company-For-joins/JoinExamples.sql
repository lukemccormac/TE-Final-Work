-- firstname, lastname and title of all employees with a position
SELECT * FROM Employee

SELECT employee.firstname, Employee.lastname, position.title FROM Employee
JOIN Position
ON Employee.position = position.id

-- title and department name of all positions assigned to an department
SELECT * FROM department

SELECT title, department.name FROM department
JOIN Position
ON department.id = Position.department

-- firstname, lastname, title, and department name of all assigned employees
SELECT * FROM Employee

SELECT firstname, lastname, title, name FROM Employee
JOIN Position 
ON Employee.position = position.id
JOIN Department
ON position.department = department.id
-- firstname and lastname of all employees (assigned or not), include title for those that are assigned

SELECT firstname, lastname, title FROM Employee
LEFT JOIN position 
ON employee.position = position.id
LEFT JOIN department
ON position.department = department.id 


SELECT * FROM Employee
LEFT JOIN position 
ON employee.position = position.id
LEFT JOIN department
ON position.department = department.id 

-- all position titles (assigned or not) and all employees assigned to a position (firstname and lastname)

SELECT * FROM Employee
RIGHT JOIN position
ON Employee.position=position.id

-- above, with the opposite outer join (left or right)
SELECT * FROM position
LEFT JOIN Employee
ON Employee.position=position.id

-- show all employees, asigned or not (firstname and lastname) and all poistion titles, asigned or not. Show mattches where they exist (FULL OUTER JOIN)


-- show all possible combinations of employees (firstname and lastname) and position titles, whether the combinations exist or not (CROSS JOIN)





--
--
--








SELECT e.firstname, e.lastname, p.title
FROM employee e
INNER JOIN position p on e.position = p.id
-- JOIN position p on e.position = p.id

SELECT p.title, d.name
FROM position p 
INNER JOIN department d on p.department = d.id

SELECT e.firstname, e.lastname, p.title, d.name
FROM employee e
INNER JOIN position p on e.position = p.id
INNER JOIN department d on p.department = d.id


SELECT e.firstname, e.lastname, p.title
FROM employee e
LEFT OUTER JOIN position p on e.position = p.id
--LEFT JOIN position p on e.position = p.id

SELECT e.firstname, e.lastname, p.title
FROM employee e
RIGHT OUTER JOIN position p on e.position = p.id


SELECT e.firstname, e.lastname, p.title
FROM position p 
LEFT OUTER JOIN employee e on e.position = p.id


SELECT e.firstname, e.lastname, p.title
FROM employee e
FULL OUTER JOIN position p on e.position = p.id
--FULL JOIN position p on e.position = p.id


SELECT e.firstname, e.lastname, p.title
FROM employee e
CROSS JOIN position p 



