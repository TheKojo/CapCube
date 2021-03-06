
SELECT
(
SELECT 'System.Collections.Generic.List[CapCubeData.Specter]' as "@Type",
	(
	SELECT 
		   [SpecterID]
		  ,[Name]
		  ,[HP]
		  ,[PP]
		  ,[Attack]
		  ,[Defense]
		  ,[SpAtk]
		  ,[SpDef]
		  ,[Speed]
		  ,[Element1ID]
		  ,[Element2ID]
		  ,[SpriteOffsetX]
		  ,[SpriteOffsetY]
	  FROM [capcube_db].[dbo].[Specter]
	  FOR XML PATH('Item'), type
	)
 FOR XML PATH('Asset'), type
 )
 FOR XML PATH('XnaContent')