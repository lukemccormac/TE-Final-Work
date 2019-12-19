
USE AnimalHospital

DROP DATABASE AnimalHospital;
CREATE DATABASE AnimalHospital;
USE AnimalHospital;

BEGIN TRANSACTION

CREATE TABLE Owner(
	address nvarchar(50) NOT NULL,
	first_name nvarchar(50) NOT NULL,
	last_name nvarchar(50) NOT NULL,
	owner_id int NOT NULL,

	PRIMARY KEY (owner_id)
	);



CREATE TABLE Pet(
	pet_id int NOT NULL,
	pet_name nvarchar(50) NOT NULL,
	pet_type nvarchar(50),
	pet_age int,
	owner_id int NOT NULL,

	PRIMARY KEY (pet_id)
	);

CREATE TABLE [Procedure](
	procedure_id int NOT NULL,
	pet_id int NOT NULL,
	cost int,

	PRIMARY KEY (procedure_id)
	);

CREATE TABLE PetProcedure(
	pet_id int NOT NULL,
	procedure_id INT NOT NULL,
	date_of nvarchar(50),
	petprocedure_id INT NOT NULL,

	PRIMARY KEY (petprocedure_id)
	);

CREATE TABLE Invoice(
	owner_id int NOT NULL,
	pet_id int NOT NULL,
	petprocedure_id int NOT NULL,
	balance int,
	invoice_number int NOT NULL,
	invoive_date nvarchar(50) NOT NULL,
	hospital nvarchar(50) NOT NULL,
	procedure_id int NOT NULL,

	PRIMARY KEY (invoice_number)
	);

	ALTER TABLE Pet
	ADD FOREIGN KEY (owner_id) REFERENCES Owner (owner_id)

	ALTER TABLE [Procedure]
	ADD FOREIGN KEY (pet_id) REFERENCES Pet (pet_id)


	ALTER TABLE PetProcedure
	ADD FOREIGN KEY (pet_id) REFERENCES Pet (pet_id)
	ALTER TABLE PetProcedure
	Add FOREIGN KEY (petprocedure_id) REFERENCES [Procedure] (procedure_id)

	ALTER TABLE Invoice
	ADD FOREIGN KEY (owner_id) REFERENCES Owner (owner_id)
	ALTER TABLE Invoice
	ADD FOREIGN KEY (pet_id) REFERENCES Pet (pet_id)
	ALTER TABLE Invoice
	ADD FOREIGN KEY (petprocedure_id) REFERENCES PetProcedure (petProcedure_id)
	ALTER TABLE Invoice
	ADD FOREIGN KEY (procedure_id) REFERENCES [Procedure] (procedure_id)

	COMMIT




