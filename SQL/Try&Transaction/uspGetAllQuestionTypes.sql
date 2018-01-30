USE [SurveyDB]
GO

/****** Object:  StoredProcedure [dbo].[uspGetAllQuestionTypes]    Script Date: 1/29/2018 8:02:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[uspGetAllQuestionTypes]
AS
/*
Created by: David Rodriguez Vazquez
Description: Shows all question types
*/
		BEGIN
		SELECT * FROM [dbo].[QuestionTypes]
		END
GO

