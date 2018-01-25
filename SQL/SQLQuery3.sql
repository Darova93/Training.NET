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

SELECT *
FROM Device
ORDER BY Name ASC

SELECT .d*
