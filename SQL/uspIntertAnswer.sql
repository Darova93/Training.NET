USE [SurveyDB]
GO

/****** Object:  StoredProcedure [dbo].[uspInsertAnswer]    Script Date: 1/26/2018 8:34:54 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspInsertAnswer]
	@OpenValue nvarchar(50),
	@OptionId int,
	@QuestionId int
AS
	BEGIN
	INSERT INTO [Answers] ([QuestionId],[OpenValue],[OptionId])VALUES
	(@QuestionId,@OpenValue,@OptionId)
	END
GO

