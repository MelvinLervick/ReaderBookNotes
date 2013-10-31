using rbn.Providers.RbnBLL.Adapters;
using rbnBLL;

namespace rbn.Providers.RbnBLL
{
  public class UserAccountProvider : IUserAccountProvider
  {
    public UserAccountProvider()
    {
    }

    #region IUserAccountProvider Members

    public Models.UserAccountModel GetUserManagedFieldsFromUserAccount( string userName )
    {
      var userManagedFields = Provider.GetUserManagedFieldsFromUserAccount( userName );
      return UserAccountAdapter.TransformToUiModel( userManagedFields );
    }

    public void SaveUserManagedFieldsInUserAccount( Models.UserAccountModel userAccount )
    {
      var userManagedFields = UserAccountAdapter.TransformToBLLModel( userAccount );
      Provider.SaveUserManagedFieldsInUserAccount( userManagedFields );
    }

    #endregion

    private rbnBLL.Providers.UserAccountProvider provider;
    internal rbnBLL.Providers.UserAccountProvider Provider
    {
      get { return provider ?? (provider = new rbnBLL.Providers.UserAccountProvider()); }
    }
  }
}