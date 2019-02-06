/*Problem 1. Find Names of All Employees by First Name */
USE SoftUni
GO

SELECT FirstName, LastName FROM Employees
WHERE FirstName LIKE 'SA%'

/*Problem 2. Find Names of All employees by Last Name */
SELECT FirstName, LastName FROM Employees
WHERE LastName LIKE '%ei%'

/*Problem 3. Find First Names of All Employees */
SELECT FirstName FROM Employees
WHERE DepartmentID IN (3, 10)
AND YEAR(HireDate) BETWEEN 1995 AND 2005

/*Problem 4. Find All Employees Except Engineers */
SELECT FirstName, LastName FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

/*Problem 5. Find Towns with Name Length */
SELECT [Name] FROM Towns
WHERE LEN([Name]) BETWEEN 5 AND 6
ORDER BY [Name]

/*Problem 6. Find Towns Starting With */
SELECT TownID, [Name] FROM Towns
WHERE [Name] LIKE '[MKBE]%'
ORDER BY [Name]

/*Problem 7. Find Towns Not Starting With */
SELECT TownID, [Name] FROM Towns
WHERE [Name] LIKE '[^RBD]%'
ORDER BY [Name]

/*Problem 8. Create View Employees Hired After 2000 Year */
GO
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName FROM Employees
WHERE YEAR(HireDate) > 2000
GO
SELECT * FROM V_EmployeesHiredAfter2000

/*Problem 9. Length of Last Name */
SELECT FirstName, LastName FROM Employees
WHERE LEN(LastName) = 5

/*Problem 10. Countries Holding ‘A’ 3 or More Times */
USE [Geography]
GO

SELECT CountryName AS [Country Name], IsoCode AS [ISO Code] FROM Countries
WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode

/*Problem 11. Mix of Peak and River Names */
SELECT PeakName, RiverName,
LOWER(CONCAT(PeakName, SUBSTRING(RiverName, 2, LEN(RiverName) - 1))) AS Mix
FROM Peaks, Rivers
WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY Mix

/*Problem 12. Games from 2011 and 2012 year */
USE Diablo
GO

SELECT TOP(50) [Name], CONVERT(VARCHAR, [Start], 23) AS [Start] FROM Games
WHERE YEAR([Start]) BETWEEN 2011 AND 2012
ORDER BY [Start], [Name]

/*Problem 13. User Email Providers */
SELECT Username,
RIGHT(Email, LEN(Email) - CHARINDEX('@', Email, 1)) AS [Email Provider]
FROM Users 
ORDER BY [Email Provider], Username

/*Problem 14. Get Users with IPAdress Like Pattern */
SELECT Username, IpAddress AS [IP Address] FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username

/*Problem 15. Show All Games with Duration and Part of the Day */
SELECT [Name],
CASE 
	WHEN DATEPART(HOUR, [Start]) < 12 THEN 'Morning'
	WHEN DATEPART(HOUR, [Start]) < 18 THEN 'Afternoon'
	ELSE 'Evening'
END AS [Part of the Day],
CASE 
	WHEN Duration <= 3 THEN 'Extra Short'
	WHEN Duration <= 6 THEN 'Short'
	WHEN Duration > 6 THEN 'Long'
	ELSE 'Extra Long'
END AS Duration
FROM Games
ORDER BY [Name], Duration

/*Problem 16. Orders Table */
USE Orders
GO

SELECT ProductName, OrderDate,
DATEADD(DAY, 3, OrderDate) AS [Pay Due],
DATEADD(MONTH, 1, OrderDate) AS [Deliver Due]
FROM Orders

/*Problem 17. People Table */
CREATE TABLE People(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
	Birthday DATETIME NOT NULL
)
INSERT INTO People([Name], Birthday)
VALUES
('Victor', '2000-12-07 00:00:00.000'),
('Steven', '1992-09-10 00:00:00.000'),
('Stephen', '1910-09-19 00:00:00.000'),
('John', '2010-01-06 00:00:00.000')

SELECT [Name],
DATEDIFF(YEAR, Birthday, GETDATE()) AS [Age in Years],
DATEDIFF(MONTH, Birthday, GETDATE()) AS [Age in Months],
DATEDIFF(DAY, Birthday, GETDATE()) AS [Age in Days],
DATEDIFF(MINUTE, Birthday, GETDATE()) AS [Age in Minutes]
FROM People