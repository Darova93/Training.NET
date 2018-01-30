USE [SurveyDB]
GO

/****** Object:  StoredProcedure [dbo].[uspGetAllOptions]    Script Date: 1/29/2018 8:02:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[uspGetAllOptions]
AS
/*
Created by: David Rodriguez Vazquez
Description: Shows all options
*/
		BEGIN
		SELECT * FROM [dbo].[Options]
		END
GO

