SELECT       
 CASE 
 WHEN  St.[Name] IS NULL THEN 'NO store'
 ELSE St.[Name]
 END  AS Store,  
 Dev.Name AS Device, Dev.Description, 
 CASE ISNULL(Co.Name,'')
 WHEN  '' THEN 'NAN'
 ELSE Co.Name 
 END  AS Color, 
 CASE ISNULL(SI.Price,0)
 WHEN  0 THEN 10
 ELSE SI.Price 
 END  AS Price,
  SI.Quantity
FROM            dbo.Device AS Dev 
LEFT JOIN dbo.Color AS Co ON Co.ColorId = Dev.ColorId 
LEFT JOIN dbo.StoreInventory AS SI ON SI.DeviceId = Dev.DeviceId 
LEFT JOIN dbo.Store AS St ON St.StoreId = SI.StoreId