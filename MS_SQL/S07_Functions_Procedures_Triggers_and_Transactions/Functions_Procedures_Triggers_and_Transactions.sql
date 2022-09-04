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

GO


CREATE OR ALTER PROCEDURE [usp_GetTownsStartingWith] @startWith NVARCHAR(50)
AS
BEGIN
	SELECT [Name] AS [Town]
	  FROM [Towns]
	 WHERE LEFT ([NAME], LEN(@startWith)) = @startWith
END


GO

--Problem 4.	Employees from Town

GO


CREATE OR ALTER PROCEDURE [usp_GetEmployeesFromTown] @tonwName VARCHAR(50)
AS
BEGIN
	SELECT [FirstName] AS [First Name],
	       [LastName] AS [Last Name]
	  FROM [Employees] AS [e]
 LEFT JOIN [Addresses] AS [a]
		ON [e].[AddressID] = [a].[AddressID]
 LEFT JOIN [Towns] AS [t]
        ON [a].TownID = [t].[TownID]
	 WHERE [t].[Name] = @tonwName
END


GO


--Problem 5.	Salary Level Function

GO


CREATE OR ALTER FUNCTION [ufn_GetSalaryLevel](@salary DECIMAL(18,4))
RETURNS VARCHAR(8)
AS
BEGIN
     DECLARE @salaryLevel VARCHAR(8)

	 IF @salary < 30000
	 BEGIN
	     SET @salaryLevel = 'Low'
	 END
	 ELSE IF @salary BETWEEN 30000 AND 50000
	 BEGIN
	     SET @salaryLevel = 'Average'
	 END
	 ELSE IF @salary > 50000
	 BEGIN
	     SET @salaryLevel = 'High'
	 END
	 
	 RETURN @salaryLevel
END


GO

--Problem 6.	Employees by Salary Level

GO

CREATE OR ALTER PROCEDURE [usp_EmployeesBySalaryLevel] @salaryLevel VARCHAR(8)
AS
BEGIN
	SELECT [FirstName] AS [First Name],
	       [LastName] AS [Last Name]
	  FROM [Employees] AS [e]
	 WHERE [dbo].[ufn_GetSalaryLevel]([Salary]) = @salaryLevel
END

GO

EXEC [dbo].[usp_EmployeesBySalaryLevel] 'High'


--Problem 7.	Define Function
GO

CREATE OR ALTER FUNCTION [ufn_IsWordComprised](@setOfLetters VARCHAR(50), @word VARCHAR(50)) 
RETURNS BIT
AS
BEGIN
    DECLARE @currentIndex INT = 1;

    WHILE @currentIndex <= LEN(@word)
	BEGIN

	DECLARE @currentLetter VARCHAR(1) = SUBSTRING(@word, @currentIndex, 1);

	IF(CHARINDEX(@currentLetter, @setOfLetters)) = 0
	BEGIN
	RETURN 0;
	END

	SET @currentIndex += 1;
	END

    RETURN 1;
END


GO


--Problem 8.	* Delete Employees and Departments

GO

CREATE OR ALTER PROCEDURE [usp_DeleteEmployeesFromDepartment](@departmentId INT)
AS
BEGIN
	 DELETE FROM [EmployeesProjects]
		   WHERE [EmployeeID] IN (
								  SELECT [EmployeeID]
								    FROM [Employees]
							       WHERE [DepartmentID] = @departmentId
								 )
	 UPDATE [Employees]
	    SET [ManagerID] = NULL
	  WHERE [ManagerID] IN (
							 SELECT [EmployeeID]
							   FROM [Employees]
							  WHERE [DepartmentID] = @departmentId
						   )
	  ALTER TABLE [Departments]
	 ALTER COLUMN [ManagerID] INT

	 UPDATE [Departments]
		SET [ManagerID] = NULL
	  WHERE [ManagerID] IN (
							 SELECT [EmployeeID]
							   FROM [Employees]
							  WHERE [DepartmentID] = @departmentId
						   )
	 DELETE FROM [Employees]
		   WHERE [DepartmentID] = @departmentId

	 DELETE FROM [Departments]
	       WHERE [DepartmentID] = @departmentId

	 SELECT COUNT([EmployeeId])
	   FROM [Employees]
	  WHERE [DepartmentID] = @departmentId
END

GO

EXECUTE [dbo].[usp_DeleteEmployeesFromDepartment] 2
