USE [SurveyDB]
GO

/****** Object:  StoredProcedure [dbo].[uspGetQuestionsAndAnswers]    Script Date: 1/29/2018 8:03:25 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[uspGetQuestionsAndAnswers]
AS
/*
Created by: David Rodriguez Vazquez
Description: Shows a question and its answers(s)
*/
	BEGIN
	SELECT Que.QuestionId, Que.Text, Ans.OpenValue, Op.Text AS 'Option' FROM Answers Ans
	INNER JOIN Questions Que ON Que.QuestionId = Ans.QuestionId
	LEFT JOIN Options Op ON Op.OptionId=Ans.OptionId
	END
GO

