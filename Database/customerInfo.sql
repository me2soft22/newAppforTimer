CREATE TABLE [dbo].[Customer]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [PhoneNumber] NCHAR(10) NOT NULL, 
    [Name] NCHAR(50) NOT NULL, 
    [NoOfVisit] INT NOT NULL, 
    [LastVisit] DATETIME NOT NULL, 
    CONSTRAINT [PK_Table] PRIMARY KEY ([Id]), 
    CONSTRAINT [PK_Table] PRIMARY KEY ([Id])
)
