--Problem 1.	Create Database

CREATE DATABASE [Minions]

USE [Minions]

--Problem 2.	Create Tables

CREATE TABLE [Minions](
	[Id] INT PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
	[Age] INT NOT NULL
)


CREATE TABLE [Towns](
	[Id] INT PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL
)

--Problem 3.	Alter Minions Table

ALTER TABLE [Minions]
ADD [TownId] INT FOREIGN KEY REFERENCES [Towns](Id)

SET IDENTITY_INSERT [Minions] ON

SET IDENTITY_INSERT [Towns] OFF


--Problem 4.	Insert Records in Both Tables

INSERT INTO [Towns]([Id], [Name])
      VALUES
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

ALTER TABLE [Minions]
ALTER COLUMN [Age] INT



INSERT INTO [Minions]([Id], [Name], [Age], [TownId])
	VALUES
(1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3, 'Steward', NULL, 2)

SELECT * FROM [Minions]
SELECT * FROM [Towns]



--Problem 5.	Truncate Table Minions

TRUNCATE TABLE [Minions]


-- Problem 6.	Drop All Tables

DROP TABLE [Minions], [Towns]


--Problem 7.	Create Table People


CREATE TABLE [People](
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARBINARY(MAX),
	CHECK (DATALENGTH([Picture]) <= 2000000),
	[Height] DECIMAL(3,2),
	[Weight] DECIMAL(5,2),
	[Gender] CHAR(1) NOT NULL,
	CHECK ([Gender] = 'm' OR [Gender] = 'f'),
	[Birthdate] DATE NOT NULL,
	[Biography] NVARCHAR(MAX)
)

INSERT INTO [People]([Name], [Height], [Weight], [Gender], [Birthdate])
	VALUES
('Pesho', 1.85, 78.50, 'm', '1988-09-27'),
('Gosho', 1.75, 98.50, 'm', '1983-09-05'),
('Maria', 1.68, 48.50, 'f', '1999-12-07'),
('Ivan', 1.95, 91.05, 'm', '1986-05-15'),
('Silvia', 1.77, 55.00, 'f', '1996-11-30')


SELECT * FROM [People]


-- Problem 8.	Create Table Users -> first variant for judge.softuni.org

CREATE TABLE [Users](
	[Id] BIGINT PRIMARY KEY IDENTITY NOT NULL,
	[Username] VARCHAR(30) NOT NULL UNIQUE,
	[ProfilePassword] VARCHAR(26) NOT NULL,
	[Picture] VARBINARY(MAX),
	CHECK (DATALENGTH([Picture]) <= 900000),
	[LastLoginTime] TIME,
	[IsDeleted] BIT
)


INSERT INTO [Users]([Username], [ProfilePassword], [LastLoginTime], [IsDeleted])
	VALUES
('Pesho', 'SADGASGSFDNJsukjh', '15:25:33', 'true'),
('Ico', 'SADGAfsahfhsukjh', '15:03:33', 'true'),
('Gosho', 'SADGAdshsNJsukjh', '12:49:58', 'false'),
('Ivan', 'SADGAdshsNJsusadkjh', '09:49:58', 'false'),
('Niki', 'SADasdGAdshsNJsukjh', '11:49:58', 'true')


SELECT * FROM [Users]


-- Problem 8.	Create Table Users -> second variant for judge.softuni.org

CREATE TABLE [Users](
	[Id] BIGINT PRIMARY KEY IDENTITY NOT NULL,
	[Username] VARCHAR(30) NOT NULL,
	[ProfilePassword] VARCHAR(26) NOT NULL,
	[Picture] VARBINARY(MAX),
	CHECK (DATALENGTH([Picture]) <= 900000),
	[LastLoginTime] DATETIME2,
	[IsDeleted] BIT DEFAULT 0
)


INSERT INTO [Users]([Username], [ProfilePassword], [LastLoginTime])
	VALUES
('Pesho', 'SADGASGSFDNJsukjh', (CURRENT_TIMESTAMP)),
('Ico', 'SADGAfsahfhsukjh', (CURRENT_TIMESTAMP)),
('Gosho', 'SADGAdshsNJsukjh', (CURRENT_TIMESTAMP)),
('Ivan', 'SADGAdssdahsNJsukjh', (CURRENT_TIMESTAMP)),
('Niki', 'SADGasdAdshsNJsukjh', (CURRENT_TIMESTAMP))


SELECT * FROM [Users]

-- Problem 8.	Create Table Users -> third variant for judge.softuni.org

CREATE TABLE [Users](
	[Id] BIGINT PRIMARY KEY IDENTITY NOT NULL,
	[Username] VARCHAR(30) NOT NULL,
	[ProfilePassword] VARCHAR(26) NOT NULL,
	[Picture] VARBINARY(MAX),
	CHECK (DATALENGTH([Picture]) <= 900000),
	[LastLoginTime] DATETIME2,
	[IsDeleted] BIT
)


INSERT INTO [Users]([Username], [ProfilePassword], [LastLoginTime], [IsDeleted])
	VALUES
('Pesho', 'SADGASGSFDNJsukjh', (CURRENT_TIMESTAMP), 1),
('Ico', 'SADGAfsahfhsukjh', (CURRENT_TIMESTAMP), 0),
('Gosho', 'SADGAdshsNJsukjh', (CURRENT_TIMESTAMP), 1),
('Ivo', 'gfahathartahah', (CURRENT_TIMESTAMP), 0),
('Ivan', 'afdasf', (CURRENT_TIMESTAMP), 1)


SELECT * FROM [Users]


--Problem 9.	Change Primary Key

ALTER TABLE 
[Users] DROP CONSTRAINT [PK__Users__3214EC07D3B56B0D]



ALTER TABLE [Users]
  ADD CONSTRAINT [Pk_Users] PRIMARY KEY (Id,Username);


--Problem 10.	Add Check Constraint

ALTER TABLE [Users]
  ADD CHECK (DATALENGTH([ProfilePassword]) >= 5)

--Problem 11.	Set Default Value of a Field

ALTER TABLE [Users] 
ADD DEFAULT (CURRENT_TIMESTAMP) FOR [LastLoginTime]


--Problem 12.	Set Unique Field

ALTER TABLE 
  [Users] DROP CONSTRAINT [PK_Users]

ALTER TABLE [Users]
  ADD CONSTRAINT [Pk_Users] PRIMARY KEY (Id);

ALTER TABLE [Users] 
   ADD UNIQUE ([Username])


--Problem 13.	Movies Database


CREATE TABLE [Directors](
	[Id] INT PRIMARY KEY IDENTITY,
	[DirectorName] NVARCHAR(25) NOT NULL,
	[Notes] NVARCHAR(50)
)

CREATE TABLE [Genres](
	[Id] INT PRIMARY KEY IDENTITY,
	[GenreName] NVARCHAR(50) NOT NULL,
	[Notes] TEXT
)

CREATE TABLE [Categories](
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryName] NVARCHAR(50) NOT NULL,
	[Notes] TEXT
)

CREATE TABLE [Movies](
	[Id] INT PRIMARY KEY IDENTITY,
	[Title] NVARCHAR(50) NOT NULL,
	[DirectorId] INT FOREIGN KEY REFERENCES [Directors]([Id]),
	[CopyrightYear] DECIMAL(4,0),
	[Length] TIME,
	[GenreId] INT FOREIGN KEY REFERENCES [Genres]([Id]),
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]),
	[Rating] DECIMAL(2,1),
	[Notes] TEXT
)

INSERT INTO [Directors]([DirectorName])
      VALUES
('Pesho'),
('Slavi'),
('Pesho'),
('Ivan'),
('Gosho')


INSERT INTO [Genres]([GenreName])
      VALUES
('Horror'),
('Comedy'),
('Sci-Fi'),
('Thriller'),
('Fantasy')

INSERT INTO [Categories]([CategoryName])
      VALUES
('Action'),
('Drama'),
('Mystery'),
('Thriller'),
('Western')

INSERT INTO [Movies]([Title], [DirectorId], [CopyrightYear], [Length], [GenreId], [CategoryId], [Rating])
      VALUES
('DSFG', 3, 2021, '03:45:25', 1, 2, 9.8),
('FGA', 2, 2021, '01:45:36', 4, 2, 7.7),
('HGFDH', 1, 2021, '01:35:45', 2, 2, 3.8),
('DSGFDFG', 4, 2021, '01:15:35', 3, 2, 7.8),
('DSGFDGFG', 5, 2021, '02:45:15', 5, 2, 1.2)


SELECT * FROM[Directors]
SELECT * FROM [Genres]
SELECT * FROM [Categories]
SELECT * FROM [Movies]

DROP TABLE [Categories]
DROP TABLE [Customers]

--Problem 14.	Car Rental Database

CREATE TABLE [Categories](
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryName] NVARCHAR(50) NOT NULL,
	[DailyRate] DECIMAL(7,2),
	[WeeklyRate] DECIMAL(7,2),
	[MonthlyRate] DECIMAL(7,2),
	[WeekendRate] DECIMAL(7,2)
)


CREATE TABLE [Cars](
	[Id] INT PRIMARY KEY IDENTITY,
	[PlateNumber] NVARCHAR(20) NOT NULL,
	[Manufacturer] NVARCHAR(20) NOT NULL,
	[Model] NVARCHAR(20) NOT NULL,
	[CarYear] DECIMAL(4,0),
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]),
	[Doors] DECIMAL(1,0),
	[Picture] VARBINARY(MAX),
	CHECK (DATALENGTH([Picture]) <= 2000000),
	[Condition] NVARCHAR(15),
	[Available] BIT
)

CREATE TABLE [Employees](
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(25) NOT NULL,
	[LastName] NVARCHAR(25) NOT NULL,
	[Title] NVARCHAR(10),
	[Notes] TEXT
)

CREATE TABLE [Customers](
	[Id] INT PRIMARY KEY IDENTITY,
	[DriverLicenceNumber] NVARCHAR(40) NOT NULL,
	[FullName] NVARCHAR(25) NOT NULL,
	[Address] TEXT,
	[ZIPCode] NVARCHAR(15),
	[Notes] TEXT
)

CREATE TABLE [RentalOrders](
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]),
	[CustomerId] INT FOREIGN KEY REFERENCES [Customers]([Id]),
	[CarId] INT FOREIGN KEY REFERENCES [Cars]([Id]),
	[TankLevel] NVARCHAR(10) NOT NULL,
	[KilometrageStart] DECIMAL(4,1),
	[KilometrageEnd] DECIMAL(4,1),
	[TotalKilometrage] DECIMAL(10,0),
	[StartDate] DATE NOT NULL,
	[EndDate] DATE NOT NULL,
	[TotalDays] DECIMAL(4,0),
	[RateApplied] DECIMAL(7,2),
	[TaxRate] DECIMAL(7,2),
	[OrderStatus] NVARCHAR(15),
	[Notes] TEXT
)

INSERT INTO [Categories]([CategoryName], [DailyRate], [WeeklyRate], [WeekendRate])
      VALUES
('practical', 59.99, 255.28, 122.25),
('comfortable',65.89, 299.87, 165.33),
('economical', 45.77, 199.54, 135.39)

INSERT INTO [Cars]([PlateNumber], [Manufacturer], [Model], [CarYear], [CategoryId], [Doors], [Available])
      VALUES
('EH0212BP', 'Opel', 'Astra', 1992, 1, 4, 'true'),
('EH02da2BP', 'Oasdel', 'Astasda', 2005, 2, 4, 'true'),
('EHasd212BP', 'Opasdl', 'Astasdasa', 2022, 3, 2, 'false')


INSERT INTO [Employees]([FirstName], [LastName])
	VALUES
('Petar', 'Ivanov'),
('Stoyan', 'Georgiev'),
('Ivan', 'Petrov')

INSERT INTO [Customers]([DriverLicenceNumber], [FullName], [ZIPCode])
	VALUES
('JIGLAKFJFJHGDHASF', 'Petar Georgiev', '528000BT'),
('JIdasdFJFJHGDHASF', 'Milen Georgiev', '5246540BT'),
('JIGLAKFJFgfdgfDHASF', 'Petar Stoyanov', '5280655BT')

INSERT INTO [RentalOrders]([EmployeeId], [CustomerId], [CarId], [TankLevel], [StartDate], [EndDate], [OrderStatus])
	VALUES
(1, 3, 2, 'FULL', '1988-09-27', '1988-10-27', 'Complete'),
(2, 3, 3, 'HALF', '2022-05-27', '2022-10-15', 'Alieve'),
(3, 1, 1, 'EMPTY', '1989-12-27', '1990-11-05', 'Complete')


SELECT * FROM [Categories]
SELECT * FROM [Cars]
SELECT * FROM [Employees]
SELECT * FROM [Customers]
SELECT * FROM [RentalOrders]


-- Problem 15.	Hotel Database

CREATE TABLE [Employees](
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(25) NOT NULL,
	[LastName] NVARCHAR(25) NOT NULL,
	[Title] NVARCHAR(10),
	[Notes] TEXT
)

CREATE TABLE [Customers](
	[Accountnumber] DECIMAL(10,0) PRIMARY KEY NOT NULL,
	[FirstName] NVARCHAR(15) NOT NULL,
	[LastName] NVARCHAR(15) NOT NULL,
	[PhoneNumber] DECIMAL(10,0) NOT NULL,
	[EmergencyName] NVARCHAR(25),
	[EmergencyNumber] DECIMAL(10,0),
	[Notes] TEXT
)

CREATE TABLE [RoomStatus](
	[RoomStatus] NVARCHAR(10) PRIMARY KEY NOT NULL,
	[Notes] TEXT
)

CREATE TABLE [RoomTypes](
	[RoomType] NVARCHAR(10) PRIMARY KEY NOT NULL,
	[Notes] TEXT
)

CREATE TABLE [BedTypes](
	[BedType] NVARCHAR(10) PRIMARY KEY NOT NULL,
	[Notes] TEXT
)

CREATE TABLE [Rooms](
	[RoomNumber] SMALLINT PRIMARY KEY NOT NULL,
	[RoomType] NVARCHAR(10) FOREIGN KEY REFERENCES [RoomTypes]([RoomType]),
	[BedType] NVARCHAR(10) FOREIGN KEY REFERENCES [BedTypes]([BedType]),
	[Rate] DECIMAL(7,2) NOT NULL,
	[RoomStatus] NVARCHAR(10) FOREIGN KEY REFERENCES [RoomStatus]([RoomStatus]),
	[Notes] TEXT
)

CREATE TABLE [Payments](
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]),
	[PaymentDate] DATE,
	[AccountNumber] DECIMAL(10,0) FOREIGN KEY REFERENCES [Customers]([AccountNumber]),
	[FirstDateOccupied] DATE NOT NULL,
	[LastDateOccupied] DATE NOT NULL,
	[TotalDays] DECIMAL(4,0),
	[AmountCharged] DECIMAL(7,2),
	[TaxRate] DECIMAL(4,2),
	[TaxAmount] DECIMAL(7,2),
	[PaymentTotal] DECIMAL(7,2),
	[Notes] TEXT
)

CREATE TABLE [Occupancies](
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]),
	[DateOccupied] DATE NOT NULL,
	[AccountNumber] DECIMAL(10,0) FOREIGN KEY REFERENCES [Customers]([AccountNumber]),
	[RoomNumber] SMALLINT FOREIGN KEY REFERENCES [Rooms]([RoomNumber]),
	[RateApplied] DECIMAL(5,2),
	[PhoneCharge] DECIMAL(5,2),
	[Notes] TEXT
)

INSERT INTO [Employees]([FirstName], [LastName])
	VALUES
('Petar', 'Ivanov'),
('Stoyan', 'Georgiev'),
('Ivan', 'Petrov')

INSERT INTO [Customers]([AccountNumber], [FirstName], [LastName], [PhoneNumber])
	VALUES
(1234567890, 'Petar', 'Ivanov', 0886656814),
(1234667890, 'Stoyan', 'Georgiev', 0685456814),
(1234567990, 'Ivan', 'Petrov', 0886855681)

INSERT INTO [RoomStatus]([RoomStatus])
	VALUES
('Available'),
('occupated'),
('Cleening')

INSERT INTO [RoomTypes]([RoomType])
	VALUES
('Double'),
('Single'),
('Famaly')

INSERT INTO [BedTypes]([BedType])
	VALUES
('Double'),
('KingSize'),
('Single')

INSERT INTO [Rooms]([RoomNumber], [RoomType], [BedType], [Rate], [RoomStatus])
	VALUES
(122, 'Double', 'Double', 25.50, 'Available'),
(132, 'Double', 'Single', 15.50, 'occupated'),
(322, 'Double', 'KingSize', 45.50, 'Cleening')

INSERT INTO [Payments]([EmployeeId], [AccountNumber], [PaymentDate], [FirstDateOccupied], [LastDateOccupied])
	VALUES
(1, 1234567890, '2020-05-27', '2022-05-27', '2022-09-27'),
(2, 1234667890, '2021-05-27', '2022-06-15', '2022-09-01'),
(3, 1234567990, '2021-06-27', '2022-09-27', '2023-01-15')

INSERT INTO [Occupancies]([EmployeeId], [DateOccupied], [AccountNumber], [RoomNumber])
	VALUES
(1, '2022-05-27', 1234567890, 122),
(2, '2022-06-27', 1234667890, 132),
(3, '2022-09-27', 1234567990, 322)


SELECT * FROM [Employees]
SELECT * FROM [Customers]
SELECT * FROM [RoomStatus]
SELECT * FROM [RoomTypes]
SELECT * FROM [BedTypes]
SELECT * FROM [Rooms]
SELECT * FROM [Payments]
SELECT * FROM [Occupancies]

--Problem 16.	Create SoftUni Database




--Problem 19.	Basic Select All Fields

SELECT * FROM [Towns]
SELECT * FROM [Departments]
SELECT * FROM [Employees]

--Problem 20.	Basic Select All Fields and Order Them

SELECT * FROM [Towns] ORDER BY [Name] ASC;
SELECT * FROM [Departments] ORDER BY [Name] ASC;
SELECT * FROM [Employees] ORDER BY [Salary] DESC;

--Problem 21.	Basic Select Some Fields

SELECT [Name] FROM [Towns] ORDER BY [Name] ASC;
SELECT [Name] FROM [Departments] ORDER BY [Name] ASC;
SELECT [FirstName], [LastName], [JobTitle], [Salary] FROM [Employees] ORDER BY [Salary] DESC;

--Problem 22.	Increase Employees Salary

--CREATE TABLE [Money](
--	[Id] INT PRIMARY KEY IDENTITY,
--	[FirstName] NVARCHAR(25) NOT NULL,
--	[LastName] NVARCHAR(25) NOT NULL,
--	[Salary] DECIMAL(7, 2),
--	[Notes] TEXT
--)

--INSERT INTO [Money]([FirstName], [LastName], [Salary])
--	VALUES
--('Double', 'GFU', 25.25),
--('Single', 'UGDSAF', 37.25),
--('Famaly', 'JHUFALHD', 45.78)


UPDATE [Employees]
	SET [Salary] = [Salary] + ([Salary] * 0.1)

SELECT [Salary] FROM [Employees]


--Problem 23.	Decrease Tax Rate

UPDATE [Payments]
	SET [TaxRate] = [TaxRate] - ([TaxRate] * 0.03)

SELECT [TaxRate] FROM [Payments]

--Problem 24.	Delete All Records


TRUNCATE TABLE [Occupancies]


-- RANAMING COLUNM
EXEC sp_RENAME 'Rooms.LastName', 'BedType'