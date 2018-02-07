CREATE DATABASE [SurveyDB]

USE [SurveyDB]
GO

CREATE TABLE [dbo].[Questions](
	[QuestionId][int]IDENTITY (1,1) NOT NULL,
	[Text][nvarchar](50) NOT NULL,
	[QuestionTypeId][int] NOT NULL
	) ON [PRIMARY]
	GO

	
CREATE TABLE [dbo].[QuestionTypes](
	[QuestionTypeId][int]IDENTITY (1,1) NOT NULL,
	[Description][nvarchar](50) NOT NULL
	) ON [PRIMARY]
	GO


CREATE TABLE [dbo].[Options](
	[OptionId][int]IDENTITY (1,1) NOT NULL,
	[Text][nvarchar](50) NOT NULL,
	) ON [PRIMARY]
	GO
	
CREATE TABLE [dbo].[QuestionOptions](
	[QuestionOptionId][int]IDENTITY (1,1) NOT NULL,
	[OptionId][int] NOT NULL,
	[QuestionId][int] NOT NULL
	) ON [PRIMARY]
	GO

CREATE TABLE [dbo].[Answers](
	[AnswerId][int]IDENTITY (1,1) NOT NULL,
	[QuestionId][int] NOT NULL,
	[OpenValue][nvarchar](50),
	[OptionId][int] NOT NULL
	) ON [PRIMARY]
	GO

--------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------

USE [SurveyDB]
GO

ALTER PROCEDURE uspInsertinOption
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

ALTER PROCEDURE uspInsertinQuestionType
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

ALTER PROCEDURE uspGetAllOptions
AS
/*
Created by: David Rodriguez Vazquez
Description: Shows all options
*/
		BEGIN
		SELECT * FROM [dbo].[Options]
		END
GO

ALTER PROCEDURE uspGetAllQuestionTypes
AS
/*
Created by: David Rodriguez Vazquez
Description: Shows all question types
*/
		BEGIN
		SELECT * FROM [dbo].[QuestionTypes]
		END
GO

ALTER PROCEDURE uspUpdateOptions
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

ALTER PROCEDURE uspUpdateQuestionTypes
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

ALTER PROCEDURE uspDeleteOptions
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

ALTER PROCEDURE uspDeleteQuestionTypes
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

ALTER PROCEDURE uspInsertQuestion
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

ALTER PROCEDURE uspInsertQuestionOption
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

ALTER PROCEDURE uspGetQuestionsAndOptions
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

ALTER PROCEDURE uspInsertAnswer
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

ALTER PROCEDURE uspGetAnswer
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

ALTER PROCEDURE uspGetQuestionsAndAnswers
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

EXEC uspInsertinOption @text='Twitter'
EXEC uspInsertinQuestionType @text='Open'
EXEC uspGetAllOptions
EXEC uspGetAllQuestionTypes
EXEC uspUpdateOptions @id=2, @text='Yes'
EXEC uspUpdateQuestionTypes @id=1, @text='Single'
EXEC uspDeleteOptions @id=16
EXEC uspDeleteQuestionTypes @id=1

EXEC uspInsertQuestion @text='What are you doing', @typeid=3
EXEC uspInsertQuestionOption @questionid=4, @optionid=7
EXEC uspGetQuestionsAndOptions @id=2
EXEC uspInsertAnswer @OpenValue=NULL, @OptionId=2, @QuestionId=4
EXEC uspGetAnswer @id=5
EXEC uspGetQuestionsAndAnswers

SELECT * FROM QuestionOptions
SELECT * FROM Questions
SELECT * FROM Answers

