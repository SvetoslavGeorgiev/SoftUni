--Problem 1.	One-To-One Relationship

CREATE TABLE [Passports](
	[PassportID] INT PRIMARY KEY IDENTITY(101,1),
	[PassportNumber] NVARCHAR(10) UNIQUE NOT NULL
)

CREATE TABLE [Persons](
	[PersonID] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(20) NOT NULL,
	[Salary] DECIMAL(7,2) NOT NULL,
	[PassportID] INT FOREIGN KEY REFERENCES [Passports]([PassportID]) UNIQUE
)

INSERT INTO [Passports]([PassportNumber])
	 VALUES
('N34FG21B'),
('K65LO4R7'),
('ZE657QP2')

INSERT INTO [Persons]([FirstName], [Salary], [PassportID])
	 VALUES
('Roberto', 43300.00, 102),
('Tom', 56100.00, 103),
('Yana', 60200.00, 101)


--Problem 2.	One-To-Many Relationship

CREATE TABLE [Manufacturers](
	[ManufacturerID] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(10) NOT NULL,
	[EstablishedOn] DATE
)



CREATE TABLE [Models](
	[ModelID] INT PRIMARY KEY IDENTITY(101,1),
	[Name] NVARCHAR(10) NOT NULL,
	[ManufacturerID] INT FOREIGN KEY REFERENCES [Manufacturers]([ManufacturerID])
)

INSERT INTO [Manufacturers]([Name])
	 VALUES
('BMW'),
('Tesla'),
('Lada')


INSERT INTO [Models]([Name], [ManufacturerID])
	 VALUES
('X1', 1),
('i6', 1),
('ModelS', 2),
('ModelX', 2),
('Model3', 2),
('Nova', 3)


--Problem 3.	Many-To-Many Relationship

CREATE TABLE [Students](
	[StudentID] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(15) NOT NULL,
)

CREATE TABLE [Exams](
	[ExamID] INT PRIMARY KEY IDENTITY(101,1),
	[Name] NVARCHAR(15) NOT NULL,
)

CREATE TABLE [StudentsExams](
	[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID]),
	[ExamID] INT FOREIGN KEY REFERENCES [Exams]([ExamID]),
	PRIMARY KEY([StudentID], [ExamID])
)

INSERT INTO [Students]([Name])
	 VALUES
('Mila'),
('Toni'),
('Ron')

INSERT INTO [Exams]([Name])
	 VALUES
('SpringMVC'),
('Neo4j'),
('Oracle 11g')


INSERT INTO [StudentsExams]([StudentID],[ExamID])
	 VALUES
(1 ,101),
(1, 102),
(2, 101),
(3, 103),
(2, 102),
(2, 103)

--Problem 4.	Self-Referencing 



--EXTRA BIT
SELECT *
	FROM [Students]

SELECT *
	FROM [Exams]

SELECT *
	FROM [StudentsExams]