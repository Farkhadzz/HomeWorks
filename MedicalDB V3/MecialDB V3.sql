USE [MedicalDB V3]

CREATE TABLE [Departments]
(
[Id] int IDENTITY (1,1) PRIMARY KEY NOT NULL,
[Building] int NOT NULL CHECK ([BUILDING] > 0 AND [BUILDING] < 6),
[Financing] MONEY NOT NULL CHECK ([Financing] >= 0),
[Name] nvarchar(100) NOT NULL UNIQUE CHECK ([Name] <> '')
);

CREATE TABLE [Doctors]
(
[Id] int IDENTITY (1,1) PRIMARY KEY NOT NULL,
[Name] nvarchar(100) NOT NULL UNIQUE CHECK ([Name] <> ''),
[Salary] money NOT NULL DEFAULT 0 CHECK ([Salary] > 0),
[Surname] nvarchar(max) NOT NULL CHECK ([Surname] <> '')
);

CREATE TABLE [DoctorsExaminations]
(
[Id] INT IDENTITY (1,1) NOT NULL PRIMARY KEY ,
[Date] DATE CHECK ([Date] < GETDATE()),
[DoctorId] INT NOT NULL FOREIGN KEY REFERENCES [Doctors]([Id]),
[DiasesId] INT NOT NULL FOREIGN KEY REFERENCES [Diases]([Id]),
[ExaminationId] INT NOT NULL FOREIGN KEY REFERENCES [Examinations]([Id]),
[WardId] INT NOT NULL FOREIGN KEY REFERENCES [Wards]([Id]),
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

CREATE TABLE [Diases]
(
  Id INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
  Name NVARCHAR(MAX) NOT NULL CHECK ([Name] <> '')
);

CREATE TABLE [Professors]
(
    Id INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
    DoctorId INT NOT NULL FOREIGN KEY REFERENCES [Doctors]([Id])
);

CREATE TABLE [Interns]
(
    Id INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
    DoctorId INT NOT NULL FOREIGN KEY REFERENCES [Doctors]([Id])
);

--1

SELECT [Wards].[Name], [Wards].[Places] FROM [Wards]
INNER JOIN [Departments] ON [Wards].[DepartmentId] = [Departments].[Id]
WHERE [Departments].[Building] = 5 AND [Wards].[Places] >= 5
AND EXISTS
(

    SELECT [Wards].[Places] FROM [Wards] WHERE [Places] > 15 AND [Departments].[Building] = 5
)

--2

SELECT [Departments].[Name] FROM [Departments]
INNER JOIN [Wards] ON [Departments].[Id] = [Wards].[DepartmentId]
INNER JOIN [DoctorsExaminations] ON [Wards].[Id] = [DoctorsExaminations].[WardId]
SELECT COUNT([DoctorsExaminations].[ExaminationId]) AS Deps FROM [DoctorsExaminations] WHERE [DoctorsExaminations].[ExaminationId] > 0;

--3

SELECT [Diases].[Name] FROM [Diases]
INNER JOIN [DoctorsExaminations] ON [Diases].[Id] = [DoctorsExaminations].[DiasesId]
SELECT COUNT([DoctorsExaminations].[ExaminationId]) AS Diases FROM [DoctorsExaminations] WHERE [DoctorsExaminations].[ExaminationId] = 0;

--4

SELECT [Doctors].[Name], [Doctors].[Surname] FROM [Doctors]
INNER JOIN [DoctorsExaminations] ON [Doctors].[Id] = [DoctorsExaminations].[DoctorId]
SELECT COUNT([DoctorsExaminations].[ExaminationId]) AS Doctors FROM [DoctorsExaminations] WHERE [DoctorsExaminations].[ExaminationId] = 0;

--5

SELECT [Departments].[Name] FROM [Departments]
INNER JOIN [Wards] ON [Wards].[DepartmentId] = [Departments].[Id]
INNER JOIN [DoctorsExaminations] ON [Wards].[Id] = [DoctorsExaminations].[WardId]
SELECT COUNT([DoctorsExaminations].[ExaminationId]) AS Deps FROM [DoctorsExaminations] WHERE [DoctorsExaminations].[ExaminationId] = 0 ;
