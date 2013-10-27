using rbn.Models;
using rbnDLL.Models;

namespace rbn.Providers.RbnDll.Adapters
{
  public class UserAccountAdapter
  {
    internal static UserAccountModel TransformToUiModel( UserAccountUserFields userAccountFields )
    {
      return new UserAccountModel
      {
        UserId = userAccountFields.UserId,
        FirstName = userAccountFields.FirstName,
        LastName = userAccountFields.LastName,
        EmailAddress = userAccountFields.EmailAddress,
        Country = userAccountFields.Country,
        Question1 = userAccountFields.Question1,
        Answer1 = userAccountFields.Answer1,
        Question2 = userAccountFields.Question2,
        Answer2 = userAccountFields.Answer2,
        AccountLocked = userAccountFields.AccountLocked
      };
    }

    internal static UserAccountUserFields TransformToDllModel( UserAccountModel userAccountFields )
    {
      return new UserAccountUserFields
      {
        UserId = userAccountFields.UserId,
        FirstName = userAccountFields.FirstName,
        LastName = userAccountFields.LastName,
        EmailAddress = userAccountFields.EmailAddress,
        Country = userAccountFields.Country,
        Question1 = userAccountFields.Question1,
        Answer1 = userAccountFields.Answer1,
        Question2 = userAccountFields.Question2,
        Answer2 = userAccountFields.Answer2,
        AccountLocked = userAccountFields.AccountLocked
      };
    }
  }
}