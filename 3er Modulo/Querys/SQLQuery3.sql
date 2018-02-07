USE [inventario]
GO

CREATE TABLE [dbo].[Manufacturer](
[ManufacturerId][int] IDENTITY(1,1) NOT NULL,
[Name] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Manufacturer] ADD
[Adress][varchar](50) NOT NULL

ALTER TABLE [dbo].[Manufacturer] ADD
[Identity][varchar](50) NOT NULL

ALTER TABLE [dbo].[Manufacturer] DROP COLUMN
[Identity]

CREATE TABLE [dbo].[Color](
[ColorId][int] IDENTITY(1,1) NOT NULL,
[Name][nvarchar](50) NOT NULL,
[HexValue][nvarchar](7) NOT NULL,
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Store](
[StoreId][int] IDENTITY(1,1) NOT NULL,
[Name][nvarchar](50) NOT NULL,
[Adress][nvarchar](50) NOT NULL,
[Telephone][nvarchar](50) NOT NULL,
) ON [PRIMARY]
GO

INSERT INTO [dbo].Color([Name],[HexValue])VALUES
('White','#FFFFFF'),
('Silver','#C0C0C0'),
('Gray','#808080'),
('Black','#000000')

GO

INSERT INTO [dbo].Store([Name],[Adress],[Telephone]) VALUES
('Walmart','Address5','6461234545'),
('Best Buy','Street6','6461235656'),
('Target','Avenue7','64612347474')
GO

INSERT INTO [dbo].Manufacturer([Name],[Address]) VALUES
('Samsung','Address1'),
('Dell','Street2'),
('Apple','Address3'),
('Acer','Avenue4')
GO

INSERT INTO [dbo].Device([Name],[Description],[ManufacturerId],[ColorId])VALUES
('TV','Samsung FHD 55',1,4),
('SmartTV','Samsung Smart 65',1,1),
('Smartphone','Iphone X',3,3),
('TV','AppleTV',3,3),
('Smartwatch','Samsung watch',1,1),
('Smartwatch','Apple watch',3,3),
('Monitor','Dell 21',2,4),
('Laptop','Alienware Dell',2,2),
('Laptop','Acer laptop',4,4),
('Tablet','Samsung Tab 4',1,1),
('Tablet','Ipad 4',3,1)
GO

INSERT INTO [dbo].StoreInventory([StoreId],[DeviceId],[Price],[Quantity])VALUES
(1,2,10000.50,10),
(1,3,18009.99,21),
(1,4,24999.99,4),
(2,9,19999.00,5),
(2,10,16000.00,6),
(3,6,5000.00,5),
(3,7,9999.00,9)
GO

SELECT TOP 20 [ManufacturerId]
	,[Name]
	,[Address]
FROM [inventario].[dbo].[Manufacturer]

SELECT TOP 20 [StoreId]
	,[Name]
FROM [inventario].[dbo].[Store]

SELECT TOP 20 [ColorId]
	,[Name]
FROM [inventario].[dbo].[Color]

SELECT TOP 20 [DeviceId]
	,[Name]
FROM [inventario].[dbo].[Device]

SELECT TOP 20 [StoreInventoryId]
	,[Quantity]
FROM [inventario].[dbo].[StoreInventory]

INSERT INTO [inventario].[dbo].[Manufacturer] VALUES ('No','a')
UPDATE [Manufacturer] SET Address='AA' WHERE ManufacturerId=5

DELETE FROM Manufacturer WHERE ManufacturerId>4
DELETE FROM Store WHERE StoreId>3
DELETE FROM Color WHERE ColorId>4
DELETE FROM Device WHERE DeviceId>12
DELETE FROM StoreInventory WHERE StoreInventoryId>8

SELECT 9.5 AS Original, CAST(9.5 AS int) AS int,
	CAST(9.5 AS decimal(6,4)) AS decimal;

SELECT 9.5 AS Original, CONVERT(int, 9.5) AS int,
	CONVERT(decimal(6,3),9.5) AS decimal;

SELECT GETDATE()

SELECT CONVERT(VARCHAR,GETDATE(),101) as MMDDYYYY,
		CONVERT(VARCHAR,GETDATE(),111) as YYYYMMDD

DECLARE @myval decimal (5, 2)
SET @myval = 193.57
SELECT CAST(CAST(@myval AS varbinary(20)) AS decimal(10,5));

SELECT name, description, SUBSTRING(name, 1, 2) AS Title,
	CAST(Name AS char(1)) AS [Initial]
FROM Device

SELECT CAST(10.6496 AS int) as trunc1,
	CAST(-10.6496 AS int) as trunc2,
	CAST(10.6496 AS numeric) as round1,
	CAST(-10.6496 AS numeric) as round2,
	CAST(10.6496 AS money) as '$$$';

SELECT CONVERT(XML, '<root><child/></root>')

SELECT Dev.Name as Type, Dev.Description, Co.Name as Color, Man.Name as Manufacturer, Sto.Name as Store, StI.Price, StI.Quantity
FROM Device Dev
INNER JOIN StoreInventory StI ON Dev.DeviceId=StI.DeviceId
INNER JOIN Manufacturer Man ON Man.ManufacturerId=Dev.ManufacturerId
INNER JOIN Store Sto ON Sto.StoreId=StI.StoreId
INNER JOIN Color Co ON Co.ColorId=Dev.ColorId

SELECT Inv.StoreId, Dev.Name, Inv.Price, Inv.Quantity
FROM Device Dev
LEFT JOIN StoreInventory Inv ON Inv.DeviceId=Dev.DeviceId

SELECT Inv.StoreId, Dev.Name, Inv.Price, Inv.Quantity
FROM Device Dev
RIGHT JOIN StoreInventory Inv ON Inv.DeviceId=Dev.DeviceId

SELECT Dev.Name, Dev.Description, Co.Name, Co. HexValue From Device Dev
FULL JOIN Color Co ON Dev.ColorId=Co.ColorId
WHERE Dev.ColorId IS NULL

SELECT Dev.Name, Dev.Description, Co.Name, Co.HexValue From Device Dev
RIGHT JOIN Color Co ON Dev.ColorId=Co.ColorId

SELECT Sto.Name as Store, Dev.Name as Device, Dev.Description, StoI.Price
FROM Device Dev
JOIN StoreInventory StoI ON Dev.DeviceId=StoI.DeviceId
JOIN Store Sto ON Sto.StoreId=StoI.StoreId
WHERE StoI.Price>=10000
ORDER BY StoI.Price DESC

SELECT Dev.Name, Dev.Description, Inv.Price
FROM Device Dev
LEFT JOIN StoreInventory Inv ON Dev.DeviceId=Inv.DeviceId
WHERE Dev.Name LIKE '%TV' AND Inv.Price IS NULL

INSERT INTO [dbo].[Device]([Name],[Description],[ManufacturerId])VALUES
('Glass','Tempered Glass',1)
GO

SELECT * FROM Device

SELECT Dev.Name, Dev.Description
FROM Device Dev
LEFT JOIN Color Co ON Dev.ColorId=Co.ColorId
WHERE Dev.ColorId IS NULL

CREATE TABLE [dbo].[Company](
	[CompanyID][int] IDENTITY(1,1) NOT NULL,
	[Name][nvarchar](50) NOT NULL,
	[Address][nvarchar](50) NOT NULL,
	[ParentID][int]) 
	ON [PRIMARY]
	GO

INSERT INTO [dbo].[Company]([Name],[Adress],[ParentID]) VALUES
('Samsung','Korea1',NULL),
('Samsung USA','USA1',1),
('Samsung MEX','Mex1',1),
('Apple','USA2',NULL),
('Apple MEX','Mex2',4)
GO

SELECT Co.CompanyID, Co.Name, Co.Address, Pa.Name
FROM Company Co
INNER JOIN Company Pa ON Pa.CompanyID=Co.ParentID

SELECT Co.CompanyID, Co.Name, Co.Address, Pa.Name
FROM Company Co
LEFT JOIN Company Pa ON Pa.CompanyID=Co.ParentID

SELECT Pa.CompanyID, Pa.Name, Pa.Address, Co.Name AS Son
FROM Company Co
JOIN Company Pa ON Pa.CompanyID=Co.ParentID
