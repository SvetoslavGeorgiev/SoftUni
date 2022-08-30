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