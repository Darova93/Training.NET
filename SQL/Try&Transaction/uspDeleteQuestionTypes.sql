USE [SurveyDB]
GO

/****** Object:  StoredProcedure [dbo].[uspDeleteQuestionTypes]    Script Date: 1/29/2018 8:02:21 PM ******/
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

