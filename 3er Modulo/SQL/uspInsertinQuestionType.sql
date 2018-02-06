USE [SurveyDB]
GO

/****** Object:  StoredProcedure [dbo].[uspInsertinQuestionType]    Script Date: 1/26/2018 8:35:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspInsertinQuestionType]
	@text nvarchar(50)
AS
		BEGIN
		INSERT INTO dbo.QuestionTypes([Description]) VALUES
		(@text)
		END
GO

