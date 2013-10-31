using rbnBLL.Models;

namespace rbnBLL
{
  public interface IUserAccount
  {
    UserAccount GetUserManagedFieldsFromUserAccount(string userName);
    void SaveUserManagedFieldsInUserAccount(UserAccount fieldValues);
  }
}