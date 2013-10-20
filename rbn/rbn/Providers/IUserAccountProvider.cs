using rbn.Models;

namespace rbn.Providers
{
  public interface IUserAccountProvider
  {
    UserAccount GetUserManagedFieldsFromUserAccount( string userName );
    void SaveUserManagedFieldsInUserAccount(Models.UserAccount userAccount);
  }
}