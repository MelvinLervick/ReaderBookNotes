CREATE TABLE [dbo].[Ratings]
(
    [RatingId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] INT NOT NULL, 
    [RatingType] varchar(1) DEFAULT 'r' NOT NULL, 
    [IdBeingRated] INT NOT NULL, 
    [Rating] INT NOT NULL DEFAULT 1, 
    [CreatedDate] DATETIME NOT NULL DEFAULT getutcdate(), 
    CONSTRAINT [FK_Ratings_UserProfile] FOREIGN KEY ([UserId]) REFERENCES [UserProfile]([UserId]) 
)

GO
