CREATE PROCEDURE [dbo].[GetReaderAliasesForBook]
  @bookId int = 0
AS
BEGIN
	SET NOCOUNT ON;

  SELECT DISTINCT up.UserId, up.UserName FROM UserProfile up
  JOIN ReaderNotes rn ON rn.ReaderId = up.UserId
  WHERE rn.BookId = @bookId
  ORDER BY up.UserName

END