USE [SurveyDB]
GO

/****** Object:  StoredProcedure [dbo].[uspUpdateOptions]    Script Date: 1/29/2018 8:04:54 PM ******/
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

