using rbn.Providers.RbnDll.Adapters;
using rbnDLL;

namespace rbn.Providers.RbnDll
{
  public class UserAccountProvider : IUserAccountProvider
  {
    public UserAccountProvider()
    {
    }

    #region IUserAccountProvider Members

    public Models.UserAccount GetUserManagedFieldsFromUserAccount( string userName )
    {
      var userManagedFields = Security.GetUserManagedFieldsFromUserAccount( userName );
      return UserAccountAdapter.TransformToUiModel( userManagedFields );
    }

    public void SaveUserManagedFieldsInUserAccount( Models.UserAccount userAccount )
    {
      var userManagedFields = UserAccountAdapter.TransformToDllModel( userAccount );
      Security.SaveUserManagedFieldsInUserAccount( userManagedFields );
    }

    #endregion
  }
}