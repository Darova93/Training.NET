IF OBJECT_ID('tempdb..#Results') IS NOT NULL 
DROP TABLE #Results
GO
CREATE TABLE #Results
 ( 
 Company CHAR(3), 
 StepId TINYINT,
 FieldId TINYINT 
  )
GO
select company, stepid, fieldid from #Results
GO
ALTER TABLE #Results ADD foo VARCHAR(50) NULL
GO
select company, stepid, fieldid, foo from #Results
GO
IF OBJECT_ID('tempdb..#Results') IS NOT NULL DROP TABLE #Results
GO
/*
Table variables (DECLARE @t TABLE) are visible only to the connection that creates it,
 and are deleted when the batch or stored procedure ends.

Local temporary tables (CREATE TABLE #t) are visible only to the connection that creates it,
 and are deleted when the connection is closed.

Global temporary tables (CREATE TABLE ##t) are visible to everyone, 
and are deleted when all connections that have referenced them have closed.

Tempdb permanent tables (USE tempdb CREATE TABLE t) are visible to everyone, 
and are deleted when the server is restarted.
*/
DECLARE @Temp TABLE
		(
		ManufacturerId int,	
		Name VARCHAR(50),
		Address VARCHAR(150)
		);

DECLARE @doc xml 
SET @doc = ( SELECT * FROM Manufacturer FOR XML AUTO, TYPE)
SELECT @doc;
--Get data from XML file
		DECLARE @docHandle INT;
		EXEC sp_xml_preparedocument @docHandle OUTPUT, @doc;
		INSERT INTO
			@Temp 
			(
				ManufacturerId,
				Name,
				Address
			)
			SELECT
				x.ManufacturerID, x.Name, x.address
			FROM
				OPENXML
					(
					@docHandle, N'.'
					)
				WITH 
					(
					ManufacturerId INT '.',
					[Name] VARCHAR(150) '.',
					Address			INT		'.'
					) x 					
EXEC sp_xml_removedocument @docHandle
SELECT * FROM @temp

		