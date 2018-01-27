USE [SurveyDB]
GO

/****** Object:  StoredProcedure [dbo].[uspGetAllQuestionTypes]    Script Date: 1/26/2018 8:33:46 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspGetAllQuestionTypes]
AS
		BEGIN
		SELECT * FROM [dbo].[QuestionTypes]
		END
GO

