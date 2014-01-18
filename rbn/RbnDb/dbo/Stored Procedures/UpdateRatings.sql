CREATE PROCEDURE [dbo].[UpdateRatings]
AS
  UPDATE [dbo].[ReaderNotes]
	  SET Rating = r.Rating
  FROM [dbo].[ReaderNotes] AS rn
  JOIN (
  SELECT [IdBeingRated], [RatingType], SUM(Rating)/COUNT(RatingId) AS Rating
  FROM [dbo].[Ratings]
  WHERE RatingType='r'
  GROUP BY [RatingType], [IdBeingRated]
  ) AS r ON rn.[ReaderNoteId] = r.IdBeingRated

  UPDATE [dbo].[Book]
	  SET Rating = r.Rating
  FROM [dbo].[Book] AS b
  JOIN (
  SELECT [IdBeingRated], [RatingType], SUM(Rating)/COUNT(RatingId) AS Rating
  FROM [dbo].[Ratings]
  WHERE RatingType='b'
  GROUP BY [RatingType], [IdBeingRated]
  ) AS r ON b.BookId = r.IdBeingRated
RETURN 0
