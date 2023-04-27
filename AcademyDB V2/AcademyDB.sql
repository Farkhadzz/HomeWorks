use [Academy];

--1

SELECT *FROM [Departments] ORDER BY [Id] desc

--2

SELECT [Name], [Rating] FROM [Groups]

--3

SELECT [Surname] , ([Premium] / [Salary] * 100) AS 'Percent Of Premium Rate' , (1 + [Premium]/[Salary]) * 100 AS 'Percent Of Total Rate' FROM [Teachers]

--4

SELECT CONCAT('The Dean Of Faculty : ', [Name], ' is ', [Dean], '.') AS 'Faculty Info' FROM [Faculties]

--5

SELECT *FROM [Teachers] [Surname] WHERE [Salary] > 1050 AND [IsProfessor] = 1

--6

SELECT [Name] FROM [Departments] WHERE [Financing] > 25000 OR [Financing] < 11000

--7

SELECT [Name] FROM [Faculties] WHERE [Name] != 'Computer Science'

--8

SELECT [Surname], [Position] FROM [Teachers] WHERE [IsProfessor] = 0

--9

SELECT [Surname] , [Position], [Salary] , [Premium] FROM [Teachers] WHERE [IsAssistant] = 1 AND [Premium] BETWEEN 160 AND 550

--10

SELECT [Surname] , [Position] FROM [Teachers] WHERE [IsAssistant] = 1

--11

SELECT [Surname] , [Position] FROM [Teachers] WHERE [EmploymentDate] < '2000-01-01'

--12

SELECT [Name] FROM [Departments] WHERE [Name] < 'Software Development' ORDER BY [Name] ASC

--13

SELECT [Surname] FROM [Teachers] WHERE [IsAssistant] = 1 AND [Salary] + [Premium] <= 1200

--14

SELECT [Name] FROM [Groups] WHERE [Year] = 5 AND [Rating] < 5 AND [Rating] > 1

--15

SELECT [Surname], [Salary] FROM [Teachers] WHERE [IsAssistant] = 1 AND ([Salary] < 550 OR [Premium] < 200)