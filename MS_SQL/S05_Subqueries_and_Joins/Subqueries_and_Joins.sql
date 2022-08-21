--Problem 1.	Employee Address

SELECT TOP(5) [EmployeeID], [JobTitle], [e].[AddressID], [a].[AddressText]
	FROM [Employees] AS [e]
	JOIN [Addresses] AS [a]
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




