CREATE TABLE [dbo].[BookSource]
(
  [BookSourceId] INT NOT NULL PRIMARY KEY IDENTITY, 
  [Source] NVARCHAR(20) NOT NULL, 
  [Url] NVARCHAR(200) NULL, 
  [Key] NVARCHAR(50) NULL, 
  [Password] NVARCHAR(50) NULL, 
  [LastModifiedDate] DATETIME NOT NULL DEFAULT getdate(), 
)
