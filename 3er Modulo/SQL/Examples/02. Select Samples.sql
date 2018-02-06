use [inventario]
/**
SELECT Samples
*/

/***********************************************************
 A. Using SELECT to retrieve rows and columns
*************************************************************/

--This section shows three code examples. This first code example returns all rows (no WHERE clause is specified) and all columns (using the *) from the Device table.
SELECT *  
FROM Device  
ORDER BY Name;  

--This next example using table aliasing to achieve the same result.
SELECT d.*  
FROM Device AS d  
ORDER BY Name;  

--This example returns all rows (no WHERE clause is specified) and a subset of the columns from the Device table. The third column heading is renamed.
SELECT Name, Description, Comments AS 'Always empty'  
FROM Device   
ORDER BY Name;  

--This example returns only the rows for DimEmployee that have an EndDate that is not NULL and a MaritalStatus of ‘M’ (married).
SELECT Name, Description, Comments AS 'Always empty'  
FROM Device   
WHERE ColorId IS NOT NULL   
AND ManufacturerId = 1  
ORDER BY Name;  

/***********************************************************
B. Using SELECT with column headings and calculations
*************************************************************/

--The following example returns all rows from the DimEmployee table, and calculates the gross pay for each employee based on their BaseRate and a 40-hour work week.
SELECT StoreId, DeviceId, Price, Price*0.16 AS TAX  
FROM StoreInventory  
ORDER BY StoreInventoryId;  

/***********************************************************
C. Using DISTINCT with SELECT
*************************************************************/

--The following example uses DISTINCT to generate a list of all unique titles in the DimEmployee table.
SELECT DISTINCT Name  
FROM Device  
ORDER BY Name;  

/***********************************************************
D. Using GROUP BY
*************************************************************/

--The following example finds the total amount for all sales on each day.
SELECT StoreId, SUM(Price) AS TotalWealth  
FROM StoreInventory  
GROUP BY StoreId  
ORDER BY StoreId;  
SELECT * FROM StoreInventory
--Because of the GROUP BY clause, only one row containing the sum of all prices is returned for each store.

/***********************************************************
E. Using GROUP BY with multiple groups
*************************************************************/

--The following example finds the average price and the sum of quantities for each store, grouped by order store and device.
SELECT StoreId, DeviceId, AVG(Price) AS AvgSales, SUM(Quantity) AS TotalWealth  
FROM StoreInventory  
GROUP BY StoreId, DeviceId  
ORDER BY StoreId;   
SELECT * FROM StoreInventory

/***********************************************************
F. Using GROUP BY and WHERE
*************************************************************/

--The following example puts the results into groups after retrieving only the rows with store greater than 1.
SELECT StoreID, SUM(Price) AS TotalSales  
FROM StoreInventory  
WHERE StoreId > 1  
GROUP BY StoreId  
ORDER BY StoreId; 
SELECT * FROM StoreInventory 

/***********************************************************
G. Using GROUP BY with an expression
*************************************************************/

--The following example groups by an expression. You can group by an expression if the expression does not include aggregate functions.
SELECT SUM(Price) AS TotalWealth  
FROM StoreInventory  
GROUP BY (Quantity * 10); 
SELECT * FROM StoreInventory

/***********************************************************
H. Using GROUP BY with ORDER BY
*************************************************************/

--The following example finds the sum of prices per store, and orders by the store.
SELECT StoreId, SUM(Price) AS TotalWealth   
FROM StoreInventory  
GROUP BY StoreId  
ORDER BY StoreId DESC;  
SELECT * FROM StoreInventory

/***********************************************************
I. Using the HAVING clause
*************************************************************/

--This query uses the HAVING clause to restrict results.
SELECT StoreId, SUM(price) AS TotalSales  
FROM StoreInventory  
GROUP BY StoreId  
HAVING SUM(price) > 20000  
ORDER BY StoreId;  
SELECT * FROM StoreInventory