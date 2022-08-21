--Problem 1.	Find Names of All Employees by First Name

SELECT [FirstName], [LastName]
	 FROM [Employees]
	WHERE [FirstName] LIKE 'Sa%'

-- SECOND VARIANT

SELECT [FirstName], [LastName]
	 FROM [Employees]
	WHERE LEFT ([FirstName], 2) IN ('Sa')

--Problem 2.	  Find Names of All employees by Last Name 

SELECT [FirstName], [LastName]
  FROM [Employees]
 WHERE [LastName] LIKE '%ei%'

--Problem 3.	Find First Names of All Employees

SELECT [FirstName]
  FROM [Employees]
 WHERE [DepartmentID] IN (3, 10) 
   AND YEAR(HireDate) BETWEEN 1995 AND 2005 

--Problem 4.	Find All Employees Except Engineers

SELECT [FirstName], [LastName]
  FROM [Employees]
 WHERE [JobTitle] NOT LIKE '%engineer%'

--Problem 5.	Find Towns with Name Length

SELECT [Name]
	     FROM [Towns]
	 WHERE DATALENGTH([Name]) IN (5, 6)
	 ORDER BY [Name]

--Problem 6.	 Find Towns Starting With

SELECT *
	 FROM [Towns]
    WHERE [Name] LIKE 'M%' OR [Name] LIKE 'K%' OR [Name] LIKE 'B%' OR [Name] LIKE 'E%'
 ORDER BY [Name]

--SECOND VARIANT
 SELECT *
	 FROM [Towns]
    WHERE [Name] LIKE '[MKBE]%'
 ORDER BY [Name]


--Problem 7.	 Find Towns Not Starting With

SELECT *
	 FROM [Towns]
    WHERE [Name] NOT LIKE 'R%' AND [Name] NOT LIKE 'B%' AND [Name] NOT LIKE 'D%'
 ORDER BY [Name]

--Problem 8.	Create View Employees Hired After 2000 Year
GO

CREATE VIEW [V_EmployeesHiredAfter2000] 
	AS
    SELECT [FirstName], [LastName]
	  FROM [Employees]
	 WHERE YEAR(HireDate) > 2000


GO

--Problem 9.	Length of Last Name

SELECT [FirstName], [LastName]
  FROM [Employees]
  WHERE DATALENGTH([LastName]) IN (5)

--Problem 10.  Rank Employees by Salary

  SELECT [EmployeeID], [FirstName], [LastName], [Salary],
  	   DENSE_RANK() OVER(PARTITION BY [Salary] ORDER BY [EmployeeID])
  	  AS [Rank]
    FROM [Employees]
   WHERE [Salary] BETWEEN 10000 AND 50000
ORDER BY [Salary] DESC

--Problem 11.	Find All Employees with Rank 2 *
SELECT *
    FROM (
         SELECT [EmployeeID], [FirstName], [LastName], [Salary],
         DENSE_RANK() OVER(PARTITION BY [Salary] ORDER BY [EmployeeID]) 
		     AS [Rank]
           FROM [Employees]
          WHERE [Salary] BETWEEN 10000 AND 50000
		  ) 
	   AS [MyTable]
    WHERE [Rank] = 2
 ORDER BY [Salary] DESC

--Problem 12.	 Countries Holding 'A' 

   SELECT [CountryName], [IsoCode]
     FROM [Countries]
    WHERE LEN([CountryName]) - LEN(REPLACE([CountryName],'a','')) >=3
 ORDER BY [IsoCode]

 --SECOND VARIANT WITH WILD CARDS

   SELECT [CountryName], [IsoCode]
     FROM [Countries]
    WHERE LOWER([CountryName]) LIKE '%a%a%a%'
 ORDER BY [IsoCode]

--Problem 13.   Mix of Peak and River Names

  SELECT [PeakName], [RiverName], 
         LOWER(([PeakName]) + SUBSTRING([RiverName], 2, LEN([Rivername]))) AS 'Mix' 
    FROM [Peaks]
    JOIN [Rivers]
ON RIGHT([PeakName], 1) = LEFT([RiverName], 1)
ORDER BY [Mix]

--SECOND VARIANT WITHOUT JOIN

  SELECT [p].[PeakName], [r].[RiverName], 
         LOWER(CONCAT(LEFT([p].[PeakName], LEN([p].[PeakName]) - 1), [r].[Rivername])) 
	  AS [Mix] 
    FROM [Peaks] AS [p],
		 [Rivers] AS [r]
   WHERE RIGHT([p].[PeakName], 1) = LEFT([r].[RiverName], 1)
ORDER BY [Mix]


--Problem 14.   Games From 2011 and 2012 Year

SELECT TOP 50 [Name], FORMAT([Start],'yyyy-MM-dd') AS [Start Date] 
         FROM [Games]
         WHERE (SELECT YEAR([Start])) IN (2011,2012)
     ORDER BY [Start Date], [Name]

--Problem 15. User Email Providers

  SELECT [Username], SUBSTRING([Email], CHARINDEX('@', [Email], 1) + 1, LEN([Email])) 
      AS [Email Provider]
    FROM [Users]
ORDER BY [Email Provider], [Username]

--Problem 16.	 Get Users with IPAdress Like Pattern

  SELECT [Username], [IpAddress]
	FROM [Users]
   WHERE [IpAddress] LIKE '___.1_%._%.___'
ORDER BY [Username]


--Problem 17.	 Show All Games with Duration and Part of the Day

   SELECT [Name],
	   CASE
		   WHEN DATEPART(HOUR, [Start]) BETWEEN 0 AND 11 THEN 'Morning'
		   WHEN DATEPART(HOUR, [Start]) BETWEEN 12 AND 17 THEN 'Afternoon'
		   ELSE 'Evening'
	   END AS [Part of the Day],
	   CASE
		   WHEN [Duration] BETWEEN 0 AND 3 THEN 'Extra Short'
		   WHEN [Duration] BETWEEN 4 AND 6 THEN 'Short'
		   WHEN [Duration] > 6 THEN 'Long'
		   ELSE 'Extra Long'
	   END AS [Duration]
     FROM [Games]
 ORDER BY [Name], [Duration]




