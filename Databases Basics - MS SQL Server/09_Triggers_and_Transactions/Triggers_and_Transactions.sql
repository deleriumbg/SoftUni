/*Problem 1. Create Table Logs */
USE Bank
GO

CREATE TABLE Logs(
	LogId INT PRIMARY KEY IDENTITY, 
	AccountId INT NOT NULL, 
	OldSum DECIMAL(15, 2), 
	NewSum DECIMAL(15, 2)
)
CREATE TRIGGER tr_LogAccountSum ON Accounts
FOR UPDATE
AS
BEGIN
    INSERT INTO Logs (AccountId, OldSum, NewSum)
		SELECT inserted.Id, deleted.Balance, inserted.Balance
		FROM inserted JOIN deleted ON inserted.Id = deleted.Id
END

/*Problem 2. Create Table Emails */
CREATE TABLE NotificationEmails(
	Id INT PRIMARY KEY IDENTITY, 
	Recipient INT FOREIGN KEY REFERENCES Accounts(Id), 
	[Subject] NVARCHAR(MAX), 
	Body NVARCHAR(MAX)
)
CREATE TRIGGER tr_LogNotificationEmails ON Logs
FOR INSERT
AS
BEGIN
	INSERT INTO NotificationEmails VALUES
	(
		(SELECT AccountId FROM inserted),
		CONCAT('Balance change for account: ', (SELECT AccountId FROM inserted)),
		CONCAT('On ', GETDATE(), ' your balance was changed from ', (SELECT OldSum FROM Logs), ' to ', (SELECT NewSum FROM Logs), '.')
	)
END

/*Problem 3. Deposit Money */
CREATE PROCEDURE usp_DepositMoney(@AccountId INT, @MoneyAmount DECIMAL(15, 4)) AS
BEGIN
	IF @MoneyAmount > 0
	BEGIN
		UPDATE Accounts
		SET Balance += @MoneyAmount
		WHERE Id = @AccountId
	END
END

EXEC usp_DepositMoney 1, 10

/*Problem 4. Withdraw Money */
CREATE PROC usp_WithdrawMoney(@AccountId INT, @MoneyAmount DECIMAL(15, 4)) AS
BEGIN
	DECLARE @AccountBalance DECIMAL(15, 4) = (SELECT Balance FROM Accounts WHERE Id = @AccountId)
	IF (@MoneyAmount > 0 AND @AccountBalance - @MoneyAmount >= 0)
	BEGIN
		UPDATE Accounts
		SET Balance -= @MoneyAmount
		WHERE Id = @AccountId
	END
END

/*Problem 5. Money Transfer */
CREATE PROC usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount DECIMAL(15, 4)) AS
BEGIN
	BEGIN TRANSACTION
		EXEC usp_WithdrawMoney @SenderId, @Amount
		EXEC usp_DepositMoney @ReceiverId, @Amount
		DECLARE @SenderBalance DECIMAL(15, 4) = (SELECT Balance FROM Accounts WHERE Id = @SenderId)
		IF (@SenderBalance < 0)
		BEGIN
			ROLLBACK
			RETURN
		END
	COMMIT TRANSACTION
END

/*Problem 6. *Massive Shopping */

/*Problem 7. Employees with Three Projects */
USE SoftUni
GO

CREATE PROC usp_AssignProject(@employeeId INT, @projectId INT) AS
BEGIN
	BEGIN TRANSACTION
		INSERT INTO EmployeesProjects (EmployeeID, ProjectID) VALUES (@employeeId, @projectId)
		DECLARE @ProjectsCount INT = (SELECT COUNT(*) FROM EmployeesProjects WHERE EmployeeID = @employeeId)
		IF (@ProjectsCount > 3)
		BEGIN
			ROLLBACK
			RAISERROR('The employee has too many projects!', 16, 1)
			RETURN
		END
	COMMIT
END

/*Problem 8. Delete Employees */
CREATE TABLE Deleted_Employees(
	EmployeeId INT PRIMARY KEY IDENTITY, 
	FirstName NVARCHAR(50) NOT NULL, 
	LastName NVARCHAR(50) NOT NULL, 
	MiddleName NVARCHAR(50), 
	JobTitle NVARCHAR(50) NOT NULL, 
	DepartmentId INT FOREIGN KEY REFERENCES Departments(DepartmentID), 
	Salary DECIMAL(15, 4)
)
CREATE TRIGGER tr_RemoveEmployee ON Employees
FOR DELETE
AS
BEGIN
    INSERT INTO Deleted_Employees
		SELECT FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary
		FROM deleted
END
