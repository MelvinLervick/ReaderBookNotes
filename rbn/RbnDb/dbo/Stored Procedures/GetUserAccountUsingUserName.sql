CREATE PROCEDURE [dbo].[GetUserAccountUsingUserName] 
	@UserName nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT        
		dbo.UserProfile.UserId
		, dbo.UserProfile.UserName
		, dbo.UserAccount.UserId AS AccountUserId
		, dbo.UserAccount.FirstName
		, dbo.UserAccount.LastName
		, dbo.UserAccount.EmailAddress
    , dbo.UserAccount.Country
    , dbo.UserAccount.Question1
    , dbo.UserAccount.Answer1
    , dbo.UserAccount.Question2
    , dbo.UserAccount.Answer2
    , dbo.UserAccount.AccountLocked
	FROM dbo.UserProfile 
	INNER JOIN dbo.UserAccount ON dbo.UserProfile.UserId = dbo.UserAccount.UserId
  WHERE UserName = @UserName

END