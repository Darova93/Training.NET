-- CRTL + SHIFT + R = refresh intellisense
/********************
INNER JOIN  = JOIN
*********************/
SELECT Dev.Name, Dev.Description, Co.Name, Co.HexValue From Device Dev
INNER JOIN Color Co ON Dev.ColorId = Co.ColorId

SELECT Inv.StoreId, Dev.Name, Inv.Price, Inv.Quantity FROM StoreInventory Inv
INNER JOIN Device Dev ON Inv.DeviceId=Dev.DeviceId

/****************************
LEFT OUTER JOIN  = LEFT JOIN
****************************/
SELECT Inv.StoreId, Dev.Name, Inv.Price, Inv.Quantity FROM Device Dev
LEFT JOIN  StoreInventory Inv ON Inv.DeviceId=Dev.DeviceId

SELECT * FROM StoreInventory

--> Changing the order we get a RIGHT JOIN !!!
SELECT Inv.StoreId, Dev.Name, Inv.Price, Inv.Quantity FROM StoreInventory Inv
LEFT JOIN Device Dev ON Inv.DeviceId=Dev.DeviceId

/*******************************
RIGHT OUTER JOIN = RIGHT JOIN
********************************/
SELECT Inv.StoreId, Dev.Name, Inv.Price, Inv.Quantity FROM Device Dev
RIGHT JOIN  StoreInventory Inv ON Inv.DeviceId=Dev.DeviceId

/*******************************
FULL OUTER JOIN = FULL JOIN
********************************/
-- INSERT INTO COLOR VALUES ('PALEVIOLETRED','#DB7093')
SELECT Dev.Name, Dev.Description, Co.Name, Co.HexValue From Device Dev
FULL JOIN Color Co ON Dev.ColorId = Co.ColorId

/*******************************
All the colors that device doesn't have
********************************/
SELECT Dev.Name, Dev.Description, Co.Name, Co.HexValue From Color Co
LEFT JOIN Device Dev ON Dev.ColorId = Co.ColorId
WHERE Dev.ColorId IS NULL

SELECT Dev.Name, Dev.Description, Co.Name, Co.HexValue From Device Dev
RIGHT JOIN Color Co ON Dev.ColorId = Co.ColorId
WHERE Dev.ColorId IS NULL

/******************************
 NOT INNER JOIN
******************************/
--ALTER TABLE [Device] ALTER COLUMN [ColorId] INT NULL
--INSERT INTO Device VALUES ('Tempered Glass', 'Generic Tempered Glass',1, NULL, 'I have a comment')
SELECT Dev.Name, Dev.Description, Co.Name, Co.HexValue From Device Dev
FULL JOIN Color Co ON Dev.ColorId = Co.ColorId
WHERE Co.ColorId IS NULL OR Dev.ColorId is NULL

/********************************
 CROSS JOIN
********************************/
SELECT Dev.Name, Dev.Description, Co.Name, Co.HexValue From Device Dev
CROSS JOIN Color Co-- ON Dev.ColorId = Co.ColorId
--WHERE Co.ColorId IS NULL OR Dev.ColorId is NULL  --Uncomment me plz

/********************************
 SELF JOIN
 ********************************/
SELECT Co.CompanyId, Co.Name, Co.Address, Par.CompanyId,Par.Name FROM Company Co
 JOIN Company Par ON Co.ParentId = Par.CompanyId

 SELECT Co.CompanyId, Co.Name, Co.Address, Par.CompanyId,Par.Name FROM Company Co
 LEFT JOIN Company Par ON Co.ParentId = Par.CompanyId

 SELECT Co.CompanyId, Co.Name, Co.Address, Par.CompanyId,Par.Name FROM Company Co
 RIGHT JOIN Company Par ON Co.ParentId = Par.CompanyId

 SELECT Co.CompanyId, Co.Name, Co.Address, Par.CompanyId,Par.Name FROM Company Co
 FULL JOIN Company Par ON Co.ParentId = Par.CompanyId

 SELECT Co.CompanyId, Co.Name, Co.Address, Par.CompanyId,Par.Name FROM Company Co
 CROSS JOIN Company Par


 SELECT * FROM Device Dev
 JOIN StoreInventory Inv ON Dev.DeviceId = Inv.DeviceId
 WHERE Inv.Price >10000
 ORDER BY Inv.PRICE DESC

 SELECT St.Name as 'Store', Dev.Name as 'Device', Dev.Description, Inv.Price, Inv.Quantity    
 FROM Device Dev
 JOIN StoreInventory Inv ON Dev.DeviceId = Inv.DeviceId
 JOIN Store St ON St.StoreId = Inv.StoreId
 WHERE Inv.Price >10000
  ORDER BY Inv.PRICE DESC

  SELECT * FROM Device DEV
  LEFT JOIN StoreInventory INV ON INV.DeviceId= DEV.DeviceId
  --LEFT JOIN Store st ON St.StoreId = INV.StoreId
  WHERE dev.Name like '%TV%'  

   SELECT * FROM Device Dev
 LEFT JOIN StoreInventory Inv ON Dev.DeviceId = Inv.DeviceId
 WHERE   Dev.Name like '%TV%'

 SELECT * FROM Device Dev
 LEFT JOIN Color Co ON Dev.ColorId = Co.ColorId
 WHERE DEV.ColorId IS NULL 

 SELECT Co.CompanyId, Co.Name, Co.Address, Par.CompanyId,Par.Name FROM Company Co
 JOIN Company Par ON Co.ParentId = Par.CompanyId

 SELECT Co.CompanyId, Co.Name, Co.Address, Par.CompanyId,Par.Name FROM Company Co
 LEFT JOIN Company Par ON Co.ParentId = Par.CompanyId

 SELECT Par.CompanyId,Par.Name,Co.CompanyId, Co.Name, Co.Address FROM Company Par
 LEFT JOIN Company Co ON Co.ParentId = Par.CompanyId
 WHERE Co.CompanyID IS NOT NULL



