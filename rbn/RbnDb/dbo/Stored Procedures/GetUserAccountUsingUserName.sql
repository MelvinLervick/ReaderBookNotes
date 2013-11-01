CREATE PROCEDURE [dbo].[GetUserAccountUsingUserName] 
	@UserName nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT        
		dbo.UserProfile.UserId
		, dbo.UserProfile.UserName
		, dbo.UserAccount.FirstName
		, dbo.UserAccount.LastName
    , dbo.UserAccount.DateOfBirth
		, dbo.UserAccount.EmailAddress
    , dbo.UserAccount.Country
    , dbo.UserAccount.Question1
    , dbo.UserAccount.Answer1
    , dbo.UserAccount.Question2
    , dbo.UserAccount.Answer2
    , dbo.UserAccount.AccountLocked
	FROM dbo.UserProfile 
	LEFT JOIN dbo.UserAccount ON dbo.UserProfile.UserId = dbo.UserAccount.UserId
  WHERE UserName = @UserName

END