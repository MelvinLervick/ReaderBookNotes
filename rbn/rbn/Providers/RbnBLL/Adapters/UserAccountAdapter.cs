using rbn.Models;

namespace rbn.Providers.RbnBLL.Adapters
{
  public class UserAccountAdapter
  {
    internal static UserAccountModel TransformToUiModel( rbnBLL.Models.UserAccount userAccountFields )
    {
      return new UserAccountModel
      {
        UserId = userAccountFields.UserId,
        FirstName = userAccountFields.FirstName,
        LastName = userAccountFields.LastName,
        DateOfBirth = userAccountFields.DateOfBirth,
        EmailAddress = userAccountFields.EmailAddress,
        Country = userAccountFields.Country,
        Question1 = userAccountFields.Question1,
        Answer1 = userAccountFields.Answer1,
        Question2 = userAccountFields.Question2,
        Answer2 = userAccountFields.Answer2,
        AccountLocked = userAccountFields.AccountLocked
      };
    }

    internal static rbnBLL.Models.UserAccount TransformToBLLModel( UserAccountModel userAccountFields )
    {
      return new rbnBLL.Models.UserAccount
      {
        UserId = userAccountFields.UserId,
        FirstName = userAccountFields.FirstName,
        LastName = userAccountFields.LastName,
        DateOfBirth = userAccountFields.DateOfBirth,
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