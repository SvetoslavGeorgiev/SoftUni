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

CREATE TABLE [Teachers](
	[TeacherID] INT PRIMARY KEY IDENTITY(101,1),
	[Name] NVARCHAR(15) NOT NULL,
	[ManagerID] INT REFERENCES [Teachers]([TeacherID])
)


INSERT INTO [Teachers]([Name], [ManagerID])
	VALUES
('John', Null),
('Maya', 106),
('Silvia', 106),
('Ted', 105),
('Mark', 101),
('Greta', 101)


--Problem 5.	Online Store Database

CREATE DATABASE [OnlineStore]

USE [OnlineStore]

CREATE TABLE [Cities](
	[CityID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Customers](
	[CustomerID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[Birthday] DATE,
	[CityID] INT FOREIGN KEY REFERENCES [Cities]([CityID])
)

CREATE TABLE [Orders](
	[OrderID] INT PRIMARY KEY IDENTITY,
	[CustomerID] INT FOREIGN KEY REFERENCES [Customers]([CustomerID])
)

CREATE TABLE [ItemTypes](
	[ItemTypeID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Items](
	[ItemID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[ItemTypeID] INT FOREIGN KEY REFERENCES [ItemTypes]([ItemTypeID])
)

CREATE TABLE [OrderItems](
	[OrderID] INT FOREIGN KEY REFERENCES [Orders]([OrderID]),
	[ItemID] INT FOREIGN KEY REFERENCES [Items]([ItemID])

	CONSTRAINT PK_Order_Item PRIMARY KEY ([OrderID], [ItemID]) --or like this without name: PRIMARY KEY ([OrderID], [ItemID])
)

--Problem 6.	University Database

CREATE DATABASE [University]

USE [University]

CREATE TABLE [Majors](
	[MajorID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Students](
	[StudentID] INT PRIMARY KEY IDENTITY,
	[StudentNumber] DECIMAL(10,0),
	[StudentName] VARCHAR(50) NOT NULL,
	[MajorID] INT REFERENCES [Majors]([MajorID])
)

CREATE TABLE [Payments](
	[PaymentID] INT PRIMARY KEY IDENTITY,
	[PaymentDate] DATETIME2,
	[PaymentAmount] DECIMAL(7,2),
	[StudentID] INT REFERENCES [Students]([StudentID])
)

CREATE TABLE [Subjects](
	[SubjectID] INT PRIMARY KEY IDENTITY,
	[SubjectName] VARCHAR(50) NOT NULL
)

CREATE TABLE [Agenda](
	[StudentID] INT REFERENCES [Students]([StudentID]),
	[SubjectID] INT REFERENCES [Subjects]([SubjectID])

	PRIMARY KEY ([StudentID], [SubjectID])
)

--Problem 9.	*Peaks in Rila

   SELECT [m].[MountainRange], [p].[PeakName], [p].[Elevation]
     FROM [Mountains] AS [m]
LEFT JOIN [Peaks]  AS [p]
	   ON [p].[MountainID] = [m].[Id]
    WHERE [MountainRange] = 'Rila'
 ORDER BY [p].[Elevation] DESC


-- SECOND VARIANT

    SELECT [Mountains].[MountainRange], [PeakName], [Elevation]
      FROM [Peaks]
INNER JOIN [Mountains] 
        ON [Mountains].[Id] = [Peaks].[MountainId]
     WHERE [Mountains].[MountainRange] = 'Rila'
  ORDER BY [Elevation] DESC

--EXTRA BIT
SELECT *
	FROM [Students]

SELECT *
	FROM [Exams]

SELECT *
	FROM [StudentsExams]