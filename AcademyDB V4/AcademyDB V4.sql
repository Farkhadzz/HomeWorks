use [AcademyDB V4]

CREATE TABLE [Curators]
(
    [Id] INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
    [Name] NVARCHAR(MAX) NOT NULL,
    [Surname] NVARCHAR(MAX) NOT NULL
);

CREATE TABLE [Faculties]
(
    [Id] INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
    [Name] NVARCHAR(100) UNIQUE NOT NULL
);

CREATE TABLE [Teachers]
(
    [Id] INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
    [Name] NVARCHAR(MAX) NOT NULL,
    [Surname] NVARCHAR(MAX) NOT NULL,
    [IsProfessor] BIT DEFAULT 0 NOT NULL,
    [Salary] MONEY CHECK ([Salary] > 0) NOT NULL
);

CREATE TABLE [Departments]
(
    [Id] INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
    [Building] INT CHECK ([Building] BETWEEN 1 AND 5) NOT NULL,
    [Name] NVARCHAR(100) UNIQUE NOT NULL,
    [FacultyID] INT FOREIGN KEY REFERENCES [Faculties]([Id]),
    [Financing] INT DEFAULT 0 CHECK ([Financing] > 0) NOT NULL
);

CREATE TABLE [Groups]
(
    [Id] INT IDENTITY (1, 1) PRIMARY KEY NOT NULL,
    [Name] NVARCHAR(10) UNIQUE NOT NULL,
    [Year] INT CHECK ([Year] BETWEEN 1 AND 5) NOT NULL,
    [DepartmentID] INT FOREIGN KEY REFERENCES [Departments]([Id])
);

CREATE TABLE [GroupsCurators]
(
    [Id] INT IDENTITY (1, 1) PRIMARY KEY NOT NULL,
    [CuratorID] INT FOREIGN KEY REFERENCES [Curators]([Id]),
    [GroupID] INT FOREIGN KEY REFERENCES [Groups]([Id])
);

CREATE TABLE [Subjects]
(
    [Id] INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
    [Name] NVARCHAR(100) UNIQUE NOT NULL
);

CREATE TABLE [Lectures]
(
    [Id] INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
    [Date] DATE CHECK ([Date] <= GETDATE()),
    [SubjectID] INT FOREIGN KEY REFERENCES [Subjects]([Id]),
    [TeacherID] INT FOREIGN KEY REFERENCES [Teachers]([Id])
);

CREATE TABLE [GroupsLectures]
(
    [Id] INT IDENTITY (1, 1) PRIMARY KEY NOT NULL,
    [GroupID] INT FOREIGN KEY REFERENCES [Groups]([Id]),
    [LectureID] INT FOREIGN KEY REFERENCES [Lectures]([Id])
);

CREATE TABLE [Students]
(
    [Id] INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
    [Name] NVARCHAR(100) NOT NULL,
    [Surname] NVARCHAR(100) NOT NULL,
    [Rating] INT CHECK ([Rating] BETWEEN 0 AND 4)
);

CREATE TABLE [GroupsStudents]
(
    [Id] INT IDENTITY (1, 1) PRIMARY KEY NOT NULL,
    [GroupID] INT FOREIGN KEY REFERENCES [Groups]([Id]),
    [StudentID] INT FOREIGN KEY REFERENCES [Students]([Id])
);

--1

SELECT [Building] FROM [Departments] WHERE [Financing] > 100000;

--2

SELECT [Groups].[Name] FROM [Groups]
INNER JOIN [Departments] ON [Groups].[DepartmentID] = [Departments].[Id]
WHERE [Departments].[Name] = N'Software Development' AND [Groups].[Year] = 5;

--3

SELECT [Groups].[Name] FROM [Groups]
INNER JOIN [GroupsStudents] ON [Groups].[Id] = [GroupsStudents].[GroupID]
INNER JOIN [Students] ON [GroupsStudents].[StudentId] = [Students].[Id]
WHERE [Rating] > (SELECT AVG([Rating]) FROM [Students] WHERE [Groups].[Name] = 'D221')

--4

SELECT [Teachers].[Name], [Teachers].[Surname] FROM [Teachers]
WHERE [Salary] > (SELECT AVG([Salary]) FROM [Teachers] WHERE [IsProfessor] = 1)

--5

SELECT [Groups].[Name] FROM [Groups]
INNER JOIN [GroupsCurators] ON [Groups].[Id] = [GroupsCurators].[GroupId]
INNER JOIN [Curators] ON [GroupsCurators].[CuratorId] = [Curators].[Id]
GROUP BY [Groups].[Name]
HAVING COUNT([Curators].[Id]) > 1

--6

SELECT [Groups].[Name] FROM [Groups]
INNER JOIN [GroupsStudents] ON [Groups].[Id] = [GroupsStudents].[GroupId]
INNER JOIN [Students] ON [GroupsStudents].[StudentId] = [Students].[Id]
WHERE (SELECT AVG([Rating]) FROM [Students]) < (SELECT MIN([Rating]) FROM [Students] WHERE ([Groups].[Year] = 5))

--7

SELECT Faculties.[Name] FROM [Faculties]
INNER JOIN [Departments] ON [Faculties].[Id] = [Departments].[FacultyId]
WHERE (SELECT SUM([Departments].[Financing]) FROM [Departments]) > (SELECT SUM([Departments].[Financing]) FROM [Departments] INNER JOIN [Faculties] ON [Faculties].[Id] = [Departments].[FacultyId] WHERE [Faculties].[Name] = 'Computer Science')