CREATE TABLE [dbo].[UserAccount]
(
	[UserId] INT NOT NULL PRIMARY KEY UNIQUE, 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [EmailAddress] NVARCHAR(100) NULL, 
    [Country] NVARCHAR(50) NULL, 
    [DateOfBirth] DATETIME NULL, 
    [Question1] NVARCHAR(100) NULL, 
    [Answer1] NVARCHAR(100) NULL, 
    [Question2] NVARCHAR(100) NULL, 
    [Answer2] NVARCHAR(100) NULL, 
    [Rating] INT NULL DEFAULT 1, 
    [NeedsApproval] BIT NULL DEFAULT 0, 
    [AccountLocked] BIT NULL DEFAULT 0, 
    [LastModifiedDate] DATETIME NOT NULL DEFAULT getdate(), 
    CONSTRAINT [FK_UserAccount_UserProfile] FOREIGN KEY ([UserId]) REFERENCES [UserProfile]([UserId])
)
