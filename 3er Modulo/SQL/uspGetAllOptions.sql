USE [SurveyDB]
GO

/****** Object:  StoredProcedure [dbo].[uspGetAllOptions]    Script Date: 1/26/2018 8:33:32 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspGetAllOptions]
AS
		BEGIN
		SELECT * FROM [dbo].[Options]
		END
GO

