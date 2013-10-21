CREATE TABLE [dbo].[ReaderNotes]
(
  [ReaderNoteId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [BookId] INT NOT NULL, 
    [ReaderId] INT NOT NULL, 
    [Rating] INT NOT NULL DEFAULT 0, 
    [AudienceId] INT NOT NULL, 
    [Note] NVARCHAR(MAX) NOT NULL, 
    [Notify] BIT NOT NULL DEFAULT 0, 
    [DateNotified] DATETIME NULL, 
    [EmailAddress] NVARCHAR(100) NULL,
    [LastModifiedDate] DATETIME NOT NULL DEFAULT getdate(), 
    CONSTRAINT [FK_ReaderNote_Book] FOREIGN KEY ([BookId]) REFERENCES [Book]([BookId]), 
    CONSTRAINT [FK_ReaderNote_UserProfile] FOREIGN KEY ([ReaderId]) REFERENCES [UserProfile]([UserId]), 
    CONSTRAINT [FK_ReaderNote_Audience] FOREIGN KEY ([AudienceId]) REFERENCES [Audience]([AudienceId])
)
