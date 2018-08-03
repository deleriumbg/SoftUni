/*Problem 1. Employee Address */
USE SoftUni
GO

SELECT TOP(5) e.EmployeeID, e.JobTitle, e.AddressId, a.AddressText FROM Employees AS e
INNER JOIN Addresses AS a ON e.AddressID = a.AddressID
ORDER BY AddressID

/*Problem 2. Addresses with Towns */
SELECT TOP(50) e.FirstName, e.LastName, t.[Name] AS Town, a.AddressText FROM Employees AS e
INNER JOIN Addresses AS a ON e.AddressID = a.AddressID
INNER JOIN Towns AS t ON a.TownID = t.TownID
ORDER BY e.FirstName, e.LastName

/*Problem 3. Sales Employee */
SELECT e.EmployeeID, e.FirstName, e.LastName, d.[Name] AS DepartmentName FROM Employees AS e
INNER JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE d.[Name] = 'Sales'
ORDER BY EmployeeID

/*Problem 4. Employee Departments */
SELECT TOP(5) e.EmployeeID, e.FirstName, e.Salary, d.[Name] FROM Employees AS e
INNER JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > 15000
ORDER BY d.DepartmentID

/*Problem 5. Employees Without Project */
SELECT TOP(3) e.EmployeeID, e.FirstName FROM Employees AS e
FULL OUTER JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
WHERE ep.ProjectID IS NULL
ORDER BY e.EmployeeID

/*Problem 6. Employees Hired After */
SELECT e.FirstName, e.LastName, e.HireDate, d.[Name] AS DeptName FROM Employees AS e
INNER JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate > '1.1.1999' AND d.[Name] IN ('Sales', 'Finance')
ORDER BY HireDate

/*Problem 7. Employees with Project */
SELECT TOP(5) e.EmployeeID, e.FirstName, p.[Name] AS ProjectName FROM Employees AS e
INNER JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
INNER JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '08.13.2002' AND p.EndDate IS NULL
ORDER BY e.EmployeeID

/*Problem 8. Employee 24 */
SELECT e.EmployeeID, e.FirstName,  
CASE
	WHEN YEAR(p.StartDate) >= 2005 THEN NULL
	ELSE p.[Name]
END AS ProjectName
FROM Employees AS e
INNER JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
INNER JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24

/*Problem 9. Employee Manager */
SELECT e.EmployeeID, e.FirstName, e.ManagerID, m.FirstName AS ManagerName FROM Employees AS e
INNER JOIN Employees AS m ON  e.ManagerID = m.EmployeeID 
WHERE e.ManagerID IN (3, 7)
ORDER BY e.EmployeeID

/*Problem 10. Employee Summary */
SELECT TOP(50) e.EmployeeID, 
			   e.FirstName + ' ' + e.LastName AS EmployeeName, 
			   m.FirstName + ' ' + m.LastName AS ManagerName, 
			   d.[Name] AS DepartmentName 
FROM Employees AS e
INNER JOIN Employees AS m ON  e.ManagerID = m.EmployeeID 
INNER JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID

/*Problem 11. Min Average Salary */
SELECT MIN(AverageSalaryPerDept) AS MinAverageSalary FROM (
	SELECT AVG(Salary) AS AverageSalaryPerDept FROM Employees
	GROUP BY DepartmentID
) AS TempTable

/*Problem 12. Highest Peaks in Bulgaria */
USE [Geography]
GO

SELECT mc.CountryCode, m.MountainRange, p.PeakName, p.Elevation FROM Mountains AS m
INNER JOIN Peaks AS p ON m.Id = p.MountainId
INNER JOIN MountainsCountries AS mc ON m.Id = mc.MountainId
WHERE mc.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC

/*Problem 13. Count Mountain Ranges */
SELECT mc.CountryCode, COUNT(m.MountainRange) AS MountainRanges FROM MountainsCountries AS mc
INNER JOIN Mountains AS m ON mc.MountainId = m.Id
GROUP BY mc.CountryCode
HAVING mc.CountryCode IN ('BG', 'RU', 'US')

/*Problem 14. Countries with Rivers */
SELECT TOP(5) c.CountryName, r.RiverName FROM Countries AS c
LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName

/*Problem 15. *Continents and Currencies */
SELECT ContinentCode, CurrencyCode, CurrencyUsage FROM(
	SELECT ContinentCode, CurrencyCode, CurrencyUsage,
	DENSE_RANK() OVER(PARTITION BY ContinentCode ORDER BY CurrencyUsage DESC) AS [Rank]
	FROM(
		SELECT ContinentCode, CurrencyCode, COUNT(CurrencyCode) AS CurrencyUsage FROM Countries
		GROUP BY CurrencyCode, ContinentCode
	) AS Currencies
) AS RankedCurrencies
WHERE [Rank] = 1 AND CurrencyUsage > 1
ORDER BY ContinentCode

/*Problem 16. Countries without any Mountains */
SELECT COUNT(c.CountryCode) AS CountryCode FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
WHERE mc.CountryCode IS NULL

/*Problem 17. Highest Peak and Longest River by Country */

/*Problem 18. * Highest Peak Name and Elevation by Country */
SELECT TOP (5) CountryName AS Country,
               CASE
                   WHEN PeakName IS NULL THEN '(no highest peak)'
                   ELSE PeakName
               END AS HighestPeakName,
               CASE
                   WHEN Elevation IS NULL THEN 0
                   ELSE Elevation
               END AS HighestPeakElevation,
               CASE
                   WHEN MountainRange IS NULL THEN '(no mountain)'
                   ELSE MountainRange
               END AS Mountain
FROM
(
    SELECT c.CountryName,
           p.PeakName,
           p.Elevation,
           m.MountainRange,
		   DENSE_RANK() OVER(PARTITION BY c.CountryName ORDER BY p.Elevation DESC) AS [Rank]
    FROM Countries AS c
         LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
         LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
         LEFT JOIN Peaks AS p ON m.Id = p.MountainId
) AS RankedPeaks
WHERE [Rank] = 1
ORDER BY CountryName, PeakName
