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

DROP TABLE [Movies]
TRUNCATE TABLE [Directors]