CREATE DATABASE Supermarket

/*01. DDL */
CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE Items(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	Price DECIMAL(15,2) NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL
)

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Phone CHAR(12) NOT NULL,
	Salary DECIMAL(15,2) NOT NULL
)

CREATE TABLE Orders(
	Id INT PRIMARY KEY IDENTITY,
	[DateTime] DATETIME2 NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL
)

CREATE TABLE OrderItems(
	OrderId INT FOREIGN KEY REFERENCES Orders(Id) NOT NULL,
	ItemId INT FOREIGN KEY REFERENCES Items(Id) NOT NULL,
	Quantity INT NOT NULL CHECK(Quantity >= 1)
	PRIMARY KEY(OrderId, ItemId)
)

CREATE TABLE Shifts(
	Id INT IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	CheckIn DATETIME2 NOT NULL,
	CheckOut DATETIME2 NOT NULL
	PRIMARY KEY(Id, EmployeeId)
)

ALTER TABLE Shifts
ADD CONSTRAINT CHK_Dates CHECK(CheckIn < CheckOut)

/*02. Insert */
INSERT INTO Employees(FirstName, LastName, Phone, Salary)
VALUES
('Stoyan',	'Petrov',	'888-785-8573',	500.25),
('Stamat',	'Nikolov',	'789-613-1122',	999995.25),
('Evgeni',	'Petkov',	'645-369-9517',	1234.51),
('Krasimir','Vidolov',	'321-471-9982',	50.25)

INSERT INTO Items([Name], Price, CategoryId)
VALUES
('Tesla battery', 154.25, 8),
('Chess', 30.25, 8),
('Juice', 5.32,	1),
('Glasses', 10,	8),
('Bottle of water',	1, 1)

/*03. Update */
UPDATE Items
SET Price *= 1.27
WHERE CategoryId BETWEEN 1 AND 3

/*04. Delete */
DELETE FROM OrderItems
WHERE OrderId = 48

DELETE FROM Orders
WHERE Id = 48

/*05. Richest People */
SELECT Id, FirstName FROM Employees 
WHERE Salary > 6500
ORDER BY FirstName, Id

/*06. Cool Phone Numbers */
SELECT 
	FirstName + ' ' + LastName AS [Full Name], 
	Phone AS [Phone Number] 
FROM Employees
WHERE Phone LIKE '3%'
ORDER BY FirstName, Phone

/*07. Employee Statistics */
SELECT e.FirstName, e.LastName, COUNT(o.Id) AS [Count] FROM Employees AS e 
JOIN Orders AS o ON e.Id = o.EmployeeId
GROUP BY e.FirstName, e.LastName
ORDER BY [Count] DESC, e.FirstName

/*08. Hard Workers Club */
SELECT e.FirstName, e.LastName, AVG(DATEDIFF(HOUR, s.CheckIn, s.CheckOut)) AS [Work hours] 
FROM Employees AS e 
JOIN Shifts AS s ON e.Id = s.EmployeeId
GROUP BY e.FirstName, e.LastName, e.Id
HAVING AVG(DATEDIFF(HOUR, s.CheckIn, s.CheckOut)) > 7
ORDER BY [Work hours] DESC, e.Id

/*09. The Most Expensive Order */
SELECT TOP(1) o.Id, SUM(i.Price * oi.Quantity) AS TotalPrice 
FROM Orders AS o 
JOIN OrderItems AS oi ON o.Id = oi.OrderId
JOIN Items AS i ON oi.ItemId = i.Id
GROUP BY o.Id
ORDER BY TotalPrice DESC

/*10. Rich Item, Poor Item */
SELECT TOP(10)
	o.Id, 
	MAX(i.Price) AS ExpensivePrice,
	MIN(i.Price) AS CheapPrice 
FROM Orders AS o 
JOIN OrderItems AS oi ON o.Id = oi.OrderId
JOIN Items AS i ON oi.ItemId = i.Id
GROUP BY o.Id
ORDER BY ExpensivePrice DESC, o.Id

/*11. Cashiers */
SELECT e.Id, e.FirstName, e.LastName FROM Employees AS e 
JOIN Orders AS o ON e.Id = o.EmployeeId
GROUP BY e.Id, e.FirstName, e.LastName
ORDER BY e.Id

/*12. Lazy Employees */
SELECT DISTINCT e.Id, e.FirstName + ' ' + e.LastName AS [Full Name] 
FROM Employees AS e 
JOIN Shifts AS s ON e.Id = s.EmployeeId
WHERE DATEDIFF(HOUR, s.CheckIn, s.CheckOut) < 4
ORDER BY e.Id

/*13. Sellers */
SELECT TOP(10)
	e.FirstName + ' ' + e.LastName AS [Full Name],
	SUM(oi.Quantity * i.Price) AS [Total Price],
	SUM(oi.Quantity) AS Items
FROM Employees AS e 
JOIN Orders AS o ON e.Id = o.EmployeeId
JOIN OrderItems AS oi ON o.Id = oi.OrderId
JOIN Items AS i ON oi.ItemId = i.Id
WHERE o.DateTime < '2018-06-15'
GROUP BY e.FirstName + ' ' + e.LastName
ORDER BY [Total Price] DESC, Items

/*14. Tough Days */
SELECT 
	e.FirstName + ' ' + e.LastName AS [Full Name],
	DATENAME(WEEKDAY, s.CheckIn) AS [Day of week]
FROM Employees AS e 
LEFT JOIN Orders AS o ON e.Id = o.EmployeeId
JOIN Shifts AS s ON e.Id = s.EmployeeId
WHERE o.Id IS NULL AND DATEDIFF(HOUR, s.CheckIn, s.CheckOut) > 12
ORDER BY e.Id

/*15. Top Order per Employee */
SELECT 
	emp.FirstName + ' ' + emp.LastName AS FullName, 
	DATEDIFF(HOUR, s.CheckIn, s.CheckOut) AS WorkHours, 
	e.TotalPrice AS TotalPrice FROM 
		(
			SELECT o.EmployeeId, SUM(oi.Quantity * i.Price) AS TotalPrice, o.DateTime,
			ROW_NUMBER() OVER (PARTITION BY o.EmployeeId ORDER BY o.EmployeeId, SUM(i.Price * oi.Quantity) DESC ) AS Rank
			FROM Orders AS o
			JOIN OrderItems AS oi ON oi.OrderId = o.Id
			JOIN Items AS i ON i.Id = oi.ItemId
			GROUP BY o.EmployeeId, o.Id, o.DateTime
		) AS e 
JOIN Employees AS emp ON emp.Id = e.EmployeeId
JOIN Shifts AS s ON s.EmployeeId = e.EmployeeId
WHERE e.Rank = 1 AND e.DateTime BETWEEN s.CheckIn AND s.CheckOut
ORDER BY FullName, WorkHours DESC, TotalPrice DESC

/*16. Average Profit per Day */
SELECT 
	DAY(o.[DateTime]) AS [Day], 
	CONVERT(DECIMAL(15,2), AVG(oi.Quantity * i.Price)) AS [Total profit]
FROM Orders AS o 
JOIN OrderItems AS oi ON o.Id = oi.OrderId
JOIN Items AS i ON oi.ItemId = i.Id
GROUP BY DAY(o.[DateTime])
ORDER BY DAY(o.[DateTime])

/*17. Top Products */
SELECT 
	i.[Name] AS Items,
	c.[Name] AS Category,
	SUM(oi.Quantity) AS [Count],
	SUM(oi.Quantity * i.Price) AS TotalPrice
FROM Items AS i 
JOIN Categories AS c ON i.CategoryId = c.Id
LEFT JOIN OrderItems AS oi ON i.Id = oi.ItemId
GROUP BY i.[Name], c.[Name]
ORDER BY TotalPrice DESC, [Count] DESC

/*18. Promotion Days */
GO
CREATE FUNCTION udf_GetPromotedProducts(@CurrentDate DATETIME2, @StartDate DATETIME2, @EndDate DATETIME2, @Discount INT, @FirstItemId INT, @SecondItemId INT, @ThirdItemId INT)
RETURNS VARCHAR(MAX)
AS 
BEGIN
	DECLARE @FirstItemPrice DECIMAL(15,2) = (SELECT Price FROM Items WHERE Id = @FirstItemId)
	DECLARE @SecondItemPrice DECIMAL(15,2) = (SELECT Price FROM Items WHERE Id = @SecondItemId)
	DECLARE @ThirdItemPrice DECIMAL(15,2) = (SELECT Price FROM Items WHERE Id = @ThirdItemId)

	IF @FirstItemPrice IS NULL OR @SecondItemPrice IS NULL OR @ThirdItemPrice IS NULL
	BEGIN
		RETURN 'One of the items does not exists!'
	END

	IF @CurrentDate NOT BETWEEN @StartDate AND @EndDate
	BEGIN
		RETURN 'The current date is not within the promotion dates!'
	END

	DECLARE @FirstItemName VARCHAR(MAX) = (SELECT [Name] FROM Items WHERE Id = @FirstItemId)
	DECLARE @SecondItemName VARCHAR(MAX) = (SELECT [Name] FROM Items WHERE Id = @SecondItemId)
	DECLARE @ThirdItemName VARCHAR(MAX) = (SELECT [Name] FROM Items WHERE Id = @ThirdItemId)

	DECLARE @FirstItemDiscountedPrice DECIMAL(15,2) = @FirstItemPrice - ((@FirstItemPrice * @Discount) / 100)
	DECLARE @SecondItemDiscountedPrice DECIMAL(15,2) = @SecondItemPrice - ((@SecondItemPrice * @Discount) / 100)
	DECLARE @ThirdItemDiscountedPrice DECIMAL(15,2) = @ThirdItemPrice - ((@ThirdItemPrice * @Discount) / 100)

	RETURN  @FirstItemName + ' price: ' + CONVERT(VARCHAR(50), @FirstItemDiscountedPrice) + ' <-> ' + 
			@SecondItemName + ' price: ' + CONVERT(VARCHAR(50), @SecondItemDiscountedPrice) + ' <-> ' + 
			@ThirdItemName + ' price: ' + CONVERT(VARCHAR(50), @ThirdItemDiscountedPrice)
END

/*19. Cancel Order */
GO
CREATE PROC usp_CancelOrder(@OrderId INT, @CancelDate DATETIME2) AS
BEGIN
	DECLARE @Id INT = (SELECT Id FROM Orders WHERE Id = @OrderId)
	IF @Id IS NULL
	BEGIN
		RAISERROR('The order does not exist!', 16, 1)
	END

	DECLARE @IssueDate DATETIME2 = (SELECT [DateTime] FROM Orders WHERE Id = @OrderId)
	IF DATEDIFF(DAY, @IssueDate, @CancelDate) > 3 
	BEGIN
		RAISERROR('You cannot cancel the order!', 16, 2)
	END

	DELETE FROM OrderItems 
	WHERE OrderId = @OrderId

	DELETE FROM Orders 
	WHERE Id = @OrderId
END

/*20. Deleted Orders */
CREATE TABLE DeletedOrders(
	OrderId INT, 
	ItemId INT, 
	ItemQuantity INT
)

GO
CREATE TRIGGER tr_DeletedOrders ON OrderItems AFTER DELETE 
AS
BEGIN
	INSERT INTO DeletedOrders(OrderId, ItemId, ItemQuantity) 
	SELECT OrderId, ItemId, Quantity FROM deleted
END