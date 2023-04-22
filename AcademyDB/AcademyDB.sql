CREATE TABLE Groups
(
Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
Name nvarchar(10) NOT NULL UNIQUE,
Rating int NOT NULL CHECK(Rating > 0 AND RATING < 6),
Year int NOT NULL CHECK(Year > 0 AND Year < 6),
);

CREATE TABLE Departments
(
Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
Financing money NOT NULL DEFAULT 0 CHECK(Financing > 0),
Name nvarchar(100) NOT NULL UNIQUE
);

CREATE TABLE Faculties
(
Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
Name nvarchar(100) NOT NULL UNIQUE
);

CREATE TABLE Teachers
(
Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
EmploymentDate date NOT NULL CHECK(EmploymentDate >= '1990-01-01'),
Name nvarchar(max) NOT NULL,
Premium money DEFAULT 0 CHECK(Premium > -1),
Salary money NOT NULL CHECK(Salary > 0),
Surname nvarchar(max) NOT NULL
);