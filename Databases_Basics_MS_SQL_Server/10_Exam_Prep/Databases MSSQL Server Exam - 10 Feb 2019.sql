CREATE DATABASE ColonialJourney

/*01. DDL */
CREATE TABLE Planets(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE Spaceports(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	PlanetId INT FOREIGN KEY REFERENCES Planets(Id) NOT NULL
)

CREATE TABLE Spaceships(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	Manufacturer VARCHAR(30) NOT NULL,
	LightSpeedRate INT DEFAULT 0
)

CREATE TABLE Colonists(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	Ucn VARCHAR(10) UNIQUE NOT NULL,
	BirthDate DATE NOT NULL
)

CREATE TABLE Journeys(
	Id INT PRIMARY KEY IDENTITY,
	JourneyStart DATE NOT NULL,
	JourneyEnd DATE NOT NULL,
	Purpose VARCHAR(11) CHECK(Purpose IN('Medical', 'Technical', 'Educational', 'Military')),
	DestinationSpaceportId INT FOREIGN KEY REFERENCES Spaceports(Id) NOT NULL,
	SpaceshipId INT FOREIGN KEY REFERENCES Spaceships(Id) NOT NULL
)

CREATE TABLE TravelCards(
	Id INT PRIMARY KEY IDENTITY,
	CardNumber CHAR(10) UNIQUE NOT NULL,
	JobDuringJourney VARCHAR(8) CHECK(JobDuringJourney IN('Pilot', 'Engineer', 'Trooper', 'Cleaner', 'Cook')),
	ColonistId INT FOREIGN KEY REFERENCES Colonists(Id) NOT NULL,
	JourneyId INT FOREIGN KEY REFERENCES Journeys(Id) NOT NULL
)

/*02. Insert */
INSERT INTO Planets([Name])
VALUES
('Mars'),
('Earth'),
('Jupiter'),
('Saturn')

INSERT INTO Spaceships([Name], Manufacturer, LightSpeedRate)
VALUES
('Golf', 'VW', 3),
('WakaWaka', 'Wakanda',	4),
('Falcon9', 'SpaceX', 1),
('Bed', 'Vidolov', 6)

/*03. Update */
UPDATE Spaceships
SET LightSpeedRate += 1
WHERE Id BETWEEN 8 AND 12

/*04. Delete */
DELETE FROM TravelCards
WHERE JourneyId IN(1,2,3)

DELETE TOP(3) FROM Journeys

/*05. Select All Travel Cards */
SELECT CardNumber, JobDuringJourney FROM TravelCards
ORDER BY CardNumber

/*06. Select All Colonists */
SELECT c.Id, c.FirstName + ' ' + c.LastName AS FullName, c.Ucn 
FROM Colonists AS c
ORDER BY c.FirstName, c.LastName, c.Id

/*07. Select All Military Journeys */
SELECT j.Id, FORMAT(j.JourneyStart, 'dd/MM/yyyy'), FORMAT(j.JourneyEnd, 'dd/MM/yyyy') 
FROM Journeys AS j
WHERE Purpose = 'Military'
ORDER BY j.JourneyStart

/*08. Select All Pilots */
SELECT c.Id, c.FirstName + ' ' + c.LastName AS full_name FROM TravelCards AS tc
JOIN Colonists AS c ON tc.ColonistId = c.Id
WHERE tc.JobDuringJourney = 'Pilot'
ORDER BY c.Id

/*09. Count Colonists */
SELECT COUNT(*) AS [count] FROM TravelCards AS tc
JOIN Journeys AS j ON tc.JourneyId = j.Id
WHERE j.Purpose = 'Technical'

/*10. Select The Fastest Spaceship */
SELECT TOP(1) s.[Name] AS SpaceshipName, sp.[Name] AS SpaceportName 
FROM Spaceships AS s 
JOIN Journeys AS j ON s.Id = j.SpaceshipId
JOIN Spaceports AS sp ON j.DestinationSpaceportId = sp.Id
ORDER BY s.LightSpeedRate DESC

/*11. Select Spaceships With Pilots */
SELECT s.[Name], s.Manufacturer FROM Spaceships AS s 
JOIN Journeys AS j ON s.Id = j.SpaceshipId
JOIN TravelCards AS tc ON j.Id = tc.JourneyId
JOIN Colonists AS cl ON tc.ColonistId = cl.Id
WHERE tc.JobDuringJourney = 'Pilot' AND DATEDIFF(YEAR, cl.BirthDate, '01/01/2019') < 30
ORDER BY s.[Name]

/*12. Select All Educational Mission */
SELECT p.[Name] AS PlanetName, s.[Name] AS SpaceportName FROM Spaceports AS s 
JOIN Planets AS p ON s.PlanetId = p.Id
JOIN Journeys AS j ON s.Id = j.DestinationSpaceportId
WHERE j.Purpose = 'Educational'
ORDER BY s.[Name] DESC

/*13. Planets And Journeys */
SELECT p.[Name], COUNT(j.Id) AS JourneysCount 
FROM Planets AS p 
JOIN Spaceports AS s ON p.Id = s.PlanetId
JOIN Journeys AS j ON s.Id = j.DestinationSpaceportId
GROUP BY p.[Name]
ORDER BY JourneysCount DESC, p.[Name]

/*14. Extract The Shortest Journey */
SELECT TOP(1) j.Id, p.[Name] AS PlanetName, s.[Name] AS SpaceportName, j.Purpose 
FROM Journeys AS j 
JOIN Spaceports AS s ON j.DestinationSpaceportId = s.Id
JOIN Planets AS p ON s.PlanetId = p.Id
ORDER BY DATEDIFF(DAY, j.JourneyStart, j.JourneyEnd)

/*15. Select The Less Popular Job */
SELECT TOP(1) j.Id, tc.JobDuringJourney FROM Journeys AS j 
JOIN TravelCards AS tc ON j.Id = tc.JourneyId
ORDER BY DATEDIFF(DAY, j.JourneyStart, j.JourneyEnd) DESC

/*16. Select Special Colonists */

/*17. Planets and Spaceports */
SELECT p.[Name], COUNT(s.Id) AS [Count] FROM Planets AS p 
LEFT JOIN Spaceports AS s ON p.Id = s.PlanetId
GROUP BY p.[Name]
ORDER BY [Count] DESC, p.[Name]

/*18. Get Colonists Count */
GO
CREATE FUNCTION dbo.udf_GetColonistsCount(@PlanetName VARCHAR(30))
RETURNS INT 
BEGIN
	DECLARE @Count INT = (SELECT COUNT(tc.ColonistId) FROM TravelCards AS tc 
						 JOIN Journeys AS j ON tc.JourneyId = j.Id
						 JOIN SpacePorts AS sp ON j.DestinationSpaceportId = sp.Id
						 JOIN Planets AS p ON sp.PlanetId = p.Id
						 WHERE p.[Name] = @PlanetName)

	RETURN @Count
END

/*19. Change Journey Purpose */
GO
CREATE PROCEDURE usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(MAX)) AS
BEGIN
	DECLARE @targetJourneyId INT = (SELECT Id FROM Journeys WHERE Id = @JourneyId)
	IF(@targetJourneyId IS NULL)
	BEGIN
		RAISERROR('The journey does not exist!', 16, 1)
	END

	DECLARE @targetPurpose VARCHAR(MAX) = (SELECT Purpose FROM Journeys
										  WHERE Id = @JourneyId)
	IF(@targetPurpose = @NewPurpose)
	BEGIN
		RAISERROR('You cannot change the purpose!', 16, 2)
	END

	UPDATE Journeys
	SET Purpose = @NewPurpose
	WHERE Id = @JourneyId    
END

/*20. Deleted Journeys */
CREATE TABLE DeletedJourneys(
	Id INT,
	JourneyStart DATE, 
	JourneyEnd DATE, 
	Purpose VARCHAR(11), 
	DestinationSpaceportId INT, 
	SpaceshipId INT
)

GO
CREATE TRIGGER tr_DeletedJourneys ON Journeys AFTER DELETE 
AS
BEGIN
	INSERT INTO DeletedJourneys(Id, JourneyStart, JourneyEnd, Purpose, DestinationSpaceportId, SpaceshipId) 
	SELECT Id, JourneyStart, JourneyEnd, Purpose, DestinationSpaceportId, SpaceshipId FROM deleted
END