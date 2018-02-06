USE [Inventory]
GO

/****** Object:  View [dbo].[vw_DeviceStore]    Script Date: 1/28/2018 11:14:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vw_DeviceStore]
AS
SELECT        St.Name AS Store, Dev.Name AS Device, Dev.Description, Co.Name AS Color, SI.Price, SI.Quantity
FROM            dbo.Device AS Dev INNER JOIN
                         dbo.Color AS Co ON Co.ColorId = Dev.ColorId INNER JOIN
                         dbo.StoreInventory AS SI ON SI.DeviceId = Dev.DeviceId INNER JOIN
                         dbo.Store AS St ON St.StoreId = SI.StoreId
GO



