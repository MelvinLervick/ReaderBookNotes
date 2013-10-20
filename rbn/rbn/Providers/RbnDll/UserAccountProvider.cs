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

    public Models.UserAccount GetUserManagedFieldsFromUserAccount( int userId )
    {
      var userManagedFields = Security.GetUserManagedFieldsFromUserAccount( userId );
      return UserAccountAdapter.TransformToUiModel( userManagedFields );
    }

    #endregion
  }
}