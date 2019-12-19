DROP DATABASE IF EXISTS EmployeeInfo; 
CREATE DATABASE EmployeeInfo; 
USE EmployeeInfo;
GO

BEGIN TRANSACTION

CREATE TABLE EmployeeData (
employee_number int IDENTITY,
job_title nvarchar (40) NOT NULL,
last_name nvarchar (40) NOT NULL,
first_name nvarchar (40) NOT NULL,
gender nvarchar (40) NOT NULL,
date_of_birth nvarchar (40) NOT NULL,
date_of_hire nvarchar (40) NOT NULL,
department_the_employee_works_for nvarchar (40) NOT NULL,

);
ALTER TABLE EmployeeData
ADD PRIMARY KEY (employee_number);

CREATE TABLE Department (

department_number int NOT NULL,
Name nvarchar (40) NOT NULL,
has_zero_to_many_employees int NOT NULL,
);

ALTER TABLE Department
ADD PRIMARY KEY (name);

CREATE TABLE Project (

project_number int NOT NULL,
name_of_project nvarchar (40) NOT NULL,
start_date nvarchar (40) NOT NULL,
has_zero_to_many_employees int NOT NULL,
);

ALTER TABLE Project
ADD PRIMARY KEY (project_number);


--ALTER TABLE EmployeeData 
--ADD FOREIGN KEY (department_the_employee_works_for) REFERENCES Department(name);


COMMIT TRANSACTION; 

INSERT INTO EmployeeData (job_title, last_name, first_name, gender, date_of_birth, date_of_hire, department_the_employee_works_for) 
VALUES ('Nurse', 'James', 'Lebron', 'Male', 'Septembe 8, 1991', 'September 1, 2018', 'Pediatrics');
INSERT INTO EmployeeData (job_title, last_name, first_name, gender, date_of_birth, date_of_hire, department_the_employee_works_for) 
VALUES ('Doctor', 'Jordan', 'Michael', 'Male', 'Septembe 4, 1984', 'October 8, 2016', 'Pediatrics');
INSERT INTO EmployeeData (job_title, last_name, first_name, gender, date_of_birth, date_of_hire, department_the_employee_works_for) 
VALUES ('PhysiciansAssistant', 'Smith', 'Claire', 'Female', 'August 2, 1985', 'July 7, 2015', 'Pediatrics');
INSERT INTO EmployeeData (job_title, last_name, first_name, gender, date_of_birth, date_of_hire, department_the_employee_works_for) 
VALUES ('Receptionist', 'Irving', 'Kyrie', 'Male', 'Septembe 8, 1991', 'September 1, 2018', 'FrontDesk');
INSERT INTO EmployeeData (job_title, last_name, first_name, gender, date_of_birth, date_of_hire, department_the_employee_works_for) 
VALUES ('Scheduler', 'James', 'Emily', 'Female', 'May 5, 2000', 'September 1, 2019', 'FrontDesk');
INSERT INTO EmployeeData (job_title, last_name, first_name, gender, date_of_birth, date_of_hire, department_the_employee_works_for) 
VALUES ('Nurse', 'Mayfield', 'Shaq', 'Male', 'January 4, 1965', 'June 5, 2013', 'Orthopedics');
INSERT INTO EmployeeData (job_title, last_name, first_name, gender, date_of_birth, date_of_hire, department_the_employee_works_for) 
VALUES ('Dcotor', 'Richards', 'Mary', 'Female', 'April 24, 1970', 'September 1, 2015', 'Orthopedics');
INSERT INTO EmployeeData (job_title, last_name, first_name, gender, date_of_birth, date_of_hire, department_the_employee_works_for) 
VALUES ('Physical Therapist', 'Johnson', 'Mark', 'Male', 'Septembe 7, 1980', 'August 7, 2018', 'Orthopedics');

INSERT INTO Department (department_number, Name, has_zero_to_many_employees) 
VALUES (1, 'Pediatrics', 3);
INSERT INTO Department (department_number, Name, has_zero_to_many_employees) 
VALUES (2, 'FrontDesk', 2);
INSERT INTO Department (department_number, Name, has_zero_to_many_employees) 
VALUES (3, 'Orthopedics', 3);

INSERT INTO Project (project_number, name_of_project, start_date, has_zero_to_many_employees)
VALUES (1, 'Research', 'September, 2 2010', 6);
INSERT INTO Project (project_number, name_of_project, start_date, has_zero_to_many_employees)
VALUES (2, 'Development', 'June, 7 2008', 4);
INSERT INTO Project (project_number, name_of_project, start_date, has_zero_to_many_employees)
VALUES (3, 'Top Secret', 'August 8, 2018', 9);
INSERT INTO Project (project_number, name_of_project, start_date, has_zero_to_many_employees)
VALUES (4, 'Robotics', 'June 8, 1990', 16);

SELECT * FROM Department
