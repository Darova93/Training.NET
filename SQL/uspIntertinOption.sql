USE [SurveyDB]
GO

/****** Object:  StoredProcedure [dbo].[uspInsertinOption]    Script Date: 1/26/2018 8:35:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[uspInsertinOption]
	@text nvarchar(50)
AS
		BEGIN
		INSERT INTO dbo.Options([Text]) VALUES
		(@text)
		END
GO

