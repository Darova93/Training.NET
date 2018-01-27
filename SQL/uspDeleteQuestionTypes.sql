USE [SurveyDB]
GO

/****** Object:  StoredProcedure [dbo].[uspDeleteQuestionTypes]    Script Date: 1/26/2018 8:32:43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[uspDeleteQuestionTypes]
	@id int
AS
	BEGIN
	DELETE FROM QuestionTypes
	WHERE [QuestionTypeId]=@id
	END
GO

