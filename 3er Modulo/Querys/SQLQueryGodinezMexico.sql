CREATE DATABASE [Godinez_Mexico]

USE [Godinez_Mexico]
GO

CREATE TABLE [dbo].[Person](
	[PersonId][int] IDENTITY (1,1) NOT NULL,
	[Name][nvarchar](50) NOT NULL,
	[Last Name][nvarchar](50) NOT NULL,
	[StateId][int] NOT NULL,
	[BirthDate][Date] NOT NULL
	) ON [PRIMARY]
GO

CREATE TABLE [dbo].[State](
	[StateId][int] IDENTITY (1,1) NOT NULL,
	[Name][nvarchar](50) NOT NULL
	) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Job](
	[JobId][int] IDENTITY (1,1) NOT NULL,
	[Description][nvarchar](50) NOT NULL,
	[Company][nvarchar](50) NOT NULL,
	) ON [PRIMARY]
GO

CREATE TABLE [dbo].[PersonJob](
	[PersonJobId][int] IDENTITY (1,1) NOT NULL,
	[JobId][int] NOT NULL,
	[PersonId][int] NOT NULL
	) ON [PRIMARY]
GO

----------------------------PROCEDURE----------------------------------

ALTER PROCEDURE usp_CreatePerson(
	@Name nvarchar(50),
	@LastName nvarchar(50),
	@StateId int,
	@BirthDate Date = NULL)
AS
	INSERT INTO [dbo].[Person] ([Name],[Last Name],[StateId],[BirthDate]) VALUES
	(@Name, @LastName, @StateId, @BirthDate)
GO

CREATE PROCEDURE usp_CreateState(
	@Name nvarchar(50))
AS
	INSERT INTO [dbo].[State] ([Name]) VALUES
	(@Name)
GO

CREATE PROCEDURE usp_CreateJob(
	@Description nvarchar(50),
	@Company nvarchar(50))
AS
	INSERT INTO [dbo].[Job] ([Description],[Company]) VALUES
	(@Description, @Company)
GO

CREATE PROCEDURE usp_CreatePersonJob(
	@JobId int,
	@PersonId int)
AS
	INSERT INTO [dbo].[PersonJob] ([JobId],[PersonId]) VALUES
	(@JobId,@PersonId)
GO

----------------------------DATA---------------------------------------

EXEC usp_CreateState @Name = 'Baja California'
EXEC usp_CreateState @Name = 'Baja California Sur'
EXEC usp_CreateState @Name = 'Veracruz'
EXEC usp_CreateState @Name = 'Sonora'
EXEC usp_CreateState @Name = 'California'
EXEC usp_CreateState @Name = 'Sinaloa'

SELECT * FROM [State]

EXEC usp_CreatePerson @Name = 'David', @LastName = 'Rodriguez', @StateId = 1
EXEC usp_CreatePerson @Name = 'Sandra', @LastName = 'De la Cruz', @StateId = 1
EXEC usp_CreatePerson @Name = 'Alexis', @LastName = 'Garza', @StateId = 1
EXEC usp_CreatePerson @Name = 'Julio', @LastName = 'Melchor', @StateId = 3
EXEC usp_CreatePerson @Name = 'Marcel', @LastName = 'Celaya', @StateId = 1
EXEC usp_CreatePerson @Name = 'Gerardo', @LastName = 'Soto', @StateId = 1
EXEC usp_CreatePerson @Name = 'Eduardo', @LastName = 'Gallegos', @StateId = 4
EXEC usp_CreatePerson @Name = 'Armando', @LastName = 'Marquez', @StateId = 1
EXEC usp_CreatePerson @Name = 'Jorge', @LastName = 'Torres', @StateId = 1
EXEC usp_CreatePerson @Name = 'Diego', @LastName = 'Padilla', @StateId = 1
EXEC usp_CreatePerson @Name = 'Alan', @LastName = 'Navarro', @StateId = 1
EXEC usp_CreatePerson @Name = 'Alan', @LastName = 'Preciado', @StateId = 1
EXEC usp_CreatePerson @Name = 'Fernando', @LastName = 'Nieves', @StateId = 1
EXEC usp_CreatePerson @Name = 'Amanda', @LastName = 'Rubio', @StateId = 1
EXEC usp_CreatePerson @Name = 'Tonatiuh', @LastName = 'Sanchez', @StateId = 1
EXEC usp_CreatePerson @Name = 'Max', @LastName = 'Zamarripa', @StateId = 1
EXEC usp_CreatePerson @Name = 'David', @LastName = 'Cruz', @StateId = 2
EXEC usp_CreatePerson @Name = 'Felix', @LastName = 'Najera', @StateId = 1
EXEC usp_CreatePerson @Name = 'Gustavo', @LastName = 'Loera', @StateId = 1
EXEC usp_CreatePerson @Name = 'Sara', @LastName = 'Rodriguez', @StateId = 2
EXEC usp_CreatePerson @Name = 'Jesus', @LastName = 'Alcantar', @StateId = 1
EXEC usp_CreatePerson @Name = 'Jesus', @LastName = 'Rascon', @StateId = 4
EXEC usp_CreatePerson @Name = 'Cesar', @LastName = 'Solorio', @StateId = 5
EXEC usp_CreatePerson @Name = 'Edy', @LastName = 'Espinoza', @StateId = 6

SELECT * FROM Person

EXEC usp_CreateJob @Description = 'Vendedor', @Company = 'Uniformes'
EXEC usp_CreateJob @Description = 'Artista', @Company = 'Arte Digital'
EXEC usp_CreateJob @Description = 'Maestro', @Company = 'UNAM'
EXEC usp_CreateJob @Description = 'Cadete', @Company = 'Grammar Nazi'
EXEC usp_CreateJob @Description = 'Maestro', @Company = 'Baile'
EXEC usp_CreateJob @Description = 'Vendedor', @Company = 'Grupo Modelo'
EXEC usp_CreateJob @Description = 'Conductor', @Company = 'UBER'
EXEC usp_CreateJob @Description = 'Conductor', @Company = 'Taxi'
EXEC usp_CreateJob @Description = 'Ingeniero', @Company = 'SpaceX'
EXEC usp_CreateJob @Description = 'Maestro', @Company = 'CETYS'
EXEC usp_CreateJob @Description = 'Ingeniero', @Company = 'NAVICO'
EXEC usp_CreateJob @Description = 'Ingeniero', @Company = 'ISOTEC'
EXEC usp_CreateJob @Description = 'Traductora', @Company = 'Traduccion'
EXEC usp_CreateJob @Description = 'Programador', @Company = 'Softtek'
EXEC usp_CreateJob @Description = 'Programador', @Company = 'Sony'
EXEC usp_CreateJob @Description = 'Diseñador', @Company = 'Samsung'

SELECT * FROM Job

EXEC usp_CreatePersonJob @JobId = 1, @PersonId = 1
EXEC usp_CreatePersonJob @JobId = 2, @PersonId = 2
EXEC usp_CreatePersonJob @JobId = 3, @PersonId = 4
EXEC usp_CreatePersonJob @JobId = 4, @PersonId = 8
EXEC usp_CreatePersonJob @JobId = 5, @PersonId = 8
EXEC usp_CreatePersonJob @JobId = 6, @PersonId = 9
EXEC usp_CreatePersonJob @JobId = 7, @PersonId = 11
EXEC usp_CreatePersonJob @JobId = 8, @PersonId = 11
EXEC usp_CreatePersonJob @JobId = 9, @PersonId = 12
EXEC usp_CreatePersonJob @JobId = 10, @PersonId = 14
EXEC usp_CreatePersonJob @JobId = 11, @PersonId = 17
EXEC usp_CreatePersonJob @JobId = 12, @PersonId = 19
EXEC usp_CreatePersonJob @JobId = 13, @PersonId = 20
EXEC usp_CreatePersonJob @JobId = 14, @PersonId = 21
EXEC usp_CreatePersonJob @JobId = 14, @PersonId = 22
EXEC usp_CreatePersonJob @JobId = 15, @PersonId = 22
EXEC usp_CreatePersonJob @JobId = 16, @PersonId = 22
EXEC usp_CreatePersonJob @JobId = 14, @PersonId = 23
EXEC usp_CreatePersonJob @JobId = 14, @PersonId = 24

GO

--------------------------VIEWS--------------------------------------

CREATE VIEW [dbo].[vw_PersonWithJob]
AS 
	SELECT Pe.[PersonId], Pe.[Name], Pe.[Last Name], St.[Name] AS 'State', 
	STUFF(SELECT ',' + Jo.Description
			FROM [Job] Jo
			WHERE PersonJob.[PersonId] = Pe.[PersonId]
			FOR XML PATH('')) 'Works'
	FROM [Person] Pe
	JOIN [State] St ON St.StateId = Pe.StateId
	Group by Pe.[Nombre], Pe.[Age], Pe.[State]

GO

CREATE VIEW [dbo].[vw_PersonWithoutJob]
AS 
	SELECT Pe.[PersonId], Pe.[Name], Pe.[Last Name], St.[Name] AS 'State', Jo.[Description] AS 'Job Description', Jo.[Company] FROM [Person] Pe
	LEFT JOIN [PersonJob] PeJ ON PeJ.[PersonId] = Pe.[PersonId]
	LEFT JOIN [Job] Jo ON Jo.[JobId] = PeJ.[JobId]
	INNER JOIN [State] St ON St.[StateId] = Pe.StateId
	WHERE Jo.Company IS NULL
GO

SELECT DISTINCT [Name] FROM [Person]
GO

CREATE VIEW [dbo].[vw_NumberOfJobs]
AS 

SELECT Per.[Name], Per.[Last Name], NumberofJobs 
FROM
		(SELECT Pe.[PersonId], COUNT(PeJ.PersonId) AS NumberofJobs
		FROM Person Pe 
		LEFT JOIN PersonJob PeJ ON PeJ.PersonId=Pe.PersonId 
		Group By Pe.[PersonId]
		) Jobnumber
		JOIN Person Per ON Per.PersonId = Jobnumber.PersonId
GO

ALTER VIEW [dbo].[vw_PersonState]
AS 
	SELECT Per.[Name], Per.[Last Name], Per.Age, St.[Name] AS 'State'
	FROM Person Per
	JOIN State St ON St.StateId = Per.StateId	
GO

ALTER VIEW [dbo].[vw_AverageAge]

	SELECT State, AVG(Age) as 'Age Average' FROM [vw_PersonState]
	GROUP BY State
GO

CREATE VIEW [dbo].[vw_LivinginState]
AS

SELECT St.[Name], LivPercentage
FROM
(SELECT St.[StateId], (COUNT(Pe.StateId))*100/24 AS LivPercentage
	FROM Person Pe
	LEFT JOIN [State] ST ON St.StateId=Pe.StateId
	Group By St.StateId) StPerc
JOIN [State] St ON StPerc.StateId = St.StateId

GO
