USE [inventario]
GO
/******************************************
A. Finding a row by using a simple equality
*******************************************/
SELECT Name, Description  
FROM Device 
WHERE Name = 'TV' ;  

/******************************************
B. Finding rows that contain a value as part of a string
*******************************************/
SELECT Name, Description  
FROM Device  
WHERE Name LIKE ('%TV%');  

/******************************************
C. Finding rows by using a comparison operator
*******************************************/
SELECT name, description  
FROM Device  
WHERE deviceId  <= 5;  


/******************************************
D. Finding rows that meet any of three conditions
*******************************************/
SELECT name, description  
FROM device  
WHERE DeviceId = 26 OR Name = 'TV' OR Description LIKE '%samsung%';  


/******************************************
E. Finding rows that must meet several conditions
*******************************************/
SELECT name, description  
FROM device  
WHERE DeviceId >20 AND name LIKE '%tab%' AND ColorId = 1;  


/******************************************
F. Finding rows that are in a list of values
*******************************************/
SELECT name, description  
FROM device  
WHERE Name IN ('TV', 'Smartwatch', 'laptop');  

SELECT name, description  
FROM device  
WHERE Name NOT IN ('TV'); 

SELECT name, description  
FROM device  
WHERE Comments IS NULL ; 

/******************************************
G. Finding rows that have a value between two values
*******************************************/
SELECT deviceid,name, description  
FROM device  
WHERE deviceid Between 4 AND 25;  
