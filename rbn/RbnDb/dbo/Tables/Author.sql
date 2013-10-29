CREATE TABLE [dbo].[Author]
(
  [AuthorId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NULL, 
    [MiddleName] NVARCHAR(30) NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Rating] INT NOT NULL DEFAULT 0, 
    [LastModifiedDate] DATETIME NOT NULL DEFAULT getdate(), 
    [Enabled] BIT NOT NULL DEFAULT 1
)