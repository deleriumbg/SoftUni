/*Problem 1. Employees with Salary Above 35000 */
USE SoftUni
GO

CREATE PROC usp_GetEmployeesSalaryAbove35000 AS
SELECT FirstName, LastName FROM Employees
WHERE Salary > 35000

EXEC usp_GetEmployeesSalaryAbove35000

/*Problem 2. Employees with Salary Above Number */
CREATE PROC usp_GetEmployeesSalaryAboveNumber(@number DECIMAL(18, 4)) AS
BEGIN
	SELECT FirstName, LastName FROM Employees
	WHERE Salary >= @number
END

EXEC usp_GetEmployeesSalaryAboveNumber 48100

/*Problem 3. Town Names Starting With */
CREATE PROC usp_GetTownsStartingWith (@startString NVARCHAR(MAX)) AS
BEGIN
	SELECT [Name] AS Towns FROM Towns
	WHERE [Name] LIKE @startString + '%'
END

EXEC usp_GetTownsStartingWith 'b'

/*Problem 4. Employees from Town */
CREATE PROC usp_GetEmployeesFromTown (@townName VARCHAR(MAX)) AS
BEGIN
	SELECT e.FirstName, e.LastName FROM Employees AS e
	INNER JOIN Addresses AS a ON e.AddressID = a.AddressID
	INNER JOIN Towns AS t ON a.TownId = t.TownID
	WHERE t.[Name] = @townName
END

EXEC usp_GetEmployeesFromTown 'Sofia'

/*Problem 5. Salary Level Function */
CREATE FUNCTION ufn_GetSalaryLevel (@salary DECIMAL(18,4)) RETURNS VARCHAR(10) AS
BEGIN
	DECLARE @salaryLevel VARCHAR(10)
	SET @salaryLevel = (
	SELECT CASE 
		WHEN @salary < 30000 THEN 'Low'
		WHEN @salary BETWEEN 30000 AND 50000 THEN 'Average'
		ELSE 'High'
	END AS SalaryLevels
	)
	RETURN @salaryLevel
END

SELECT Salary, dbo.ufn_GetSalaryLevel(Salary) AS [Salary Level] FROM Employees

/*Problem 6. Employees by Salary Level */
CREATE PROC usp_EmployeesBySalaryLevel (@salaryLevel VARCHAR(10)) AS
BEGIN
	SELECT FirstName, LastName FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @salaryLevel
END

EXEC usp_EmployeesBySalaryLevel 'High'

/*Problem 7. Define Function */
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(MAX), @word NVARCHAR(MAX)) RETURNS BIT AS
BEGIN
	DECLARE @counter INT = 1
	DECLARE @currentLetter CHAR
	WHILE (LEN(@word) >= @counter)
	BEGIN
		SET @currentLetter = SUBSTRING(@word, @counter, 1)
		IF(CHARINDEX(@currentLetter, @setOfLetters) = 0)
		BEGIN
			RETURN 0
		END
		SET @counter += 1
	END
	RETURN 1
END

/*Problem 8. * Delete Employees and Departments */

/*Problem 9. Find Full Name */
USE Bank
GO

CREATE PROC usp_GetHoldersFullName AS
BEGIN
	SELECT FirstName + ' ' + LastName AS [Full Name] FROM AccountHolders
END

EXEC usp_GetHoldersFullName

/*Problem 10. People with Balance Higher Than */
CREATE PROC usp_GetHoldersWithBalanceHigherThan (@number MONEY) AS
BEGIN
	SELECT ah.FirstName AS [First Name], ah.LastName AS [Last Name] FROM AccountHolders AS ah
	INNER JOIN Accounts AS a ON ah.Id = a.AccountHolderId
	GROUP BY ah.FirstName, ah.LastName
	HAVING SUM(a.Balance) > @number
END

EXEC usp_GetHoldersWithBalanceHigherThan 1000

/*Problem 11. Future Value Function */
CREATE FUNCTION ufn_CalculateFutureValue (@sum DECIMAL(15, 2), @yearlyInterestRate FLOAT, @years INT) RETURNS DECIMAL(15, 4) AS
BEGIN
	DECLARE @futureValue DECIMAL(15, 4)
	SET @futureValue = @sum * (POWER((1 + @yearlyInterestRate), @years))
	RETURN @futureValue
END

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5) AS [Output]

/*Problem 12. Calculating Interest */
CREATE PROC usp_CalculateFutureValueForAccount (@accountId INT, @interestRate FLOAT) AS
BEGIN
	SELECT	ah.Id AS [Account Id], 
			ah.FirstName, 
			ah.LastName, 
			a.Balance AS [Current Balance],
			dbo.ufn_CalculateFutureValue(a.Balance, @interestRate, 5) AS [Balance in 5 years]
	FROM AccountHolders AS ah
	INNER JOIN Accounts AS a ON ah.Id = a.AccountHolderId
	WHERE a.Id = @accountId
END

EXEC usp_CalculateFutureValueForAccount 1, 0.1

/*Problem 13. *Scalar Function: Cash in User Games Odd Rows */
USE Diablo
GO

CREATE FUNCTION ufn_CashInUsersGames (@gameName NVARCHAR(MAX)) RETURNS TABLE AS
RETURN SELECT SUM(Cash) AS SumCash FROM
		(
			SELECT g.[Name], ug.Cash, ROW_NUMBER() OVER(ORDER BY ug.Cash DESC) AS RowNumber FROM UsersGames AS ug
			INNER JOIN Games AS g ON ug.GameId = g.Id
			WHERE g.[Name] = @gameName
		) AS CashTable
		WHERE RowNumber % 2 <> 0

SELECT SumCash FROM dbo.ufn_CashInUsersGames('Lily Stargazer')