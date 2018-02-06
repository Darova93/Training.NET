USE [SurveyDB]
GO

/****** Object:  StoredProcedure [dbo].[uspInsertQuestionOption]    Script Date: 1/26/2018 8:35:39 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[uspInsertQuestionOption]
	@questionid int,
	@optionid int
AS
	BEGIN
	INSERT INTO [dbo].[QuestionOptions]([QuestionId],[OptionId])VALUES
	(@questionid,@optionid)
	END
GO

