		USE [inventario]
GO

/*FUNCTION
*/

CREATE FUNCTION svfReverseName(@string varchar(100))
RETURNS varchar(100)
AS
-- 
BEGIN
DECLARE @Name varchar(100)
SET @Name = REVERSE(@string)
RETURN @Name
END

SELECT [dbo].[svfReverseName] (Name) as REVERSED, Description
FROM Device
GO

CREATE FUNCTION tvfProductsCostingMoreThan(@cost money)
RETURNS TABLE
AS
--
RETURN
	SELECT Dev.Name, Dev.Description, Si.Price, Si.Quantity
	FROM Device Dev
	INNER JOIN StoreInventory SI ON SI.DeviceId = Dev.DeviceId
	WHERE Price > @cost

SELECT * 
	FROM [dbo].[tvfProductsCostingMoreThan](1000)
WHERE [Name] LIKE '%TV'
GO

/*VIEW
*/

CREATE VIEW [dbo].[vw_DeviceStore]
AS
SELECT	St.Name AS Store, Dev.Name AS Device, Dev.Description, Co.Name AS Color, SI.Price, SI.Quantity
FROM	dbo.Device AS DEV
			INNER JOIN dbo.Color AS Co ON Co.ColorId = Dev.ColorId 
			INNER JOIN dbo.StoreInventory AS SI ON SI.DeviceId = Dev.DeviceId 
			INNER JOIN dbo.Store AS St ON St.StoreId = SI.StoreId
GO

SELECT *
	FROM [inventario].[dbo].[vw_DeviceStore] WHERE Quantity >8


/*TRANSACTION
*/

BEGIN TRANSACTION;

BEGIN TRY
	INSERT INTO Color VALUES ('block','#334455')
	SELECT 1/0;
END TRY
BEGIN CATCH
	EXECUTE usp_GetErrorInfo
       SELECT @@TRANCOUNT as 'Transaction Count', 'Failed, need rollback' as 'Transaction location'
       IF @@TRANCOUNT >0
       ROLLBACK TRANSACTION;
END CATCH;

IF @@TRANCOUNT > 0
	COMMIT TRANSACTION;
GO

/* ERROR
*/

CREATE PROCEDURE [dbo].[usp_GetErrorInfo]
AS
SELECT
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_SEVERITY() AS ErrorSeverity,
	ERROR_MESSAGE() AS 