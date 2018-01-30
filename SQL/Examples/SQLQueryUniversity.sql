USE University
GO 

CREATE TABLE [dbo].[Students](
	[StudentId][int]IDENTITY (1,1) NOT NULL,
	[Name][nvarchar](50) NOT NULL,
	[LastName][nvarchar](50) NOT NULL,
	[Age][int] NOT NULL,
	[email][nvarchar](50) NOT NULL,
	[CareerId][int]) ON [PRIMARY]
	GO

CREATE TABLE [dbo].[Teachers](
	[TeacherId][int]IDENTITY (1,1) NOT NULL,
	[Name][nvarchar](50) NOT NULL,
	[LastName][nvarchar](50) NOT NULL,
	[Birthdate][Date] NOT NULL,
	[Telephone][nvarchar](50) NOT NULL,
	[Salary][money],
	[StartDate][Date] NOT NULL,
	[email][nvarchar](50) NOT NULL
	) ON [PRIMARY]
	GO

CREATE TABLE [dbo].[Career](
	[CareerId][int]IDENTITY (1,1) NOT NULL,
	[Name][nvarchar](50) NOT NULL
	) ON [PRIMARY]
	GO

CREATE TABLE [dbo].[Faculty](
	[FacultyId][int]IDENTITY(1,1) NOT NULL,
	[Name][nvarchar](50) NOT NULL
	) ON [PRIMARY]
	GO
CREATE TABLE [dbo].[Classroom](
	[ClassroomId][int]IDENTITY(1,1) NOT NULL,
	[Description][nvarchar](50) NOT NULL,
	[FacultyID][int] NOT NULL
	) ON [PRIMARY]
	GO

CREATE TABLE [dbo].[Subject](
	[SubjectId][int] IDENTITY(1,1) NOT NULL,
	[Name][nvarchar](50) NOT NULL,
	) ON [PRIMARY]
	GO

CREATE TABLE [dbo].[AssignSubject](
	[CareerId][int] NOT NULL,
	[SubjectId][int] NOT NULL,
	) ON [PRIMARY]
	GO

CREATE TABLE [dbo].[AssignCareer](
	[FacultyId][int] NOT NULL,
	[CareerId][int] NOT NULL,
	) ON [PRIMARY]
	GO

CREATE TABLE [dbo].[AssignStudent](
	[StudentId][int] NOT NULL,
	[ClassId][int] NOT NULL
	) ON [PRIMARY]
	GO

CREATE TABLE [dbo].[AssignTeacher](
	[TeacherId][int] NOT NULL,
	[ClassId][int] NOT NULL,
	) ON [PRIMARY]
	GO

CREATE TABLE [dbo].[Class](
	[ClassId][int] IDENTITY (1,1) NOT NULL,
	[SubjectId][int] NOT NULL,
	[Description][nvarchar](50),
	[StartTime][time],
	[EndTime][time],
	[ClasroomId][int]
	) ON [PRIMARY]
	GO