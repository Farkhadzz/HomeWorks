use [MedicalDataBase]

CREATE TABLE [Departments]
(
    Id int IDENTITY (1,1) PRIMARY KEY NOT NULL,
    Building int NOT NULL CHECK (BUILDING > 0 AND BUILDING < 6),
    Financing money NOT NULL DEFAULT 0 CHECK (Financing >= 0),
    Floor int NOT NULL CHECK (Floor >= 1),
    Name nvarchar(100) NOT NULL UNIQUE CHECK (Name <> '')
);

CREATE TABLE [Diseases]
(
  Id int IDENTITY (1,1) PRIMARY KEY NOT NULL,
  Name nvarchar(100) NOT NULL UNIQUE CHECK (Name <> ''),
  Severity int NOT NULL DEFAULT 1 CHECK (Severity >= 1),
);

CREATE TABLE [Doctors]
(
  Id int IDENTITY (1,1) PRIMARY KEY NOT NULL,
  Name nvarchar(100) NOT NULL CHECK (Name <> ''),
  Phone char(10),
  Premium money NOT NULL DEFAULT 0 CHECK (Premium >= 0),
  Salary money NOT NULL CHECK (Salary > 0),
  Surname nvarchar(100) NOT NULL CHECK (Surname <> '')
);

CREATE TABLE [Examinatiions]
(
  Id int IDENTITY (1,1) PRIMARY KEY NOT NULL,
  DayOfWeek int NOT NULL CHECK (DayOfWeek <= 7 AND DayOfWeek >= 1),
  EndTime time NOT NULL CHECK ( EndTime >= '08:00:00' AND EndTime <= '18:00:00'),
  Name nvarchar(100) NOT NULL UNIQUE CHECK (Name <> ''),
  StartTime time NOT NULL CHECK (StartTime >= '08:00:00' AND StartTime <= '18:00:00'),
);

CREATE TABLE [Wards]
(
  Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
  Building int NOT NULL CHECK (Building >= 1 AND Building <= 5),
  Floor int NOT NULL CHECK (Floor >= 1),
  Name nvarchar(20) NOT NULL UNIQUE CHECK (Name <> '')
);

--1

SELECT * FROM [Wards];

--2

SELECT [Surname], [Phone] FROM [Doctors];

--3

SELECT [Floor] FROM [Wards];

--4

SELECT [Name] AS "NameOFDisease", [Severity] AS "SeverityOFDisease" FROM [Diseases];

--5 НЕ ПОНЯЛ

--6

SELECT [Name] FROM [Departments] WHERE [Building] = 5 AND [Financing] < 30000;

--7

SELECT [Name] FROM [Departments] WHERE [Building] = 3 AND [Financing] BETWEEN 12000 AND 15000;

--8

SELECT [Name] FROM [Wards] WHERE [Floor] = 1 AND [Building] IN (4, 5);

--9

SELECT [Name] , [Building] , [Financing] FROM [Departments] WHERE [Building] IN (3,6) AND ([Financing] < 11000 OR [Financing] > 25000);

--10

SELECT [Surname] FROM [Doctors] WHERE ([Premium] + [Salary]) > 1500

--11

SELECT [Surname] FROM [Doctors] WHERE [Salary]/2 > 3*[Premium];

--12 НЕ ПОНЯЛ

--13

SELECT [Name] , [Building] FROM [Departments] WHERE [Building] IN (1,3,8,10);

--14

SELECT [Name] FROM [Diseases] WHERE Severity != 1 AND Severity != 2;

--15

SELECT [Name] FROM [Departments] WHERE [Building] != 1 AND [Building] != 3

--16

SELECT [Name] FROM [Departments] WHERE [Building] IN (1,3);

--17

SELECT [Surname] FROM [Doctors] WHERE [Surname] LIKE 'N%';