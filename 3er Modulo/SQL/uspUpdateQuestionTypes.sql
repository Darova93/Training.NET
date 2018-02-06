USE [SurveyDB]
GO

/****** Object:  StoredProcedure [dbo].[uspUpdateQuestionTypes]    Script Date: 1/26/2018 8:36:09 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspUpdateQuestionTypes]
	@id int,
	@text nvarchar(50)
AS
	BEGIN
	UPDATE QuestionTypes
	SET [Description]=@text
	WHERE [QuestionTypeId]=@id
	END
GO

