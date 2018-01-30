USE [SurveyDB]
GO

/****** Object:  StoredProcedure [dbo].[uspInsertinOption]    Script Date: 1/29/2018 8:04:08 PM ******/
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

