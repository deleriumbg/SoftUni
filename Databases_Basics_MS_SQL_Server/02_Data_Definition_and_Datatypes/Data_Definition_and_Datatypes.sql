/*Problem 1. Create Database*/
CREATE DATABASE Minions
GO
USE Minions

/*Problem 2. Create Tables*/
CREATE TABLE Minions(
	Id INT PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL,
	Age INT
)

CREATE TABLE Towns(
	Id INT PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL
)

/*Problem 3. Alter Minions Table*/
ALTER TABLE Minions
ADD TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL

/*Problem 4. Insert Records in Both Tables*/
INSERT INTO Towns
VALUES
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

INSERT INTO Minions
VALUES
(1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3, 'Steward', NULL, 2)

/*Problem 5. Truncate Table Minions*/
TRUNCATE TABLE Minions

/*Problem 6. Drop All Tables*/
DROP TABLE Minions
DROP TABLE Towns

/*Problem 7. Create Table People*/
CREATE TABLE People(
	Id INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX),
	Height DECIMAL(3,2),
	[Weight] DECIMAL(5,2),
	Gender CHAR(1) CONSTRAINT CHK_UserGender CHECK (Gender in ('M', 'F')) NOT NULL,
	Birthdate DATETIME NOT NULL,
	Biography NVARCHAR(MAX)
)

ALTER TABLE People
ADD CONSTRAINT CHK_PictureSize CHECK(DATALENGTH(Picture) <= 2 * 1024 * 1024)

INSERT INTO People(Name, Gender, Birthdate)
VALUES
('Pesho', 'M', 24/01/1990),
('Gosho', 'M', 28/07/1996),
('Mimi', 'F', 11/01/1983),
('Penka', 'F', 7/11/1989),
('Stavri', 'M', 13/05/1991)

/*Problem 8. Create Table Users*/
CREATE TABLE Users(
	Id BIGINT IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX) CONSTRAINT CHK_ProfilePicture CHECK(DATALENGTH(ProfilePicture) <= 900 * 1024),
	LastLoginTime DATETIME,
	IsDeleted BIT NOT NULL DEFAULT 0
)

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY(Id)

INSERT INTO Users(Username, [Password])
VALUES
('Pesho', '123456'),
('Gosho', '123456'),
('Mimi', '123456'),
('Penka', '123456'),
('Stavri', '123456')

/*Problem 9. Change Primary Key*/
ALTER TABLE Users
DROP CONSTRAINT PK_Users

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY(Id, Username)

/*Problem 10. Add Check Constraint*/
ALTER TABLE Users
ADD CONSTRAINT CHK_Password CHECK(DATALENGTH(Password) >= 5)

/*Problem 11. Set Default Value of a Field*/
ALTER TABLE Users
ADD DEFAULT GETDATE() FOR LastLoginTime

/*Problem 12. Set Unique Field*/
ALTER TABLE Users
DROP CONSTRAINT PK_Users

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY(Id)

ALTER TABLE Users
ADD CONSTRAINT UK_Users UNIQUE(Username)

ALTER TABLE Users
ADD CONSTRAINT CHK_Username CHECK(DATALENGTH(Username) >= 3)

/*Problem 13. Movies Database*/
CREATE DATABASE Movies
GO
USE Movies

CREATE TABLE Directors(
	Id INT PRIMARY KEY IDENTITY,
	DirectorName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)
INSERT INTO Directors
VALUES
(1, 'Director1'),
(2, 'Director2'),
(3, 'Director3'),
(4, 'Director4'),
(5, 'Director5')

CREATE TABLE Genres(
	Id INT PRIMARY KEY IDENTITY,
	GenreName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)
INSERT INTO Genres
VALUES
(1, 'Genre1'),
(2, 'Genre2'),
(3, 'Genre3'),
(4, 'Genre4'),
(5, 'Genre5')

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)
INSERT INTO Categories
VALUES
(1, 'Category1'),
(2, 'Category2'),
(3, 'Category3'),
(4, 'GCategory4'),
(5, 'Category5')

CREATE TABLE Movies(
	Id INT IDENTITY CONSTRAINT PK_Movies PRIMARY KEY,
	Title NVARCHAR(50) NOT NULL,
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id) NOT NULL,
	CopyrightYear INT,
	[Length] TIME,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	Rating NUMERIC(2,1),
	Notes NVARCHAR(MAX)
)
INSERT INTO Movies(Title, DirectorId, GenreId, CategoryId)
VALUES
('Title1', 1, 2, 3),
('Title2', 2, 3, 4),
('Title3', 3, 4, 5),
('Title4', 4, 5, 1),
('Title5', 5, 1, 2)

/*Problem 14. Car Rental Database*/
CREATE DATABASE CarRental
GO
USE CarRental

CREATE TABLE Categories(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	CategoryName NVARCHAR(50) NOT NULL,
	DailyRate DECIMAL(6,2) NOT NULL,
	WeeklyRate DECIMAL(10,2),
	MonthlyRate DECIMAL(10,2),
	WeekendRate DECIMAL(6,2),
)
INSERT INTO Categories(CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES
('Category1', 10.40, NULL, 120.50, NULL),
('Category2', 12.65, 60.00, NULL, 13.30),
('Category3', 14.80, NULL, NULL, 17.10)

CREATE TABLE Cars(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	PlateNumber VARCHAR(10) NOT NULL,
	Manufacturer VARCHAR(50) NOT NULL,
	Model VARCHAR(50) NOT NULL,
	CarYear INT NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	Doors INT,
	Picture VARBINARY(MAX),
	Condition VARCHAR(50),
	Available BIT DEFAULT 0
)
INSERT INTO Cars
VALUES
('AA 9999 H', 'Mazda', '323', 1998, 1, 4, NULL, 'Used', 1),
('BX 3366 B', 'BMW', '3', 2004, 2, 4, NULL, 'Used', NULL),
('TX 5544 H', 'Mercedes', 'Benz', 2018, 3, 2, NULL, 'New', 1)

CREATE TABLE Employees(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)
INSERT INTO Employees
VALUES
('Pesho', 'Peshov', 'CEO', 'The boss'),
('Gosho', 'Goshov', 'Engineer', NULL),
('Stamat', 'Stamatov', 'Mechanic', NULL)

CREATE TABLE Customers(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	DriverLicenseNumber VARCHAR(50) UNIQUE NOT NULL,
	FullName NVARCHAR(50) NOT NULL,
	[Address] NVARCHAR(150),
	City NVARCHAR(50),
	ZipCode VARCHAR(30),
	Notes NVARCHAR(MAX)
)
INSERT INTO Customers(DriverLicenseNumber, FullName)
VALUES
('676338742683', 'Pesho Petrov'),
('567456756757', 'Ivan Ivanov'),
('564564564456', 'Atanas Atanasov')

CREATE TABLE RentalOrders(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id) NOT NULL,
	CarId INT FOREIGN KEY REFERENCES Cars(Id) NOT NULL,
	TankLevel NUMERIC(4,2),
	KilometrageStart INT,
	KilometrageEnd INT,
	TotalKilometrage INT,
	StartDate DATETIME NOT NULL,
	EndDate DATETIME NOT NULL,
	TotalDays INT,
	RateApplied DECIMAL(8,2),
	TaxRate DECIMAL(8,2),
	OrderStatus NVARCHAR(50),
	Notes NVARCHAR(MAX)
)
INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, StartDate, EndDate)
VALUES
(1, 2, 3, 22/01/2018, 26/01/2018),
(2, 3, 1, 2/06/2018, 11/06/2018),
(3, 1, 2, 15/03/2018, 22/03/2018)

/*Problem 15. Hotel Database*/
CREATE DATABASE Hotel
GO
USE Hotel

CREATE TABLE Employees(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)
INSERT INTO Employees
VALUES
('Pesho', 'Peshov', 'CEO', 'The boss'),
('Gosho', 'Goshov', 'Receptionist', NULL),
('Stamat', 'Stamatov', 'Housekeeper', NULL)

CREATE TABLE Customers(
	AccountNumber INT IDENTITY(1,1) PRIMARY KEY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(20),
	EmergencyName NVARCHAR(50) NOT NULL,
	EmergencyNumber VARCHAR(20),
	Notes NVARCHAR(MAX)
)
INSERT INTO Customers(FirstName, LastName, EmergencyName)
VALUES
('Pesho', 'Peshov', 'Petur'),
('Gosho', 'Goshov', 'Georgi'),
('Stamat', 'Stamatov', 'Stavri')

CREATE TABLE RoomStatus(
	RoomStatus VARCHAR(20) PRIMARY KEY,
	Notes NVARCHAR(MAX)
)
INSERT INTO RoomStatus(RoomStatus)
VALUES
('Free'),
('Occupied'),
('Reserved')

CREATE TABLE RoomTypes(
	RoomType VARCHAR(20) PRIMARY KEY,
	Notes NVARCHAR(MAX)
)
INSERT INTO RoomTypes(RoomType)
VALUES
('Small'),
('Large'),
('Suite')

CREATE TABLE BedTypes(
	BedType VARCHAR(20) PRIMARY KEY,
	Notes NVARCHAR(MAX)
)
INSERT INTO BedTypes(BedType)
VALUES
('Single'),
('Double'),
('King Size')

CREATE TABLE Rooms(
	RoomNumber INT IDENTITY(1,1) PRIMARY KEY,
	RoomType VARCHAR(20) FOREIGN KEY REFERENCES RoomTypes(RoomType) NOT NULL,
	BedType VARCHAR(20) FOREIGN KEY REFERENCES BedTypes(BedType) NOT NULL,
	Rate DECIMAL(8,2) NOT NULL,
	RoomStatus VARCHAR(20) FOREIGN KEY REFERENCES RoomStatus(RoomStatus) NOT NULL,
	Notes NVARCHAR(MAX)
)
INSERT INTO Rooms
VALUES
('Small', 'Single', 30, 'Free', NULL),
('Large', 'Double', 60, 'Free', NULL),
('Suite', 'Double', 80, 'Reserved', NULL)

CREATE TABLE Payments(
	Id INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
    PaymentDate DATETIME NOT NULL,
    AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
    FirstDateOccupied DATETIME,
    LastDateOccupied DATETIME,
    TotalDays INT NOT NULL,
    AmountCharged DECIMAL(10, 2),
    TaxRate DECIMAL(10, 2),
    TaxAmount DECIMAL(10, 2),
    PaymentTotal DECIMAL(10, 2) NOT NULL,
	Notes NVARCHAR(MAX)
)
INSERT INTO Payments(EmployeeId, PaymentDate, AccountNumber, TotalDays, PaymentTotal)
VALUES
(1, 22/04/2018, 2, 5, 380),
(2, 13/07/2018, 1, 2, 270),
(3, 20/07/2018, 3, 1, 90)

CREATE TABLE Occupancies(
	Id INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
    DateOccupied DATETIME NOT NULL,
    AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
    RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber) NOT NULL,
    RateApplied DECIMAL(10, 2) NOT NULL,
    PhoneCharge DECIMAL(10, 2),
	Notes NVARCHAR(MAX)
)
INSERT INTO Occupancies(EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied)
VALUES
(1, 12/05/2018, 2, 1, 66.50),
(2, 7/01/2018, 1, 2, 88),
(3, 21/04/2018, 3, 3, 93)

/*Problem 16. Create SoftUni Database*/
CREATE DATABASE SoftUni
GO
USE SoftUni

CREATE TABLE Towns(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Addresses(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	AddressText NVARCHAR(150) NOT NULL,
	TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL,
)

CREATE TABLE Departments(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(50),
	LastName NVARCHAR(50) NOT NULL,
	JobTitle NVARCHAR(80) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL,
	HireDate DATETIME,
	Salary DECIMAL(10,2) NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id),
)

/*Problem 17. Backup Database*/
BACKUP DATABASE SoftUni
TO DISK = 'C:\SoftUni\Databases_Basics_MS_SQL_Server\02_Data_Definition_and_Datatypes\SoftUniDB.bak'

USE Movies
DROP DATABASE SoftUni

RESTORE DATABASE SoftUni
FROM DISK = 'C:\SoftUni\Databases_Basics_MS_SQL_Server\02_Data_Definition_and_Datatypes\SoftUniDB.bak'

/*Problem 18. Basic Insert*/
USE SoftUni

INSERT INTO Towns
VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

INSERT INTO Departments
VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')

INSERT INTO Employees(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
VALUES
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, 01/02/2013, 3500.00),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, 02/03/2004, 4000.00),
('Maria', 'Petrova', 'Ivanova', 'Intern', 5, 28/08/2016, 525.25),
('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, 09/12/2007, 3000.00),
('Peter', 'Pan', 'Pan',	'Intern', 3, 28/08/2016, 599.88)

/*Problem 19. Basic Select All Fields*/
SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees

/*Problem 20. Basic Select All Fields and Order Them*/
SELECT * FROM Towns
ORDER BY [Name]

SELECT * FROM Departments
ORDER BY [Name]

SELECT * FROM Employees
ORDER BY Salary DESC

/*Problem 21. Basic Select Some Fields*/
SELECT [Name] FROM Towns
ORDER BY [Name]

SELECT [Name] FROM Departments
ORDER BY [Name]

SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC

/*Problem 22. Increase Employees Salary*/
UPDATE Employees
SET Salary *= 1.1
SELECT Salary FROM Employees

/*Problem 23. Decrease Tax Rate*/
USE Hotel

UPDATE Payments
SET TaxRate *= 0.97
SELECT TaxRate FROM Payments

/*Problem 24. Delete All Records*/
TRUNCATE TABLE Occupancies