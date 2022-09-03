--Problem 1.	Employees with Salary Above 35000

GO

CREATE PROCEDURE [usp_GetEmployeesSalaryAbove35000]
AS
BEGIN
	SELECT [FirstName],
		   [LastName]
	  FROM [Employees]
	 WHERE [Salary] > 35000
END


GO

--Problem 2.	Employees with Salary Above Number


GO

CREATE OR ALTER PROCEDURE [usp_GetEmployeesSalaryAboveNumber] @minSalary DECIMAL(18, 4)
AS
BEGIN
	SELECT [FirstName],
		   [LastName]
	  FROM [Employees]
	 WHERE [Salary] >= @minSalary
END


GO


--Problem 3.	Town Names Starting With

CREATE OR ALTER PROCEDURE [usp_GetTownsStartingWith] @startWith NVARCHAR(50)
AS
BEGIN
	SELECT [Name] AS [Town]
	  FROM [Towns]
	 WHERE LEFT ([NAME], LEN(@startWith)) = @startWith
END


GO