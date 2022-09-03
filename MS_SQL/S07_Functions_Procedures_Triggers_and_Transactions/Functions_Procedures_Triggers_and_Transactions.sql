--Problem 1.	Employees with Salary Above 35000

GO

CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
AS
BEGIN
	SELECT [FirstName],
		   [LastName]
	  FROM [Employees]
	 WHERE [Salary] > 35000
END


GO