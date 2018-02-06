USE [SurveyDB]
GO

/****** Object:  StoredProcedure [dbo].[uspUpdateOptions]    Script Date: 1/26/2018 8:35:58 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspUpdateOptions]
	@id int,
	@text nvarchar(50)
AS
	BEGIN
	UPDATE Options
	SET [Text]=@text
	WHERE [OptionId]=@id
	END
GO

