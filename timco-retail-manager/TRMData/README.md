# TRMData

New SQL Server Database Project

- Create Directory PublishLocations
- Create Directory dbo
- Create Directory dbo/Tables
- Create Directory dbo/views
- Create Directory dbo/Stored Procedures
- Right click on the project --> Publish --> Edit 
	- Brose --> Select SQL Local DB
	- Databse Name: TRMData
	- Save profile as (Save it in PublishLocations as TRMData.publish.xml)
	- Click Publish to create the database in the local SQL Server

## Create a User table in the Tables directory

```sql
CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [AuthUserId] NVARCHAR(128) NOT NULL, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [EmailAddress] NVARCHAR(256) NOT NULL, 
    [CreatedDate] DATETIME2 NOT NULL DEFAULT getutcdate() 
)
```

```sql
CREATE TABLE [dbo].[User]
(
    [Id] NVARCHAR(128) NOT NULL, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [EmailAddress] NVARCHAR(256) NOT NULL, 
    [CreatedDate] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    CONSTRAINT [PK_User] PRIMARY KEY ([Id]) 
)

```

## Create a Sale table in the Tables directory
