USE SurveySystemDb
Go

CREATE VIEW [dbo].vw_SurveyAnswers
AS
	SELECT Ans.SurveyId, Ans.[QuestionId], Opt.[Value] FROM [dbo].Answers Ans
	INNER JOIN [dbo].Options Opt ON Opt.Id = Ans.OptionId
GO

ALTER PROCEDURE [dbo].usp_SurveyReport
(
	@surveyId INT
)
AS
	SELECT Que.[Text] AS "Question",
	(SELECT AVG([Value]) FROM vw_SurveyAnswers SurAns WHERE SurAns.QuestionId = SurQu.Question_Id AND SurAns.SurveyId = @surveyId) AS Average
	FROM SurveyQuestions SurQu
	INNER JOIN Questions Que ON Que.Id = SurQu.Question_Id
	WHERE SurQu.Survey_Id=@surveyId
GO
