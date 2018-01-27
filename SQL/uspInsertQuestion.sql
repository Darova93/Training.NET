USE [SurveyDB]
GO

/****** Object:  StoredProcedure [dbo].[uspInsertQuestion]    Script Date: 1/26/2018 8:35:28 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspInsertQuestion]
	@text nvarchar(50),
	@typeid int
AS
	BEGIN
	INSERT INTO [dbo].[Questions]([Text],[QuestionTypeId])VALUES
	(@text,@typeid)
	END
GO

