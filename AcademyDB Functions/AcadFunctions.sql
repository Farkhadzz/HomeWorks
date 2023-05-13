use [AcademyDB V4]

-- Functions

--1

INSERT INTO [Teachers] VALUES ('Farkhad', 'Zulfugarov', 1, 7000)

CREATE FUNCTION TeacherId(@TeacherID INT)
RETURNS NVARCHAR(MAX)
AS
BEGIN
    DECLARE @TeachersName NVARCHAR(MAX)
    SELECT @TeachersName = [Name] FROM Teachers WHERE [Id] = @TeacherID
    RETURN @TeachersName
END

DECLARE @TeacherName NVARCHAR(MAX)
SET @TeacherName = dbo.TeacherId(1)
SELECT @TeacherName AS 'Teacher Name :'

--2

CREATE FUNCTION GroupNameWithId(@Id INT)
RETURNS NVARCHAR(MAX)
AS
BEGIN
    DECLARE @GroupName NVARCHAR(MAX)
    SELECT @GroupName = [Name] FROM Groups WHERE [Id] = @Id
    RETURN @GroupName
END

DECLARE @GroupName NVARCHAR(MAX)
SET @GroupName = dbo.GroupNameWithId(1)
SELECT @GroupName AS 'Group Name :'

--3 (Почему то не запускается)

CREATE FUNCTION StudentInGroup(@StudentID INT)
RETURNS NVARCHAR(MAX)
AS
BEGIN
   DECLARE @GroupName NVARCHAR(MAX)
   SELECT @GroupName = [Name] FROM [Groups]
   INNER JOIN [GroupsStudents] ON [Groups].[Id] = [GroupsStudents].[GroupId]
   INNER JOIN [Students] ON [GroupsStudents].[StudentId] = [Students].[Id]
   WHERE @StudentID = [Students].[Id]
END

--4

CREATE FUNCTION GetStudentsByGroupName (@GroupName NVARCHAR(10))
RETURNS TABLE
AS
RETURN
(
    SELECT [Students].[Name] FROM Students
    JOIN GroupsStudents ON GroupsStudents.StudentID = Students.ID
    JOIN Groups ON Groups.ID = GroupsStudents.GroupID
    WHERE Groups.Name = @GroupName
);

--Prorecuders

--1

CREATE PROCEDURE InsertStudent(@StudentName NVARCHAR(MAX), @StudentSurname NVARCHAR(MAX), @StudentRating INT)
AS
BEGIN
    INSERT INTO [Students] VALUES (@StudentName, @StudentSurname, @StudentRating)
END

EXEC InsertStudent 'Huseyn', 'Magomedov', 3

--2

CREATE PROCEDURE InsertSubject(@SubjectName NVARCHAR(MAX))
AS
BEGIN
    INSERT INTO [Subjects] VALUES (@SubjectName)
END

EXEC InsertSubject 'SQL'

--3

CREATE PROCEDURE InsertFaculty(@FacultyName NVARCHAR(MAX))
AS
BEGIN
    INSERT INTO [Faculties] VALUES (@FacultyName)
END

EXEC InsertFaculty 'Programming'

--4

CREATE PROCEDURE InsertTeacher(@TeacherName NVARCHAR(MAX), @TeacherSurname NVARCHAR(MAX), @TeacherIsProfessor BIT, @TeacherSalary MONEY)
AS
BEGIN
    INSERT INTO [Teachers] VALUES (@TeacherName, @TeacherSurname, @TeacherIsProfessor, @TeacherSalary)
END

EXEC InsertTeacher 'Elvin', 'Azimov', 0, 5000

--5

CREATE PROCEDURE InsertCurator(@CuratorName NVARCHAR(MAX), @CuratorSurname NVARCHAR(MAX))
AS
BEGIN
    INSERT INTO [Curators] VALUES (@CuratorName, @CuratorSurname)
END

EXEC InsertCurator 'Misha', 'Quliyev'