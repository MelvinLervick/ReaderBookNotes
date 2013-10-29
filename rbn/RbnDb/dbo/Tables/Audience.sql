CREATE TABLE [dbo].[Audience]
(
  [AudienceId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NCHAR(15) NOT NULL, 
    [Enabled] BIT NOT NULL DEFAULT 1
)
