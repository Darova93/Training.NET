USE [SurveyDB]
GO

/****** Object:  StoredProcedure [dbo].[uspInsertQuestionOption]    Script Date: 1/29/2018 8:04:45 PM ******/
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

