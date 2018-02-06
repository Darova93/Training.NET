CREATE FUNCTION ProductsCostingMoreThan(@cost money)
RETURNS TABLE
AS
RETURN
    SELECT Dev.Name,Dev.Description, Si.Price, Si.Quantity
    FROM Device Dev
	INNER JOIN StoreInventory SI ON SI.DeviceId = Dev.DeviceId
    WHERE Price > @cost