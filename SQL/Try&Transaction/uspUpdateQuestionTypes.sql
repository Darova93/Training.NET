USE [SurveyDB]
GO

/****** Object:  StoredProcedure [dbo].[uspUpdateQuestionTypes]    Script Date: 1/29/2018 8:05:04 PM ******/
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

