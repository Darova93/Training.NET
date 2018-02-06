CREATE FUNCTION svfReverseName(@string varchar(100)) 
RETURNS varchar(100) 
AS 
BEGIN 
DECLARE @Name varchar(100) 
SET @Name = REVERSE(@string) 
RETURN @Name
END


--SELECT [dbo].[ReverseName]('Josue') GO