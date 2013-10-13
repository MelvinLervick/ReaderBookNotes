CREATE TABLE [dbo].[UserProfile]
(
	[UserId] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [UserName] NVARCHAR(50) NOT NULL, 
    [DateCreated] DATETIME NOT NULL DEFAULT GetDate()
)
