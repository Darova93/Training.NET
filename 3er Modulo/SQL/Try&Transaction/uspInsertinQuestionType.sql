USE [SurveyDB]
GO

/****** Object:  StoredProcedure [dbo].[uspInsertinQuestionType]    Script Date: 1/29/2018 8:04:21 PM ******/
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

