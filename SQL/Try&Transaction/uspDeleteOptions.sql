USE [SurveyDB]
GO

/****** Object:  StoredProcedure [dbo].[uspDeleteOptions]    Script Date: 1/29/2018 8:02:00 PM ******/
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

