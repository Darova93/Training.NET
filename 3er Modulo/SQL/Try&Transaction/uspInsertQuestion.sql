USE [SurveyDB]
GO

/****** Object:  StoredProcedure [dbo].[uspInsertQuestion]    Script Date: 1/29/2018 8:04:32 PM ******/
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

