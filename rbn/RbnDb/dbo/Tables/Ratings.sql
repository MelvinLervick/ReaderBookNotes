CREATE TABLE [dbo].[Ratings]
(
  [RatingId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] INT NOT NULL, 
    [ReaderNoteId] INT NOT NULL, 
    [Rating] INT NOT NULL DEFAULT 0, 
    [AudienceId] INT NULL, 
    CONSTRAINT [FK_Ratings_UserProfile] FOREIGN KEY ([UserId]) REFERENCES [UserProfile]([UserId]), 
    CONSTRAINT [FK_Ratings_ReaderNotes] FOREIGN KEY ([ReaderNoteId]) REFERENCES [ReaderNotes]([ReaderNoteId]), 
    CONSTRAINT [FK_Ratings_Audience] FOREIGN KEY ([AudienceId]) REFERENCES [Audience]([AudienceId])
)

GO

CREATE TRIGGER [dbo].[Trigger_RatingsAudienceId]
    ON [dbo].[Ratings]
    AFTER INSERT
    AS
    BEGIN
      DECLARE @RatingId As Int
      DECLARE @AudienceId As Int
      Select @RatingId = i.RatingId From inserted i;
      Select @AudienceId = AudienceId From Audience Where Name = 'Not Specified';

      IF EXISTS(Select RatingId From Ratings Where RatingId = @RatingId)
      BEGIN
        Update Ratings SET AudienceId=@AudienceId WHERE RatingId = @RatingId
      END
    END