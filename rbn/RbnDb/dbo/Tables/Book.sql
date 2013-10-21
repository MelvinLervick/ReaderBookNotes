CREATE TABLE [dbo].[Book]
(
  [BookId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ISBN] NVARCHAR(32) NULL, 
    [Title] NVARCHAR(50) NOT NULL, 
    [AuthorId] INT NULL, 
    [AudienceId] INT NULL, 
    [Rating] INT NOT NULL DEFAULT 0, 
    [LastModifiedDate] DATETIME NOT NULL DEFAULT getdate(), 
    CONSTRAINT [FK_Book_Audience] FOREIGN KEY ([AudienceId]) REFERENCES [Audience]([AudienceId]), 
    CONSTRAINT [FK_Book_Author] FOREIGN KEY ([AuthorId]) REFERENCES [Author]([AuthorId])
)
