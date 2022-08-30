USE [Gringotts]

--Problem 1. Records’ Count

SELECT TOP(1) SUM([Id]) AS [Count]
	    FROM [WizzardDeposits]
	GROUP BY [Id]
	ORDER BY [Id] DESC

--Problem 2. Longest Magic Wand

SELECT TOP(1) [MagicWandSize] AS [LongestMagicWand]
	FROM [WizzardDeposits]
	GROUP BY [MagicWandSize]
	ORDER BY [LongestMagicWand] DESC 

--Problem 3. Longest Magic Wand Per Deposit Groups

  SELECT [DepositGroup], MAX([MagicWandSize]) AS [LongestMagicWand]
    FROM [WizzardDeposits]
GROUP BY [DepositGroup]

--Problem 4. * Smallest Deposit Group Per Magic Wand Size

SELECT TOP(2) [DepositGroup]
         FROM [WizzardDeposits]
     GROUP BY [DepositGroup]
     ORDER BY AVG([MagicWandSize])

--Problem 5. Deposits Sum

  SELECT [DepositGroup], SUM([DepositAmount]) AS [TotalSum]
    FROM [WizzardDeposits]
GROUP BY [DepositGroup]