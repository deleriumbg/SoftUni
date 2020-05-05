CREATE DATABASE ReportService

/*01. DDL */
CREATE TABLE Users(
	Id INT PRIMARY KEY IDENTITY,
	Username NVARCHAR(30) UNIQUE NOT NULL,
	[Password] NVARCHAR(50) NOT NULL,
	[Name] NVARCHAR(50),
	Gender CHAR(1) CHECK(Gender IN('M', 'F')),
	BirthDate DATE,
	Age INT,
	Email NVARCHAR(50) NOT NULL
)

CREATE TABLE Departments(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(25),
	LastName NVARCHAR(25),
	Gender CHAR(1) CHECK(Gender IN('M', 'F')),
	BirthDate DATE,
	Age INT,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL
)

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE Status(
	Id INT PRIMARY KEY IDENTITY,
	Label VARCHAR(30) NOT NULL
)

CREATE TABLE Reports(
	Id INT PRIMARY KEY IDENTITY,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	StatusId INT FOREIGN KEY REFERENCES Status(Id),
	OpenDate DATE NOT NULL,
	CloseDate DATE,
	[Description] VARCHAR(200),
	UserId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
)

/*02. Insert */
INSERT INTO Employees(FirstName, LastName, Gender, BirthDate, DepartmentId)
VALUES
('Marlo', 'O’Malley', 'M', '9/21/1958',	1),
('Niki', 'Stanaghan', 'F', '11/26/1969', 4),
('Ayrton', 'Senna',	'M', '03/21/1960', 9),
('Ronnie', 'Peterson', 'M', '02/14/1944', 9),
('Giovanna', 'Amati', 'F', '07/20/1959', 5)

INSERT INTO Reports(CategoryId, StatusId, OpenDate, CloseDate, [Description], UserId, EmployeeId)
VALUES
(1,	1,	'04/13/2017', NULL,	'Stuck Road on Str.133', 6,	2),
(6,	3,	'09/05/2015', '12/06/2015', 'Charity trail running', 3,	5),
(14,2,	'09/07/2015', NULL,	 'Falling bricks on Str.58', 5,	2),
(4,	3,	'07/03/2017', '07/06/2017', 'Cut off streetlight on Str.11', 1,	1)

/*03. Update */
UPDATE Reports
SET StatusId = 2
WHERE StatusId = 1 AND CategoryId = 4

/*04. Delete */
DELETE Reports
WHERE StatusId = 4

/*05. Users by Age */
SELECT Username, Age FROM Users AS u
ORDER BY u.Age, u.Username DESC
    
/*06. Unassigned Reports */
SELECT r.[Description], r.OpenDate FROM Reports AS r
WHERE r.EmployeeId IS NULL
ORDER BY r.OpenDate, r.[Description]

/*07. Employees & Reports */
SELECT 
	e.FirstName, 
	e.LastName,
	r.[Description],
	FORMAT(r.OpenDate, 'yyyy-MM-dd')
FROM Employees AS e
JOIN Reports AS r ON e.Id = r.EmployeeId
WHERE r.EmployeeId IS NOT NULL
ORDER BY e.Id, r.OpenDate, r.Id

/*08. Most Reported Category */
SELECT 
	c.[Name],
	COUNT(r.CategoryId) AS ReportsNumber
FROM Categories AS c
JOIN Reports AS r ON c.Id = r.CategoryId
GROUP BY c.[Name]
ORDER BY ReportsNumber DESC, c.[Name]

/*09. Employees in Category */
SELECT 
	c.[Name] AS CategoryName,
	COUNT(e.Id) AS [Employees Number]
FROM Categories AS c 
JOIN Departments AS d ON c.DepartmentId = d.Id
JOIN Employees AS e ON d.Id = e.DepartmentId
GROUP BY c.[Name]

/*10. Users per Employee */
SELECT 
	e.FirstName + ' ' + e.LastName AS [Name],
	COUNT(r.UserId) AS [Users Number]
FROM employees AS e 
LEFT JOIN Reports AS r ON e.Id = r.EmployeeId
GROUP BY e.FirstName + ' ' + e.LastName
ORDER BY [Users Number] DESC, [Name]

/*11. Emergency Patrol */
SELECT
	r.OpenDate,
	r.[Description],
	u.Email 
FROM Reports AS r
JOIN Users AS u ON r.UserId = u.Id
JOIN Categories AS c ON r.CategoryId = c.Id
WHERE r.CloseDate IS NULL 
AND LEN(r.[Description]) > 20
AND r.[Description] LIKE '%str%'
AND c.DepartmentId IN(1, 4, 5)
ORDER BY r.OpenDate, u.Email, r.Id

/*12. Birthday Report */
SELECT DISTINCT c.[Name] AS [Category Name] FROM Reports AS r 
JOIN Users AS u ON r.UserId = u.Id
JOIN Categories AS c ON r.CategoryId = c.Id
WHERE DAY(u.BirthDate) = DAY(r.OpenDate) AND MONTH(u.BirthDate) = MONTH(r.OpenDate)
ORDER BY c.[Name]

/*13. Numbers Coincidence */
SELECT DISTINCT u.Username FROM Users AS u
JOIN Reports AS r ON u.Id = r.UserId
WHERE u.Username LIKE '[0-9]%' AND CONVERT(VARCHAR(10), r.CategoryId) = LEFT(u.Username, 1)
OR u.Username LIKE '%[0-9]' AND CONVERT(VARCHAR(10), r.CategoryId) = RIGHT(u.Username, 1)

/*14. Open/Closed Statistics */
SELECT	e.FirstName + ' ' + e.LastName AS [Name],
        CONCAT(ISNULL(cd.ReportSum, 0), '/', ISNULL(od.ReportSum, 0)) AS [Closed Open Reports]
      FROM Employees e
	  JOIN (  SELECT r.EmployeeId,
                     COUNT(1) AS [ReportSum]
                FROM Reports r
               WHERE DATEPART(YEAR, r.OpenDate) = 2016
            GROUP BY r.EmployeeId) AS od
        ON od.EmployeeId = e.Id
 LEFT JOIN (  SELECT r.EmployeeId,
                     COUNT(1) AS [ReportSum]
                FROM Reports r
               WHERE DATEPART(YEAR, r.CloseDate) = 2016
            GROUP BY r.EmployeeId) AS cd
        ON cd.EmployeeId = e.Id
ORDER BY [Name]

/*15. Average Closing Time */
SELECT 
	d.[Name] AS [DepartmentName],
	ISNULL(CONVERT(VARCHAR(MAX), AVG(DATEDIFF(DAY, r.OpenDate, r.CloseDate))), 'no info')
FROM Departments AS d
JOIN Categories AS c ON d.Id = c.DepartmentId
JOIN Reports AS r ON c.Id = r.CategoryId
GROUP BY d.[Name]
ORDER BY d.[Name]

/*17. Employee's Load */
GO
CREATE FUNCTION udf_GetReportsCount(@employeeId INT, @statusId INT)
RETURNS INT AS
BEGIN
	DECLARE @reportsCount INT = (SELECT COUNT(*) FROM Reports AS r
								WHERE r.EmployeeId = @employeeId
								AND r.StatusId = @statusId)
	RETURN @reportsCount 
END

/*18. Assign Employee */
GO
CREATE PROCEDURE usp_AssignEmployeeToReport(@employeeId INT, @reportId INT)
AS
BEGIN
	BEGIN TRANSACTION
		DECLARE @categoryId INT = (SELECT CategoryId FROM Reports
									WHERE Id = @reportId)
		DECLARE @employeeDepartmentId INT = (SELECT DepartmentId FROM Employees
											WHERE Id = @employeeId)
		DECLARE @categoryDepartmentId INT= (SELECT DepartmentId
									FROM Categories
									WHERE Id = @categoryId)

		UPDATE Reports
		SET EmployeeId = @employeeId
		WHERE Id = @reportId	

		IF @employeeId IS NOT NULL AND @employeeDepartmentId <> @categoryDepartmentId
		BEGIN
			ROLLBACK;
			THROW 50013, 'Employee doesn''t belong to the appropriate department!', 1
		END
	COMMIT
END

/*19. Close Reports */
GO
CREATE TRIGGER tr_Completed ON Reports AFTER UPDATE
AS
BEGIN
	DECLARE @ReportId INT
    SET @ReportId = (SELECT i.Id
                      FROM INSERTED i
                      JOIN DELETED d
                        ON d.Id = i.Id
                     WHERE d.CloseDate IS NULL AND i.CloseDate IS NOT NULL)

    UPDATE Reports 
       SET StatusId = 3
	 WHERE Id = @ReportId
END

/*20. Categories Revision */
SELECT c.[Name],
	   COUNT(r.Id) AS ReportsNumber,
	   CASE 
	      WHEN InProgressCount > WaitingCount THEN 'in progress'
		  WHEN InProgressCount < WaitingCount THEN 'waiting'
		  ELSE 'equal'
	   END AS MainStatus
FROM Reports AS r
    JOIN Categories AS c ON c.Id = r.CategoryId
    JOIN Status AS s ON s.Id = r.StatusId
    JOIN (SELECT r.CategoryId, 
		         SUM(CASE WHEN s.Label = 'in progress' THEN 1 ELSE 0 END) as InProgressCount,
		         SUM(CASE WHEN s.Label = 'waiting' THEN 1 ELSE 0 END) as WaitingCount
		  FROM Reports AS r
		  JOIN Status AS s on s.Id = r.StatusId
		  WHERE s.Label IN ('waiting','in progress')
		  GROUP BY r.CategoryId
		 ) AS sc ON sc.CategoryId = c.Id
WHERE s.Label IN ('waiting', 'in progress') 
GROUP BY C.[Name],
	     CASE 
		     WHEN InProgressCount > WaitingCount THEN 'in progress'
		     WHEN InProgressCount < WaitingCount THEN 'waiting'
		     ELSE 'equal'
	     END
ORDER BY C.[Name], 
		 ReportsNumber, 
		 MainStatus