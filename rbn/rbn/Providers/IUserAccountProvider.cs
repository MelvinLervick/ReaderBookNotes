using rbn.Models;

namespace rbn.Providers
{
  public interface IUserAccountProvider
  {
    UserAccountModel GetUserManagedFieldsFromUserAccount( string userName );
    void SaveUserManagedFieldsInUserAccount(UserAccountModel userAccount);
  }
}