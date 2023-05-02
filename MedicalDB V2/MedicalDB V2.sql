use [MedicalDB]

CREATE TABLE [Departments]
(
[Id] int IDENTITY (1,1) PRIMARY KEY NOT NULL,
[Building] int NOT NULL CHECK ([BUILDING] > 0 AND [BUILDING] < 6),
[Name] nvarchar(100) NOT NULL UNIQUE CHECK ([Name] <> '')
);

CREATE TABLE [Doctors]
(
[Id] int IDENTITY (1,1) PRIMARY KEY NOT NULL,
[Name] nvarchar(100) NOT NULL UNIQUE CHECK ([Name] <> ''),
[Premium] money NOT NULL DEFAULT 0 CHECK ([Premium] >= 0),
[Salary] money NOT NULL DEFAULT 0 CHECK ([Salary] > 0),
[Surname] nvarchar(max) NOT NULL CHECK ([Surname] <> '')
);

CREATE TABLE [DoctorsExaminations]
(
[Id] INT IDENTITY (1,1) NOT NULL PRIMARY KEY ,
[EndTime] TIME NOT NULL CHECK ( [EndTime] >= '08:00:00' AND [EndTime] <= '18:00:00'),
[StartTime] TIME NOT NULL CHECK ([StartTime] >= '08:00:00' AND [StartTime] <= '18:00:00'),
[DoctorId] INT NOT NULL FOREIGN KEY REFERENCES [Doctors]([Id]),
[ExaminationId] INT NOT NULL FOREIGN KEY REFERENCES [Examinations]([Id]),
[WardId] INT NOT NULL FOREIGN KEY REFERENCES [Wards]([Id]),
[Name] NVARCHAR(100) NOT NULL CHECK (Name <> '') UNIQUE
);

CREATE TABLE [Examinations]
(
[Id] INT IDENTITY (1,1) NOT NULL PRIMARY KEY ,
[Name] NVARCHAR(100) NOT NULL CHECK ([Name] <> '') UNIQUE
);

CREATE TABLE [Wards]
(
[Id] INT IDENTITY (1,1) NOT NULL PRIMARY KEY ,
[Name] NVARCHAR(20) NOT NULL CHECK ([Name] <> '') UNIQUE,
[Places] INT NOT NULL CHECK ([Places] >= 1),
[DepartmentId] INT NOT NULL FOREIGN KEY REFERENCES [Departments]([Id])
);

--1

SELECT * FROM [Wards] WHERE [Places] > 10

--2

SELECT [Departments].Building, COUNT(Wards.Id) AS [WardsNumber] FROM [Departments] INNER JOIN [Wards] ON [Departments].Id = [Wards].DepartmentId GROUP BY [Departments].Building

--3

SELECT [Departments].Name , COUNT(Wards.Id) AS [DepartmentsNumber] FROM [Departments] INNER JOIN [Wards] ON [Departments].Id = [Wards].DepartmentId GROUP BY [Departments].Name

--4

select Departments.Name, sum(Doctors.Salary + Doctors.Premium) as TotalBonus FROM Departments inner join Wards on Departments.Id = Wards.DepartmentId inner join DoctorsExaminations on Wards.Id = DoctorsExaminations.WardId inner join Doctors on DoctorsExaminations.DoctorId = Doctors.Id group by Departments.Name

--5 НЕ ПОНЯЛ

--6

SELECT [Id] AS [DoctorsCount], SUM([Premium] + [Salary]) AS [TotalSalary] FROM [Doctors] GROUP BY [Doctors].Id

--7

SELECT AVG([Salary] + [Premium]) AS [SalaryAVG] FROM [Doctors]

--8

SELECT Name FROM Wards WHERE Places = (SELECT MIN(Places) FROM [Wards])

--9 НЕ ПОНЯЛ