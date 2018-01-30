USE [Inventory]
GO
CREATE PROCEDURE uspGetAllDeviceName 
AS 
/*
Create by: Aurvar
Create Date: 01/26/2018
Description: Returns the name for all the devices in Device table
*/
BEGIN
     SELECT Name FROM [dbo].[Device] 
END
GO
--*******************************************************************************************
EXEC uspGetAllDeviceName 
GO
--or just simply 
uspGetAllDeviceName

SP_HELPTEXT uspGetAllDeviceName
--*******************************************************************************************
USE [Inventory]
GO
CREATE PROCEDURE uspGetDeviceByName 
(
	@Name nvarchar(30) 
)
AS 
/*
Create by: Aurvar
Create Date: 01/26/2018
Description: Returns  all the devices with the name provided
*/
BEGIN
     SELECT * FROM [dbo].[Device]
     WHERE Name = @Name 
END
GO
--*******************************************************************************************
EXEC uspGetDeviceByName @Name = 'TV'
GO
EXEC uspGetDeviceByName 'Laptop'
GO
--*******************************************************************************************
USE [Inventory]
GO
CREATE PROCEDURE uspGetDeviceByDescription 
(
@Description nvarchar(30) 
)
AS 
/*
Create by: Aurvar
Create Date: 01/26/2018
Description: Returns  all the devices with the description provided
*/
     SELECT * FROM [dbo].[Device]
     WHERE Description Like '%'+ @Description +'%'
GO
--*******************************************************************************************
EXEC uspGetDeviceByDescription @Description = 'sung'
GO
EXEC uspGetDeviceByDescription 'ppl'
GO
--*******************************************************************************************
USE [Inventory]
GO
ALTER PROCEDURE uspGetDeviceByDescription 
(
@Description nvarchar(30) = NULL
)
AS 
/*
Create by: Aurvar
Create Date: 01/26/2018
Description: Returns  all the devices with the name provided, if its null it retrieves all
*/
     SELECT * FROM [dbo].[Device]
     WHERE Description = ISNULL(@Description,Description )
GO
--*******************************************************************************************
EXEC uspGetDeviceByDescription @Description = 'Samsung FHD 55'
GO
EXEC uspGetDeviceByDescription
GO
--*******************************************************************************************
USE [Inventory]
GO
CREATE PROCEDURE uspGetDeviceNameColor 
(
@Name nvarchar(30) 
,@Color nvarchar(20) = NULL
)
AS 
/*
Create by: Aurvar
Create Date: 01/26/2018
Description: Returns  all the devices with the name and color provided 
*/
     SELECT * FROM [dbo].[Device] Dev
	 INNER JOIN [dbo].[Color] Co ON Dev.ColorId=Co.ColorId
     WHERE Dev.[Name] Like '%'+ @Name + '%' AND Co.[Name] LIKE '%'+ISNULL(@Color ,Co.[Name])+'%'
GO
--*******************************************************************************************
EXEC uspGetDeviceNameColor 'tv','a'
EXEC uspGetDeviceNameColor @color='a',@name='tv'
EXEC uspGetDeviceNameColor @name='tv', @color='b'

-----------
USE [Inventory]
GO
CREATE PROCEDURE uspGetDeviceColorCount 
(
@Name nvarchar(30) 
,@ColorCount int OUTPUT --  SP OUT
)
AS 
--Comment
BEGIN
     SELECT @ColorCount= Count(Dev.DeviceId) FROM [dbo].[Device] Dev     
	 INNER JOIN [dbo].[Color] Co ON Dev.ColorId=Co.ColorId
     WHERE Dev.[Name] Like '%'+ @Name +'%'
END
GO

DECLARE @Count int
EXEC uspGetDeviceColorCount @name='tv', @colorCount= @count OUTPUT
SELECT @Count 

    SELECT * FROM [dbo].[Device] Dev     
	 INNER JOIN [dbo].[Color] Co ON Dev.ColorId=Co.ColorId
     WHERE Dev.[Name] Like '%'+ 'tv' +'%'


---------------
USE [Inventory]
GO
CREATE PROCEDURE uspTryCatchTest
AS
-- Xplode
BEGIN TRY
    SELECT 1/0
END TRY
BEGIN CATCH
    SELECT ERROR_NUMBER() AS ErrorNumber
     ,ERROR_SEVERITY() AS ErrorSeverity
     ,ERROR_STATE() AS ErrorState
     ,ERROR_PROCEDURE() AS ErrorProcedure
     ,ERROR_LINE() AS ErrorLine
     ,ERROR_MESSAGE() AS ErrorMessage;
END CATCH

EXEC uspTryCatchTest
