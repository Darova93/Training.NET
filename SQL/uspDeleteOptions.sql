USE [SurveyDB]
GO

/****** Object:  StoredProcedure [dbo].[uspDeleteOptions]    Script Date: 1/26/2018 8:33:17 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspDeleteOptions]
	@id int
AS
	BEGIN
	DELETE FROM Options
	WHERE [OptionId]=@id
	END
GO

