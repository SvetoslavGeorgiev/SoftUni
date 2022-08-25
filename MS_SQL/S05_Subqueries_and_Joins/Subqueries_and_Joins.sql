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


 --Problem 7.	Employees with Project

SELECT TOP(5) [e].[EmployeeID], [e].[FirstName], [p].[Name] AS [ProjectName]
	     FROM [Employees] AS [e]
   INNER JOIN [EmployeesProjects] AS [ep]
	       ON [e].[EmployeeID] = [ep].[EmployeeID]
   INNER JOIN [Projects] AS [p]
	       ON [ep].[ProjectID] = [p].[ProjectID]
	    WHERE [p].[StartDate] > '2002-08-13' AND [p].[EndDate] IS NULL
	 ORDER BY [e].[EmployeeID]


--8.Problem	Employee 24

SELECT [e].[EmployeeID], [e].[FirstName],
	   CASE
		      WHEN DATEPART(YEAR, [p].[StartDate]) > '2004' THEN NULL
			  ELSE [p].[Name]
	   END AS [ProjectName]
  FROM [Employees] AS [e]
  JOIN [EmployeesProjects] AS [ep]
    ON [e].[EmployeeID] = [ep].[EmployeeID]
  JOIN [Projects] AS [p]
    ON [ep].[ProjectID] = [p].[ProjectID]
 WHERE [e].[EmployeeID] IN (24)
   

--Problem 9.	Employee Manager


    SELECT [e].[EmployeeID], [e].[FirstName], [e].[ManagerID], [m].[FirstName] AS [ManagerName]
      FROM [Employees] AS [e]
INNER JOIN [Employees] AS [m]
        ON [e].[ManagerID] = [m].[EmployeeID]
     WHERE [e].[ManagerID] IN (3, 7)
  ORDER BY [e].[EmployeeID]


--Problem 10. Employee Summary

SELECT TOP(50) [e].[EmployeeID], CONCAT([e].[FirstName], ' ', [e].[LastName]) AS [EmployeeName], CONCAT([m].[FirstName], ' ', [m].[LastName]) AS [ManagerName], [d].[Name]
	      FROM [Employees] AS [e]
    INNER JOIN [Employees] AS [m]
	        ON [e].[ManagerID] = [m].[EmployeeID]
     LEFT JOIN [Departments] AS [d]
            ON [e].[DepartmentID] = [d].[DepartmentID]
      ORDER BY [e].[EmployeeID]


--Problem 11. Min Average Salary

SELECT MIN([avg]) AS [MinAverageSalary]
	FROM (
	        SELECT AVG([Salary]) AS [avg]
			      FROM [Employees]
			  GROUP BY [DepartmentID]
	     ) AS [AverageSalaries]



USE [Geography]

--Problem 12. Highest Peaks in Bulgaria

     SELECT [mc].[CountryCode], [m].[MountainRange], [p].[PeakName], [p].[Elevation]
       FROM [Peaks] AS [p]
 INNER JOIN [Mountains] AS [m]
         ON [p].[MountainId] = [m].[Id]
 INNER JOIN [MountainsCountries] AS [mc]
         ON [m].[Id] = [mc].[MountainId]
      WHERE [mc].[CountryCode] = 'BG' AND [p].[Elevation] > 2835
   ORDER BY [p].[Elevation] DESC


--Problem 13. Count Mountain Ranges


   SELECT [c].[CountryCode], COUNT([mc].[CountryCode]) AS [MountainRanges]
     FROM [Countries] AS [c]
LEFT JOIN [MountainsCountries] AS [mc]
       ON [c].[CountryCode] = [mc].[CountryCode]
    WHERE [c].[CountryCode] IN ('BG', 'US', 'RU')
 GROUP BY [c].[CountryCode]

--Problem 14. Countries With or Without Rivers

SELECT TOP(5) [c].[CountryName], [r].[RiverName]
         FROM [Countries] AS [c]
   INNER JOIN [Continents] AS [con]
           ON [c].[ContinentCode] = [con].[ContinentCode]
    LEFT JOIN [CountriesRivers] AS [cr]
           ON [c].[CountryCode] = [cr].[CountryCode]
    LEFT JOIN [Rivers] AS [r]
           ON [cr].[RiverId] = [r].[Id]
        WHERE [con].[ContinentName] = 'Africa'
     ORDER BY [c].[CountryName] ASC



--Problem 15. Continents and Currencies

SELECT [OrderedCurrencies].[ContinentCode],
	   [OrderedCurrencies].[CurrencyCode],
	   [OrderedCurrencies].[CurrencyUsage]
  FROM [Continents] AS [c]
  JOIN (
	     SELECT [ContinentCode] AS [ContinentCode],
	      COUNT([CurrencyCode]) AS [CurrencyUsage],
	            [CurrencyCode] as [CurrencyCode],
	            DENSE_RANK() OVER (PARTITION BY [ContinentCode]
	            ORDER BY COUNT([CurrencyCode]) DESC) 
	   AS [Rank]
	 FROM [Countries]
 GROUP BY [ContinentCode], [CurrencyCode]
   HAVING COUNT([CurrencyCode]) > 1
	           )
	        AS [OrderedCurrencies]
            ON [c].[ContinentCode] = [OrderedCurrencies].[ContinentCode]
         WHERE [OrderedCurrencies].Rank = 1


--Problem 16. Countries Without any Mountains

   SELECT COUNT([c].[CountryCode]) AS [CountryCode]
           FROM [Countries] AS [c]
LEFT OUTER JOIN [MountainsCountries] AS [m] 
             ON [c].[CountryCode] = [m].[CountryCode]
          WHERE [m].[MountainId] IS NULL

