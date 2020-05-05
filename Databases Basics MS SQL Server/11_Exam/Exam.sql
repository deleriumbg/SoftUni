CREATE DATABASE School


/*1*/
CREATE TABLE Students(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	MiddleName NVARCHAR(25),
	LastName NVARCHAR(30) NOT NULL,
	Age INT CHECK(Age BETWEEN 5 AND 100),
	[Address] NVARCHAR(50),
	Phone CHAR(10) 
)

CREATE TABLE Subjects(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	Lessons INT CHECK(Lessons > 0) NOT NULL
)

CREATE TABLE StudentsSubjects(
	Id INT PRIMARY KEY IDENTITY,
	StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
	SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL,
	Grade DECIMAL(15,2) CHECK(Grade BETWEEN 2 AND 6) NOT NULL
)

CREATE TABLE Exams(
	Id INT PRIMARY KEY IDENTITY,
	[Date] DATE,
	SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL,
)

CREATE TABLE StudentsExams(
	StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
	ExamId INT FOREIGN KEY REFERENCES Exams(Id) NOT NULL,
	Grade DECIMAL(15,2) CHECK(Grade BETWEEN 2 AND 6) NOT NULL,

	PRIMARY KEY(StudentId, ExamId)
)

CREATE TABLE Teachers(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	[Address] NVARCHAR(20) NOT NULL,
	Phone CHAR(10),
	SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL,
)

CREATE TABLE StudentsTeachers(
	StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
	TeacherId INT FOREIGN KEY REFERENCES Teachers(Id) NOT NULL

	PRIMARY KEY(StudentId, TeacherId)
)

/*2*/
INSERT INTO Teachers(FirstName, LastName, [Address], Phone, SubjectId)
VALUES
('Ruthanne','Bamb',	'84948 Mesta Junction',	'3105500146',	6),
('Gerrard',	'Lowin',	'370 Talisman Plaza',	'3324874824',	2),
('Merrile',	'Lambdin',	'81 Dahle Plaza',	'4373065154',	5),
('Bert',	'Ivie',	'2 Gateway Circle',	'4409584510',	4)

INSERT INTO Subjects([Name], Lessons)
VALUES
('Geometry',12),
('Health',	10),
('Drama',	7),
('Sports',	9)

/*3*/
UPDATE StudentsSubjects
SET Grade = 6.00
WHERE SubjectId IN(1,2) AND Grade >= 5.50

/*4*/
DELETE FROM StudentsTeachers
WHERE TeacherId IN(7, 12, 15, 18, 24, 26)
DELETE FROM Teachers
WHERE Phone LIKE('%72%')

SELECT * FROM Teachers
WHERE Phone LIKE('%72%')

/*5*/
SELECT FirstName, LastName, Age FROM Students 
WHERE Age >= 12
ORDER BY FirstName, LastName

/*6*/
SELECT 
	CONCAT(FirstName, ' ', ISNULL(MiddleName + ' ', ' '), LastName) AS [Full Name],
	[Address] 
FROM Students
WHERE [Address] LIKE('%road%')
ORDER BY FirstName, LastName, [Address]

/*7*/
SELECT s.FirstName, s.[Address], s.Phone FROM Students AS s
WHERE s.MiddleName IS NOT NULL AND s.Phone LIKE('42%')
ORDER BY s.FirstName

/*8*/
SELECT s.FirstName, s.LastName, COUNT(st.TeacherId) AS TeachersCount 
FROM Students AS s 
JOIN StudentsTeachers AS st ON s.Id = st.StudentId
GROUP BY s.FirstName, s.LastName

/*9*/
SELECT 
	t.FirstName + ' ' + t.LastName AS FullName,
	s.[Name] + '-' + CONVERT(NVARCHAR(60), s.Lessons) AS Subjects,
	COUNT(st.StudentId) AS Students
FROM Teachers AS t 
JOIN Subjects AS s ON t.SubjectId = s.Id
JOIN StudentsTeachers AS st ON t.Id = st.TeacherId
GROUP BY t.FirstName, t.LastName, s.[Name], s.Lessons
ORDER BY Students DESC, FullName, Subjects

/*10*/
SELECT s.FirstName + ' ' + s.LastName AS [Full Name] 
FROM Students AS s 
LEFT JOIN StudentsExams AS se ON s.Id = se.StudentId
WHERE ExamId IS NULL
ORDER BY [Full Name]

/*11*/
SELECT TOP(10) 
	t.FirstName,
	t.LastName,
	COUNT(st.StudentId) AS StudentsCount
FROM Teachers AS t 
JOIN StudentsTeachers AS st ON t.Id = st.TeacherId
GROUP BY t.FirstName, t.LastName
ORDER BY StudentsCount DESC, t.FirstName, t.LastName

/*12*/
SELECT TOP(10) 
	s.FirstName,
	s.LastName,
	CONVERT(DECIMAL(10,2), AVG(se.Grade)) AS Grade
FROM Students AS s 
JOIN StudentsExams AS se ON s.Id = se.StudentId
GROUP BY s.FirstName, s.LastName
ORDER BY Grade DESC, s.FirstName, s.LastName

/*13*/
SELECT FirstName, LastName, Grade FROM 
	(SELECT 
		s.FirstName,
		s.LastName,
		ss.Grade,
		ROW_NUMBER() OVER (PARTITION BY s.FirstName, s.LastName ORDER BY ss.Grade DESC) AS Rank  
	FROM Students AS s 
	JOIN StudentsSubjects AS ss ON s.Id = ss.StudentId
) AS H
WHERE Rank = 2
ORDER BY H.FirstName, H.LastName

SELECT 

/*14*/
SELECT 
	CONCAT(FirstName, ' ', ISNULL(MiddleName + ' ', ''), LastName) AS [Full Name]
FROM Students AS s 
LEFT JOIN StudentsSubjects AS ss ON s.Id = ss.StudentId
WHERE ss.SubjectId IS NULL
ORDER BY [Full Name]

/*16*/
SELECT 
	s.[Name],
	AVG(ss.Grade)
FROM Subjects AS s 
JOIN StudentsSubjects AS ss ON s.Id = ss.SubjectId
GROUP BY s.[Name], s.Id
ORDER BY s.Id

/*18*/
GO
CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(10,2))
RETURNS NVARCHAR(MAX) AS 
BEGIN
	DECLARE @StudentNumber INT = (SELECT Id FROM Students WHERE Id = @studentId)
	IF @StudentNumber IS NULL 
	BEGIN
		RETURN 'The student with provided id does not exist in the school!'
	END

	IF @grade >= 6.00
	BEGIN
		RETURN 'Grade cannot be above 6.00!'
	END

	DECLARE @GradesCount INT = (SELECT COUNT(*) FROM StudentsExams AS se
								WHERE se.StudentId = @studentId 
								AND @grade + 0.5 <= se.Grade)
	DECLARE @StudentFirstName NVARCHAR(100) = (SELECT FirstName FROM Students
												WHERE Id = @studentId)
	RETURN  'You have to update ' + CONVERT(NVARCHAR(10), @GradesCount) + 
			' grades for the student ' + @StudentFirstName
END

/*19*/
GO
CREATE PROC usp_ExcludeFromSchool(@StudentId INT) AS 
BEGIN
	DECLARE @StudentNumber INT = (SELECT Id FROM Students WHERE Id = @studentId)
	IF @StudentNumber IS NULL
	BEGIN
		RAISERROR('This school has no student with the provided id!', 16, 1)
	END

	DELETE FROM StudentsExams
	WHERE StudentId = @studentId

	DELETE FROM StudentsTeachers
	WHERE StudentId = @studentId
	
	DELETE FROM StudentsSubjects
	WHERE StudentId = @studentId
	
	DELETE FROM Students
	WHERE Id = @studentId
END

/*20*/
CREATE TABLE ExcludedStudents(
	StudentId INT, 
	StudentName NVARCHAR(150)
)

GO
CREATE TRIGGER tr_ExcludedStudents ON Students AFTER DELETE 
AS
BEGIN
	INSERT INTO ExcludedStudents(StudentId, StudentName) 
	SELECT Id, FirstName + ' ' + LastName FROM deleted
END