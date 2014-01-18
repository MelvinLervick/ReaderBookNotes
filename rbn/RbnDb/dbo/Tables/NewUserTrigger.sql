CREATE TRIGGER [NewUserTrigger]
ON UserProfile
FOR Insert
AS
BEGIN
  SET NOCOUNT ON
  DECLARE @UserId As Int
  DECLARE @RoleId As Int
  Select @UserId = i.UserId From inserted i;
  Select @RoleId = RoleId From webpages_Roles Where RoleName = 'Contributor';

  IF EXISTS(Select UserId From UserProfile Where UserId = @UserId)
  BEGIN
    Insert Into webpages_UsersInRoles(UserId, RoleId) Values (@UserId, @RoleId)
  END
END

GO