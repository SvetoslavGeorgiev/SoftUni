--Problem 1.	Employee Address

SELECT TOP(5) [EmployeeID], [JobTitle], [e].[AddressID], [a].[AddressText]
	FROM [Employees] AS [e]
	LEFT JOIN [Addresses] AS [a]
	ON [e].[AddressID] = [a].[AddressID]
	ORDER BY [e].[AddressID]


--Problem 2.	Addresses with Towns

SELECT TOP(50) [FirstName], [LastName], [t].[Name] AS [Town], [a].[AddressText]
	FROM [Employees] AS [e]
	JOIN [Addresses] AS [a]
	ON [e].[AddressID] = [a].[AddressID]
	JOIN [Towns] AS [t]
	ON [a].[TownID] = [t].TownID
	ORDER BY [e].[FirstName], [e].[LastName]

--Problem 3.	Sales Employee

  SELECT [EmployeeID], [FirstName], [LastName], 
         [Name] 
      AS [DepartmentName]
    FROM [Employees]
	  AS [e]
    JOIN [Departments] 
	  AS [d]
	  ON [e].[DepartmentID] = [d].[DepartmentID]
   WHERE [d].[Name] IN ('Sales')
ORDER BY [EmployeeID]

--Problem 4.	Employee Departments


SELECT TOP(5) [EmployeeID], [FirstName], [Salary], 
         [Name] 
      AS [DepartmentName]
    FROM [Employees]
	  AS [e]
    JOIN [Departments] 
	  AS [d]
	  ON [e].[DepartmentID] = [d].[DepartmentID]
   WHERE [e].[Salary] > 15000
ORDER BY [d].[DepartmentID]

--Problem 5.	Employees Without Project


SELECT TOP(3) [e].[EmployeeID], [FirstName]
	     FROM [Employees] AS [e]
    LEFT JOIN [EmployeesProjects] AS [ep]
	       ON [e].[EmployeeID] = [ep].[EmployeeID]
	    WHERE [ep].[ProjectID] IS NULL
	 ORDER BY [e].[EmployeeID]


--Problem 6.	Employees Hired After

   SELECT [FirstName], [LastName], [HireDate], [Name] AS [DeptName]
     FROM [Employees] AS [e]
LEFT JOIN [Departments] AS [d]
	   ON [e].[DepartmentID] = [d].[DepartmentID]
	WHERE [e].[HireDate] > '1999-01-01'
      AND [d].[Name] IN ('Sales', 'Finance')
 ORDER BY [HireDate]


