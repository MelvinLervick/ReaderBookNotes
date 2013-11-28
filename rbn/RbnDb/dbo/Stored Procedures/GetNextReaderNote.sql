CREATE PROCEDURE GetNextReaderNote
	@bookId int,
	@notesThatCanBeViewed int = 0,
	@page int = 0,
	@totalPages int,
	@next bit = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @TotalNotes int = 0
	Select @TotalNotes = Count(ReaderNoteId)
	From [dbo].[ReaderNotes]
	Where BookId = @bookId AND Enabled = 1

	if @notesThatCanBeViewed > 0 AND @TotalNotes > @notesThatCanBeViewed
	BEGIN
		SET @TotalNotes = @notesThatCanBeViewed
	END
	--PRINT @TotalNotes

	DECLARE @pageToReturn int = 1
	IF @next = 1
	BEGIN
		IF (@page + 1) > @TotalNotes
		BEGIN
			SET @pageToReturn = @TotalNotes
		END
		ELSE
		BEGIN
			SET @pageToReturn = @page + 1
		END
	END
	ELSE
	BEGIN
		IF (@page - 1) > @TotalNotes
		BEGIN
			SET @pageToReturn = @TotalNotes
		END
		ELSE
		BEGIN
			IF @page - 1 <= 0
				SET @pageToReturn = 1
			ELSE
				SET @pageToReturn = @page - 1
		END
	END

  SELECT 
	  row.Page
	  ,row.ReaderNoteId
	  ,row.BookId
	  ,row.ReaderId
	  ,row.Rating
	  ,row.AudienceId
	  ,row.Note
	  ,row.Notify
	  ,ua.Rating AS ReaderRating
	  ,@TotalNotes AS TotalNotes 
  FROM
  (
  Select TOP (@TotalNotes) ROW_NUMBER() OVER (ORDER BY LastModifiedDate DESC) as Page, * 
  From [dbo].[ReaderNotes]
  Where BookId = @bookId AND Enabled = 1
  ) as row
  JOIN [dbo].[UserAccount] ua ON ua.UserId = row.ReaderId
  WHERE row.Page = @pageToReturn
END
