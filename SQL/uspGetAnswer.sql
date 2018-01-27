USE [SurveyDB]
GO

/****** Object:  StoredProcedure [dbo].[uspGetAnswer]    Script Date: 1/26/2018 8:33:58 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspGetAnswer]
	@id int
AS
	BEGIN
	SELECT Ans.AnswerId, Que.Text AS 'Question', Ans.OpenValue, Op.Text AS 'Option' FROM [dbo].[Answers] Ans
	INNER JOIN Questions Que ON Que.QuestionId = Ans.QuestionId
	LEFT JOIN Options Op ON Op.OptionId=Ans.OptionId
	WHERE [AnswerId]=@id
	END
GO

