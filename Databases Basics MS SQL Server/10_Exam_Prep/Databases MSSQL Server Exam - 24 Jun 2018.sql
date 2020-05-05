CREATE DATABASE TripService

/* 01. DDL */
CREATE TABLE Cities(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	CountryCode CHAR(2) NOT NULL
)

CREATE TABLE Hotels(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	CityId INT FOREIGN KEY REFERENCES Cities(Id),
	EmployeeCount INT NOT NULL,
	BaseRate DECIMAL(15,2)
)

CREATE TABLE Rooms(
	Id INT PRIMARY KEY IDENTITY,
	Price DECIMAL(15,2) NOT NULL,
	[Type] NVARCHAR(20) NOT NULL,
	Beds INT NOT NULL,
	HotelId INT FOREIGN KEY REFERENCES Hotels(Id)
)

CREATE TABLE Trips(
	Id INT PRIMARY KEY IDENTITY,
	RoomId INT FOREIGN KEY REFERENCES Rooms(Id),
	BookDate DATE NOT NULL,
	ArrivalDate DATE NOT NULL,
	ReturnDate DATE NOT NULL,
	CancelDate DATE,
	CONSTRAINT CHK_BookDate CHECK(BookDate < ArrivalDate),
	CONSTRAINT CHK_ArrivalDate CHECK(ArrivalDate < ReturnDate)
)

CREATE TABLE Accounts(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(20),
	LastName NVARCHAR(50) NOT NULL,
	CityId INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
	BirthDate DATE NOT NULL,
	Email VARCHAR(100) UNIQUE NOT NULL
)

CREATE TABLE AccountsTrips(
	AccountId INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL,
	TripId INT FOREIGN KEY REFERENCES Trips(Id) NOT NULL,
	Luggage INT NOT NULL CHECK(Luggage >= 0),
	CONSTRAINT PK_AccountsTrips_AccountId_TripId PRIMARY KEY(AccountId, TripId)
)

/* 02. Insert */
INSERT INTO Accounts (FirstName, MiddleName, LastName, CityId, BirthDate, Email) VALUES
('John', 'Smith', 'Smith', 34, '1975-07-21', 'j_smith@gmail.com'),
('Gosho', NULL , 'Petrov', 11, '1978-05-16', 'g_petrov@gmail.com'),
('Ivan', 'Petrovich', 'Pavlov', 59, '1849-09-26', 'i_pavlov@softuni.bg'),
('Friedrich', 'Wilhelm', 'Nietzsche', 2, '1844-10-15', 'f_nietzsche@softuni.bg')

INSERT INTO Trips (RoomId, BookDate, ArrivalDate, ReturnDate, CancelDate) VALUES
(101, '2015-04-12', '2015-04-14', '2015-04-20', '2015-02-02'),
(102, '2015-07-07', '2015-07-15', '2015-07-22', '2015-04-29'),
(103, '2013-07-17', '2013-07-23', '2013-07-24', NULL),
(104, '2012-03-17', '2012-03-31', '2012-04-01', '2012-01-10'),
(109, '2017-08-07', '2017-08-28', '2017-08-29', NULL)

/* 03. Update */
UPDATE Rooms
SET Price = Price + ((Price * 14) / 100)
WHERE HotelId IN(5, 7, 9)

/*04. Delete */
DELETE FROM AccountsTrips
WHERE AccountId = 47

/*05. Bulgarian Cities */
SELECT Id, [Name] FROM Cities
WHERE CountryCode = 'BG'
ORDER BY [Name]

/*06. People Born After 1991 */
SELECT CONCAT(FirstName, ' ', ISNULL(MiddleName + ' ', ''), LastName) AS [Full Name],
		 YEAR(BirthDate) AS BirthYear
FROM Accounts
WHERE YEAR(BirthDate) > 1991
ORDER BY BirthYear DESC, FirstName

/*07. EEE-Mails */
SELECT a.FirstName, a.LastName, FORMAT(a.BirthDate, 'MM-dd-yyyy'), c.[Name], a.Email 
FROM Accounts AS a
JOIN Cities AS c ON a.CityId = c.Id
WHERE a.Email LIKE 'e%'
ORDER BY c.[Name] DESC

/*08. City Statistics */
SELECT c.[Name], COUNT(h.Id) AS Hotels 
FROM Cities AS c
LEFT JOIN Hotels AS h ON c.Id = h.CityId 
GROUP BY c.[Name]
ORDER BY COUNT(h.Id) DESC, c.[Name]

/*09. Expensive First Class Rooms */
SELECT r.Id, r.Price, h.[Name], c.[Name] FROM Rooms AS r
JOIN Hotels AS h ON r.HotelId = h.Id
JOIN Cities AS c ON h.CityId = c.Id
WHERE r.[Type] = 'First Class'
ORDER BY r.Price DESC, r.Id

/*10. Longest and Shortest Trips */
SELECT 
	a.Id,
	CONCAT(FirstName, ' ', ISNULL(MiddleName + ' ', ''), LastName) AS [Full Name],
	MAX(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS LongestTrip,
	MIN(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS ShortestTrip
FROM Accounts AS a
JOIN AccountsTrips AS at ON a.Id = at.AccountId
JOIN Trips AS t ON at.TripId = t.Id
GROUP BY 
	a.Id,
	CONCAT(FirstName, ' ', ISNULL(MiddleName + ' ', ''), LastName),
	a.MiddleName,
	t.CancelDate
HAVING a.MiddleName IS NULL AND t.CancelDate IS NULL
ORDER BY LongestTrip DESC, a.Id

/*11. Metropolis */
SELECT TOP(5) a.CityId, c.[Name], c.CountryCode, COUNT(a.Id) 
FROM Accounts AS a
JOIN Cities AS c ON a.CityId = c.Id
GROUP BY a.CityId, c.[Name], c.CountryCode
ORDER BY COUNT(a.Id) DESC

/*12. Romantic Getaways */
SELECT a.Id, a.Email, c.[Name], COUNT(*) AS Trips
FROM Accounts AS a
JOIN AccountsTrips AS at ON a.Id = at.AccountId
JOIN Trips AS t ON at.TripId = t.Id
JOIN Rooms AS r ON t.RoomId = r.Id
JOIN Hotels AS h ON r.HotelId = h.Id
JOIN Cities AS c ON h.CityId = c.Id
WHERE a.CityId = h.CityId
GROUP BY a.Id, a.Email, c.[Name]
HAVING COUNT(*) >= 1
ORDER BY Trips DESC, a.Id

/*13. Lucrative Destinations */
SELECT TOP(10) c.Id, c.[Name], SUM(h.BaseRate + r.Price) AS [Total Revenue], COUNT(t.Id) AS Trips
FROM Hotels AS h
JOIN Rooms AS r ON h.Id = r.HotelId
JOIN Trips AS t ON r.Id = t.RoomId
JOIN Cities AS c ON h.CityId = c.Id
WHERE YEAR(t.BookDate) = 2016
GROUP BY c.Id, c.[Name]
ORDER BY SUM(h.BaseRate + r.Price) DESC, Trips DESC

/*14. Trip Revenues */
SELECT t.Id, 
	h.[Name], 
	r.[Type], 
	CASE
		WHEN t.CancelDate IS NOT NULL
		THEN 0
		ELSE COUNT(at.AccountId) * (r.Price + h.BaseRate)
	END AS Revenue
FROM Trips AS t
JOIN Rooms AS r ON t.RoomId = r.Id
JOIN Hotels AS h ON r.HotelId = h.Id
JOIN AccountsTrips AS at ON t.Id = at.TripId
GROUP BY t.Id, 
	h.[Name], 
	r.[Type], 
	t.CancelDate, 
	h.BaseRate, 
	r.Price
ORDER BY r.[Type], t.Id

/*15. Top Travelers */
SELECT Id, Email, CountryCode, Trips
FROM (
	SELECT 
		a.Id, 
		a.Email, 
		c.CountryCode, 
		COUNT(t.Id) AS Trips,
		DENSE_RANK() OVER(PARTITION BY c.CountryCode ORDER BY COUNT(t.ID) DESC, a.Id) AS Rank
	FROM Accounts AS a 
	JOIN AccountsTrips AS at ON a.Id = at.AccountId
	JOIN Trips AS t ON at.TripId = t.Id
	JOIN Rooms AS r ON t.RoomId = r.Id
	JOIN Hotels AS h ON r.HotelId = h.Id
	JOIN Cities AS c ON h.CityId = c.Id
	GROUP BY 
		a.Id, 
		a.Email, 
		c.CountryCode
) AS Helper
WHERE Rank = 1 
ORDER BY Trips DESC

/*16. Luggage Fees */
SELECT 
	TripId, 
	SUM(Luggage) AS Luggage,
	CASE 
		WHEN SUM(Luggage) > 5 THEN '$' + CONVERT(VARCHAR, SUM(Luggage) * 5)
		ELSE '$0'
	END AS Fee
FROM AccountsTrips
GROUP BY TripId
HAVING SUM(Luggage) > 0 
ORDER BY Luggage DESC

/*17. GDPR Violation */
SELECT 
	t.Id,
	CONCAT(a.FirstName, ' ', ISNULL(a.MiddleName + ' ', ''), a.LastName) AS [Full Name],
	ca.[Name] AS [From],
	c.[Name] AS [To],
	CASE
		WHEN t.CancelDate IS NOT NULL THEN 'Canceled'
		ELSE CONVERT(VARCHAR, DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) + ' days'
	END AS [Duration]
FROM Accounts AS a 
	JOIN Cities AS ca ON a.CityId = ca.Id
	JOIN AccountsTrips AS at ON a.Id = at.AccountId
	JOIN Trips AS t ON at.TripId = t.Id
	JOIN Rooms AS r ON t.RoomId = r.Id
	JOIN Hotels AS h ON r.HotelId = h.Id
	JOIN Cities AS c ON h.CityId = c.Id
ORDER BY [Full Name], t.Id

/*18. Available Room */
GO
CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS VARCHAR(MAX) AS
BEGIN
	DECLARE @BookedRooms TABLE(Id INT)
	INSERT INTO @BookedRooms
		SELECT DISTINCT r.Id FROM Rooms AS r
		LEFT JOIN Trips AS t ON r.Id = t.RoomId
		WHERE r.HotelId = @HotelId AND @Date BETWEEN t.ArrivalDate AND t.ReturnDate
		AND t.CancelDate IS NULL

	DECLARE @Rooms TABLE(Id INT, Price DECIMAL(15,2), [Type] VARCHAR(20), Beds INT, TotalPrice DECIMAL(15,2))
	INSERT INTO @Rooms
		SELECT TOP(1)
			r.Id,
			r.Price,
			r.[Type],
			r.Beds,
			@People * (h.BaseRate + r.Price) AS TotalPrice
		FROM Rooms AS r
		LEFT JOIN Hotels AS h ON r.HotelId = h.Id
		WHERE
			r.HotelId = @HotelId AND
			r.Beds >= @People AND
			r.Id NOT IN (SELECT Id
						FROM @BookedRooms)
		ORDER BY TotalPrice DESC

	DECLARE @RoomCount INT = (SELECT COUNT(*) FROM @Rooms)

	IF(@RoomCount < 1)
	BEGIN
		RETURN 'No rooms available'
	END

	DECLARE @Result VARCHAR(MAX) = (SELECT CONCAT('Room ', Id, ': ', Type, ' (', Beds, ' beds) - ', '$', TotalPrice)
                                    FROM @Rooms)

	RETURN @Result
END
GO

/*19. Switch Room */
CREATE PROC usp_SwitchRoom(@TripId INT, @TargetRoomId INT) AS 
BEGIN
END

/*20. Cancel Trip */
GO
CREATE TRIGGER T_CancelTrip ON Trips INSTEAD OF DELETE 
AS
BEGIN
	UPDATE Trips
	SET CancelDate = GETDATE()
	WHERE Id IN (SELECT Id
				FROM deleted
				WHERE CancelDate IS NULL)
END


 




