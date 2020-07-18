CREATE TABLE [dbo].[Projects]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(255) NOT NULL, 
    [Description] NVARCHAR(255) NOT NULL, 
    [IniPath] NVARCHAR(255) NOT NULL, 
    [DatabaseType] NVARCHAR(50) NOT NULL,
    [SiteDatabase] NVARCHAR(255) NOT NULL, 
    [PlantDatabase] NVARCHAR(255) NOT NULL, 
    [Port] INT NOT NULL
)
