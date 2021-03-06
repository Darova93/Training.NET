USE [master]
GO
/****** Object:  Database [SurveyDB]    Script Date: 2/6/2018 4:55:42 PM ******/
CREATE DATABASE [SurveyDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SurveyDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\SurveyDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SurveyDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\SurveyDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [SurveyDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SurveyDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SurveyDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SurveyDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SurveyDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SurveyDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SurveyDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [SurveyDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [SurveyDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SurveyDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SurveyDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SurveyDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SurveyDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SurveyDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SurveyDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SurveyDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SurveyDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SurveyDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SurveyDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SurveyDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SurveyDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SurveyDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SurveyDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SurveyDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SurveyDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SurveyDB] SET  MULTI_USER 
GO
ALTER DATABASE [SurveyDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SurveyDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SurveyDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SurveyDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SurveyDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SurveyDB] SET QUERY_STORE = OFF
GO
USE [SurveyDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [SurveyDB]
GO
/****** Object:  Table [dbo].[Answers]    Script Date: 2/6/2018 4:55:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answers](
	[AnswerId] [int] IDENTITY(1,1) NOT NULL,
	[QuestionId] [int] NOT NULL,
	[OpenValue] [nvarchar](50) NULL,
	[OptionId] [int] NULL,
 CONSTRAINT [PK_Answers] PRIMARY KEY CLUSTERED 
(
	[AnswerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Options]    Script Date: 2/6/2018 4:55:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Options](
	[OptionId] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Options] PRIMARY KEY CLUSTERED 
(
	[OptionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuestionOptions]    Script Date: 2/6/2018 4:55:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionOptions](
	[QuestionOptionId] [int] IDENTITY(1,1) NOT NULL,
	[OptionId] [int] NOT NULL,
	[QuestionId] [int] NOT NULL,
 CONSTRAINT [PK_QuestionOptions] PRIMARY KEY CLUSTERED 
(
	[QuestionOptionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Questions]    Script Date: 2/6/2018 4:55:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questions](
	[QuestionId] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](50) NOT NULL,
	[QuestionTypeId] [int] NOT NULL,
 CONSTRAINT [PK_Questions] PRIMARY KEY CLUSTERED 
(
	[QuestionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuestionTypes]    Script Date: 2/6/2018 4:55:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionTypes](
	[QuestionTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_QuestionTypes] PRIMARY KEY CLUSTERED 
(
	[QuestionTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Answers] ON 

INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OpenValue], [OptionId]) VALUES (1, 1, NULL, 2)
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OpenValue], [OptionId]) VALUES (2, 2, NULL, 9)
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OpenValue], [OptionId]) VALUES (3, 5, N'Nothing', NULL)
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OpenValue], [OptionId]) VALUES (5, 3, NULL, 6)
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OpenValue], [OptionId]) VALUES (6, 3, NULL, 8)
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OpenValue], [OptionId]) VALUES (7, 3, NULL, 10)
INSERT [dbo].[Answers] ([AnswerId], [QuestionId], [OpenValue], [OptionId]) VALUES (9, 4, NULL, 2)
SET IDENTITY_INSERT [dbo].[Answers] OFF
SET IDENTITY_INSERT [dbo].[Options] ON 

INSERT [dbo].[Options] ([OptionId], [Text]) VALUES (2, N'Yes')
INSERT [dbo].[Options] ([OptionId], [Text]) VALUES (3, N'No')
INSERT [dbo].[Options] ([OptionId], [Text]) VALUES (4, N'Maybe')
INSERT [dbo].[Options] ([OptionId], [Text]) VALUES (5, N'Sometimes')
INSERT [dbo].[Options] ([OptionId], [Text]) VALUES (6, N'Coffee')
INSERT [dbo].[Options] ([OptionId], [Text]) VALUES (7, N'Gay')
INSERT [dbo].[Options] ([OptionId], [Text]) VALUES (8, N'Facebook')
INSERT [dbo].[Options] ([OptionId], [Text]) VALUES (9, N'Everywhere')
INSERT [dbo].[Options] ([OptionId], [Text]) VALUES (10, N'Twitter')
SET IDENTITY_INSERT [dbo].[Options] OFF
SET IDENTITY_INSERT [dbo].[QuestionOptions] ON 

INSERT [dbo].[QuestionOptions] ([QuestionOptionId], [OptionId], [QuestionId]) VALUES (1, 2, 1)
INSERT [dbo].[QuestionOptions] ([QuestionOptionId], [OptionId], [QuestionId]) VALUES (2, 3, 1)
INSERT [dbo].[QuestionOptions] ([QuestionOptionId], [OptionId], [QuestionId]) VALUES (3, 5, 2)
INSERT [dbo].[QuestionOptions] ([QuestionOptionId], [OptionId], [QuestionId]) VALUES (4, 9, 2)
INSERT [dbo].[QuestionOptions] ([QuestionOptionId], [OptionId], [QuestionId]) VALUES (5, 6, 3)
INSERT [dbo].[QuestionOptions] ([QuestionOptionId], [OptionId], [QuestionId]) VALUES (6, 8, 3)
INSERT [dbo].[QuestionOptions] ([QuestionOptionId], [OptionId], [QuestionId]) VALUES (7, 10, 3)
INSERT [dbo].[QuestionOptions] ([QuestionOptionId], [OptionId], [QuestionId]) VALUES (9, 2, 4)
INSERT [dbo].[QuestionOptions] ([QuestionOptionId], [OptionId], [QuestionId]) VALUES (10, 7, 4)
SET IDENTITY_INSERT [dbo].[QuestionOptions] OFF
SET IDENTITY_INSERT [dbo].[Questions] ON 

INSERT [dbo].[Questions] ([QuestionId], [Text], [QuestionTypeId]) VALUES (1, N'Do you like me?', 1)
INSERT [dbo].[Questions] ([QuestionId], [Text], [QuestionTypeId]) VALUES (2, N'How often do you jump', 1)
INSERT [dbo].[Questions] ([QuestionId], [Text], [QuestionTypeId]) VALUES (3, N'Favorite things', 2)
INSERT [dbo].[Questions] ([QuestionId], [Text], [QuestionTypeId]) VALUES (4, N'Are you straight', 1)
INSERT [dbo].[Questions] ([QuestionId], [Text], [QuestionTypeId]) VALUES (5, N'What are you doing', 3)
SET IDENTITY_INSERT [dbo].[Questions] OFF
SET IDENTITY_INSERT [dbo].[QuestionTypes] ON 

INSERT [dbo].[QuestionTypes] ([QuestionTypeId], [Description]) VALUES (1, N'Single')
INSERT [dbo].[QuestionTypes] ([QuestionTypeId], [Description]) VALUES (2, N'Multiple')
INSERT [dbo].[QuestionTypes] ([QuestionTypeId], [Description]) VALUES (3, N'Open')
SET IDENTITY_INSERT [dbo].[QuestionTypes] OFF
ALTER TABLE [dbo].[Answers]  WITH CHECK ADD  CONSTRAINT [FK_Answers_Options] FOREIGN KEY([OptionId])
REFERENCES [dbo].[Options] ([OptionId])
GO
ALTER TABLE [dbo].[Answers] CHECK CONSTRAINT [FK_Answers_Options]
GO
ALTER TABLE [dbo].[Answers]  WITH CHECK ADD  CONSTRAINT [FK_Answers_Questions] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Questions] ([QuestionId])
GO
ALTER TABLE [dbo].[Answers] CHECK CONSTRAINT [FK_Answers_Questions]
GO
ALTER TABLE [dbo].[QuestionOptions]  WITH CHECK ADD  CONSTRAINT [FK_QuestionOptions_Options] FOREIGN KEY([OptionId])
REFERENCES [dbo].[Options] ([OptionId])
GO
ALTER TABLE [dbo].[QuestionOptions] CHECK CONSTRAINT [FK_QuestionOptions_Options]
GO
ALTER TABLE [dbo].[QuestionOptions]  WITH CHECK ADD  CONSTRAINT [FK_QuestionOptions_Questions] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Questions] ([QuestionId])
GO
ALTER TABLE [dbo].[QuestionOptions] CHECK CONSTRAINT [FK_QuestionOptions_Questions]
GO
ALTER TABLE [dbo].[Questions]  WITH CHECK ADD  CONSTRAINT [FK_Questions_QuestionTypes] FOREIGN KEY([QuestionTypeId])
REFERENCES [dbo].[QuestionTypes] ([QuestionTypeId])
GO
ALTER TABLE [dbo].[Questions] CHECK CONSTRAINT [FK_Questions_QuestionTypes]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetErrorInfo]    Script Date: 2/6/2018 4:55:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetErrorInfo]  
AS  
SELECT  
    ERROR_NUMBER() AS ErrorNumber  
    ,ERROR_SEVERITY() AS ErrorSeverity  
    ,ERROR_STATE() AS ErrorState  
    ,ERROR_PROCEDURE() AS ErrorProcedure  
    ,ERROR_LINE() AS ErrorLine  
    ,ERROR_MESSAGE() AS ErrorMessage;  
GO
/****** Object:  StoredProcedure [dbo].[uspDeleteOptions]    Script Date: 2/6/2018 4:55:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspDeleteOptions]
	@id int
AS
/*
Created by: David Rodriguez Vazquez
Description: Deletes an option
*/
	BEGIN TRANSACTION;
	BEGIN TRY 
		DELETE FROM Options
		WHERE [OptionId]=@id
	END TRY
	BEGIN CATCH
		EXEC usp_GetErrorInfo
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;
	END CATCH

	IF @@TRANCOUNT > 0
	COMMIT TRANSACTION;
GO
/****** Object:  StoredProcedure [dbo].[uspDeleteQuestionTypes]    Script Date: 2/6/2018 4:55:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspDeleteQuestionTypes]
	@id int
AS
/*
Created by: David Rodriguez Vazquez
Description: Deletes a question type
*/
	BEGIN TRANSACTION;
	BEGIN TRY
		DELETE FROM QuestionTypes
		WHERE [QuestionTypeId]=@id
	END TRY
	BEGIN CATCH
		EXEC usp_GetErrorInfo
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;
	END CATCH

	IF @@TRANCOUNT > 0
			COMMIT TRANSACTION;
GO
/****** Object:  StoredProcedure [dbo].[uspGetAllOptions]    Script Date: 2/6/2018 4:55:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspGetAllOptions]
AS
/*
Created by: David Rodriguez Vazquez
Description: Shows all options
*/
		BEGIN
		SELECT * FROM [dbo].[Options]
		END
GO
/****** Object:  StoredProcedure [dbo].[uspGetAllQuestionTypes]    Script Date: 2/6/2018 4:55:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspGetAllQuestionTypes]
AS
/*
Created by: David Rodriguez Vazquez
Description: Shows all question types
*/
		BEGIN
		SELECT * FROM [dbo].[QuestionTypes]
		END
GO
/****** Object:  StoredProcedure [dbo].[uspGetAnswer]    Script Date: 2/6/2018 4:55:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspGetAnswer]
	@id int
AS
/*
Created by: David Rodriguez Vazquez
Description: Shows an answer
*/
	BEGIN
	SELECT Ans.AnswerId, Que.Text AS 'Question', Ans.OpenValue, Op.Text AS 'Option' FROM [dbo].[Answers] Ans
	INNER JOIN Questions Que ON Que.QuestionId = Ans.QuestionId
	LEFT JOIN Options Op ON Op.OptionId=Ans.OptionId
	WHERE [AnswerId]=@id
	END
GO
/****** Object:  StoredProcedure [dbo].[uspGetQuestionsAndAnswers]    Script Date: 2/6/2018 4:55:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspGetQuestionsAndAnswers]
AS
/*
Created by: David Rodriguez Vazquez
Description: Shows a question and its answers(s)
*/
	BEGIN
	SELECT Que.QuestionId, Que.Text, Ans.OpenValue, Op.Text AS 'Option' FROM Answers Ans
	INNER JOIN Questions Que ON Que.QuestionId = Ans.QuestionId
	LEFT JOIN Options Op ON Op.OptionId=Ans.OptionId
	END
GO
/****** Object:  StoredProcedure [dbo].[uspGetQuestionsAndOptions]    Script Date: 2/6/2018 4:55:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspGetQuestionsAndOptions]
	@id int
AS
/*
Created by: David Rodriguez Vazquez
Description: Shows a question with its options
*/
	BEGIN
	SELECT Que.QuestionId, Que.Text AS 'Question', Op.Text AS 'Option' FROM QuestionOptions QO
	INNER JOIN Questions Que ON Que.QuestionId=QO.QuestionId
	INNER JOIN Options Op ON Op.OptionId=QO.OptionId
	WHERE Que.QuestionId=@id 
	END
GO
/****** Object:  StoredProcedure [dbo].[uspInsertAnswer]    Script Date: 2/6/2018 4:55:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspInsertAnswer]
	@OpenValue nvarchar(50),
	@OptionId int,
	@QuestionId int
AS
/*
Created by: David Rodriguez Vazquez
Description: Inserts new answer
*/
	BEGIN TRANSACTION;
	BEGIN TRY
		INSERT INTO [Answers] ([QuestionId],[OpenValue],[OptionId])VALUES
		(@QuestionId,@OpenValue,@OptionId)
	END TRY
	BEGIN CATCH
		EXEC usp_GetErrorInfo
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;
	END CATCH

	IF @@TRANCOUNT > 0
			COMMIT TRANSACTION;
GO
/****** Object:  StoredProcedure [dbo].[uspInsertinOption]    Script Date: 2/6/2018 4:55:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspInsertinOption]
	@text nvarchar(50)
AS

/*
Created by: David Rodriguez Vazquez
Description: Inserts new options
*/
		BEGIN TRANSACTION;
		BEGIN TRY
			INSERT INTO dbo.Options([Text]) VALUES
			(@text)
		END TRY
		BEGIN CATCH
			EXEC usp_GetErrorInfo
			IF @@TRANCOUNT > 0 
			ROLLBACK TRANSACTION;
		END CATCH

		IF @@TRANCOUNT > 0
			COMMIT TRANSACTION;
GO
/****** Object:  StoredProcedure [dbo].[uspInsertinQuestionType]    Script Date: 2/6/2018 4:55:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspInsertinQuestionType]
	@text nvarchar(50)
AS
/*
Created by: David Rodriguez Vazquez
Description: Inserts new question types
*/
		BEGIN TRANSACTION;
		BEGIN TRY
			INSERT INTO dbo.QuestionTypes([Description]) VALUES
			(@text)
		END TRY
		BEGIN CATCH
			EXEC usp_GetErrorInfo
			IF @@TRANCOUNT > 0 
				ROLLBACK TRANSACTION;
		END CATCH
			
		IF @@TRANCOUNT > 0
			COMMIT TRANSACTION;
GO
/****** Object:  StoredProcedure [dbo].[uspInsertQuestion]    Script Date: 2/6/2018 4:55:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspInsertQuestion]
	@text nvarchar(50),
	@typeid int
AS
/*
Created by: David Rodriguez Vazquez
Description: Inserts new question
*/
	BEGIN TRANSACTION;
	BEGIN TRY
		INSERT INTO [dbo].[Questions]([Text],[QuestionTypeId])VALUES
		(@text,@typeid)
	END TRY
	BEGIN CATCH
		EXEC usp_GetErrorInfo
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;
	END CATCH

	IF @@TRANCOUNT > 0
			COMMIT TRANSACTION;
GO
/****** Object:  StoredProcedure [dbo].[uspInsertQuestionOption]    Script Date: 2/6/2018 4:55:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspInsertQuestionOption]
	@questionid int,
	@optionid int
AS
/*
Created by: David Rodriguez Vazquez
Description: Inserts question options
*/
	BEGIN TRANSACTION;
	BEGIN TRY
		INSERT INTO [dbo].[QuestionOptions]([QuestionId],[OptionId])VALUES
		(@questionid,@optionid)
	END TRY
	BEGIN CATCH
		EXEC usp_GetErrorInfo
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;
	END CATCH
	
	IF @@TRANCOUNT > 0
			COMMIT TRANSACTION;
GO
/****** Object:  StoredProcedure [dbo].[uspUpdateOptions]    Script Date: 2/6/2018 4:55:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspUpdateOptions]
	@id int,
	@text nvarchar(50)
AS
/*
Created by: David Rodriguez Vazquez
Description: Updates option text
*/
	BEGIN TRANSACTION;
	BEGIN TRY
		UPDATE Options
		SET [Text]=@text
		WHERE [OptionId]=@id
	END TRY
	BEGIN CATCH
		EXEC usp_GetErrorInfo
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;
	END CATCH
	IF @@TRANCOUNT > 0
			COMMIT TRANSACTION;
GO
/****** Object:  StoredProcedure [dbo].[uspUpdateQuestionTypes]    Script Date: 2/6/2018 4:55:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspUpdateQuestionTypes]
	@id int,
	@text nvarchar(50)
AS
/*
Created by: David Rodriguez Vazquez
Description: Updates question types text
*/
	BEGIN TRANSACTION;
	BEGIN TRY 
		UPDATE QuestionTypes
		SET [Description]=@text
		WHERE [QuestionTypeId]=@id
	END TRY
	BEGIN CATCH
		EXEC usp_GetErrorInfo
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;
	END CATCH

	IF @@TRANCOUNT > 0
		COMMIT TRANSACTION;
GO
USE [master]
GO
ALTER DATABASE [SurveyDB] SET  READ_WRITE 
GO
