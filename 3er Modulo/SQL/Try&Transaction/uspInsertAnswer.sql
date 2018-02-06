USE [SurveyDB]
GO

/****** Object:  StoredProcedure [dbo].[uspInsertAnswer]    Script Date: 1/29/2018 8:03:55 PM ******/
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

