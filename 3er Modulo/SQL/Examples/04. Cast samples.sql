/*

*/
SELECT 9.5 AS Original, CAST(9.5 AS int) AS int, 
    CAST(9.5 AS decimal(6,4)) AS decimal;
SELECT 9.5 AS Original, CONVERT(int, 9.5) AS int, 
    CONVERT(decimal(6,4), 9.5) AS decimal;
/*
CAST is part of the ANSI-SQL specification; whereas, CONVERT is not.  In fact, CONVERT is SQL implementation specific.
CONVERT differences lie in that it accepts an optional style parameter which is used for formatting.
For example, when converting a DateTime datatype to Varchar, you can specify the resulting date’s format, such as YYYY/MM/DD or MM/DD/YYYY.
*/
SELECT CONVERT(VARCHAR,GETDATE(),101) as MMDDYYYY,
       CONVERT(VARCHAR,GETDATE(),111) as YYYYMMDD

	   --round trip conversion
DECLARE @myval decimal (5, 2);  
SET @myval = 193.57;  
SELECT CAST(CAST(@myval AS varbinary(20)) AS decimal(10,5));  
-- Or, using CONVERT  
SELECT CONVERT(decimal(10,5), CONVERT(varbinary(20), @myval));  

-- Subsets of strings
SELECT name, description, SUBSTRING(name, 1, 2) AS Title,
    CAST(name AS char(1)) AS [Initial]  
FROM Device

-- Values than can be truncated
SELECT  CAST(10.6496 AS int) as trunc1,
         CAST(-10.6496 AS int) as trunc2,
         CAST(10.6496 AS numeric) as round1,
         CAST(-10.6496 AS numeric) as round2,
		  CAST(10.3496847 AS money) as '$$$';
 
 --Using CAST with arithmetic operators
 SELECT 1000 as salary, CAST(ROUND(1000*1.16, 0) AS int) AS NewSalary  

 --Using CAST to concatenate
 SELECT 'The list price is ' + CAST(Price AS varchar(12)) AS ListPrice  
FROM StoreInventory  
WHERE Price BETWEEN 350.00 AND 10000.00;  

--Using CAST to produce more readable text
SELECT DISTINCT CAST(description AS char(10)) AS ShortDescription, description  
FROM dbo.Device  

--Using CAST with the LIKE clause
SELECT *
FROM Device
WHERE CAST(CAST(ColorId AS int) AS char(20)) LIKE '2%';  
GO  

--Using CONVERT or CAST with typed XML
SELECT CONVERT(XML, '<root><child/></root>')
SELECT CONVERT(XML, '<root>          <child/>         </root>', 1)
SELECT CAST('<Name><FName>Carol</FName><LName>Elliot</LName></Name>'  AS XML)

--dates & time
SELECT   
   GETDATE() AS UnconvertedDateTime,  
   CAST(GETDATE() AS nvarchar(30)) AS UsingCast,  
   CONVERT(nvarchar(30), GETDATE(), 126) AS UsingConvertTo_ISO8601  ;  

   DECLARE @d1 date, @t1 time, @dt1 datetime;  
SET @d1 = GETDATE();  
SET @t1 = GETDATE();  
SET @dt1 = GETDATE();  
SET @d1 = GETDATE();  
-- When converting date to datetime the minutes portion becomes zero.  
SELECT @d1 AS [date], CAST (@d1 AS datetime) AS [date as datetime];  
-- When converting time to datetime the date portion becomes zero   
-- which converts to January 1, 1900.  
SELECT @t1 AS [time], CAST (@t1 AS datetime) AS [time as datetime];  
-- When converting datetime to date or time non-applicable portion is dropped.  
SELECT @dt1 AS [datetime], CAST (@dt1 AS date) AS [datetime as date], 
   CAST (@dt1 AS time) AS [datetime as time];  
GO  
-- What is the difference ?
SELECT   
   '2018-01-25T15:50:59.997' AS UnconvertedText,  
   CAST('2018-01-25T15:50:59.997' AS datetime) AS UsingCast,  
   CONVERT(datetime, '2018-01-25T15:50:59.997', 126) AS UsingConvertFrom_ISO8601 ;  
GO  

--Convert the binary value 0x4E616d65 to a character value. 
SELECT CONVERT(binary(8), 'Name', 0) AS [Style 0, character to binary];  
SELECT CONVERT(char(8), 0x4E616d65, 0) AS [Style 0, binary to character];  