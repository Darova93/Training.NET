USE [SurveyDB]
GO

/****** Object:  StoredProcedure [dbo].[uspGetQuestionsAndOptions]    Script Date: 1/26/2018 8:39:42 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspGetQuestionsAndOptions]
	@id int
AS
	BEGIN
	SELECT Que.QuestionId, Que.Text AS 'Question', Op.Text AS 'Option' FROM QuestionOptions QO
	INNER JOIN Questions Que ON Que.QuestionId=QO.QuestionId
	INNER JOIN Options Op ON Op.OptionId=QO.OptionId
	WHERE Que.QuestionId=@id 
	END
GO

