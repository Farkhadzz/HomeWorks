USE [AcademyDB V3]

CREATE TABLE [Assistants]
(
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    TeacherId INT NOT NULL FOREIGN KEY REFERENCES Teachers([Id])
);

CREATE TABLE [Curators]
(
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    TeacherId INT NOT NULL FOREIGN KEY REFERENCES Teachers([Id]),
);

CREATE TABLE [Deans]
(
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    TeacherId INT NOT NULL FOREIGN KEY REFERENCES Teachers([Id])
);

CREATE TABLE [Departments]
(
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Building INT NOT NULL CHECK ([Building] > 0 AND [Building] < 6),
    Name NVARCHAR(100) NOT NULL UNIQUE CHECK ([Name] <> ''),
    FacultyId INT NOT NULL FOREIGN KEY REFERENCES Faculties([Id]),
    HeadId INT NOT NULL FOREIGN KEY REFERENCES Heads([Id])
);

CREATE TABLE [Faculties]
(
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Building INT NOT NULL CHECK ([Building] > 0 AND [Building] < 6),
    Name NVARCHAR(100) NOT NULL UNIQUE CHECK ([Name] <> ''),
    DeanId INT NOT NULL FOREIGN KEY REFERENCES Deans([Id])
);

CREATE TABLE [Groups]
(
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL UNIQUE CHECK([Name] <> ''),
    Year INT NOT NULL CHECK([Year] > 0 AND [Year] < 6),
    DepartmentId INT NOT NULL FOREIGN KEY REFERENCES Departments([Id])
);

CREATE TABLE [GroupsCurators]
(
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    CuratorId INT NOT NULL FOREIGN KEY REFERENCES Curators([Id]),
    GroupId INT NOT NULL FOREIGN KEY REFERENCES Groups([Id])
);

CREATE TABLE [GroupsLectures]
(
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    GroupId INT NOT NULL FOREIGN KEY REFERENCES Groups([Id]),
    LectureId INT NOT NULL FOREIGN KEY REFERENCES Lectures([Id])
);

CREATE TABLE [Heads]
(
    Id INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
    TeacherId INT NOT NULL FOREIGN KEY REFERENCES Teachers([Id])
);

CREATE TABLE [LectureRooms]
(
    Id INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
    Building INT NOT NULL CHECK ([Building] > 0 AND [Building] < 6),
    Name NVARCHAR(10) NOT NULL UNIQUE CHECK ([Name] <> '')
);

CREATE TABLE [Lectures]
(
    Id INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
    SubjectId INT NOT NULL FOREIGN KEY REFERENCES Subjects([Id]),
    TeacherId INT NOT NULL FOREIGN KEY REFERENCES Teachers([Id]),
);

CREATE TABLE [Schedules]
(
    Id INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
    Class INT NOT NULL CHECK ([Class] > 0 AND [Class] <9),
    DayOfWeek INT NOT NULL CHECK ([DayOfWeek] > 0 AND [DayOfWeek] < 8),
    Week INT NOT NULL CHECK ([Week] > 0 AND [Week] < 53),
    LectureId INT NOT NULL FOREIGN KEY REFERENCES Lectures([Id]),
    LectureRoomId INT NOT NULL FOREIGN KEY REFERENCES Lectures([Id])
);

CREATE TABLE [Subjects]
(
    Id INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL UNIQUE CHECK ([Name] <> '')
);

CREATE TABLE [Teachers]
(
    Id INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
    Name NVARCHAR(MAX) NOT NULL CHECK ([Name] <> ''),
    Surname NVARCHAR(MAX) NOT NULL CHECK ([Surname] <> '')
);

--1

SELECT [LectureRooms].[Name] FROM [LectureRooms] INNER JOIN [Teachers] ON [LectureRooms].[Id] = [Teachers].[Id] WHERE [Teachers].[Name] = 'Edward' AND [Teachers].[Surname] = 'Hopper';

--2

SELECT [Teachers].[Surname] AS [AssistantName]
FROM [Teachers]
INNER JOIN [Heads] ON [Teachers].[Id] = [Heads].[TeacherId]
INNER JOIN [Departments] ON [Heads].[Id] = [Departments].[HeadId]
INNER JOIN [Groups] ON [Departments].[Id] = [Groups].[DepartmentId]
INNER JOIN [Assistants] ON [Assistants].[TeacherId]
WHERE [Groups].[Name] = 'F505';

--3

SELECT * FROM [Lectures]
INNER JOIN [Subjects] ON [Lectures].[Id] = [Subjects].[Id]
INNER JOIN [GroupsLectures] ON [Lectures].[Id] = [GroupsLectures].[Id]
INNER JOIN [Groups] ON [GroupsLectures].[Id] = [Groups].[Id]
INNER JOIN [Teachers] ON [Lectures].[TeacherId] = [Teachers].[Id]
WHERE [Groups].[Year] = 5 AND [Teachers].[Name] = 'Alex' AND [Teachers].[Surname] = 'Carmack';

--4

SELECT [Surname] FROM [Teachers]
WHERE NOT EXISTS
(
    SELECT * FROM [Lectures] INNER JOIN [Schedules] ON [Lectures].[id] = [Schedules].[LectureId]
    WHERE [Lectures].[TeacherId] = [Teachers].[Id] AND [Schedules].[DayOfWeek] = 1
);

--5

SELECT [Name], [Building] FROM [LectureRooms]
WHERE NOT EXISTS
(
    SELECT * FROM [Lectures] INNER JOIN [Schedules] ON [Lectures].[id] = [Schedules].[LectureId]
    WHERE [Schedules].[DayOfWeek] = 3 AND [Schedules].[Week] = 2 AND [Schedules].[Class] = 3
);

--6

SELECT [Teachers].[Name], [Teachers].[Surname] FROM [Teachers]
INNER JOIN Deans ON [Teachers].[Id] = [Deans].[TeacherId]
INNER JOIN [Faculties] ON [Deans].[Id] = [Faculties].[DeanId]
WHERE [Faculties].[Name] = 'Computer Science' AND NOT EXISTS
(
    SELECT * FROM [Teachers]
    INNER JOIN [Heads] ON [Teachers].[Id] = [Heads].[TeacherId]
    INNER JOIN [Departments] ON [Heads].[Id] = [Departments].[HeadId]
    WHERE [Departments].[Name] = 'Software Development'
);

--7

SELECT DİSTİNCT [Building] FROM (
    SELECT [Building] FROM [Faculties]
    UNION
    SELECT [Building] FROM [Departments]
    UNION
    SELECT [Building] FROM [LectureRooms]
) AS Buildings

--8 НЕ ПОНЯЛ

--9

SELECT [DayOfWeek] FROM [Schedules]
INNER JOIN [LectureRooms] ON [Schedules].[LectureRoomId] = [LectureRooms].[Id]
WHERE [LectureRooms].[Name] = 'A311' AND [LectureRooms].[Name] = 'A104' AND [LectureRooms].[Building] = 6;