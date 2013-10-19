CREATE TABLE [dbo].[UserAccount]
(
	[UserId] INT NOT NULL PRIMARY KEY UNIQUE, 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [EmailAddress] NVARCHAR(100) NULL, 
    [Rating] INT NULL DEFAULT 0, 
    [NeedsApproval] BIT NULL DEFAULT 0, 
    [AccountLocked] BIT NULL DEFAULT 0, 
    CONSTRAINT [FK_UserAccount_UserProfile] FOREIGN KEY ([UserId]) REFERENCES [UserProfile]([UserId])
)
