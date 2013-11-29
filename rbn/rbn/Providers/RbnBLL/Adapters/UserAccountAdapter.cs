using rbn.Models;

namespace rbn.Providers.RbnBLL.Adapters
{
  public class UserAccountAdapter
  {
    internal static UserAccountModel TransformToUiModel( rbnBLL.Models.UserAccount fields )
    {
      return new UserAccountModel
      {
        UserId = fields.UserId,
        FirstName = fields.FirstName,
        LastName = fields.LastName,
        DateOfBirth = fields.DateOfBirth,
        EmailAddress = fields.EmailAddress,
        Country = fields.Country,
        Question1 = fields.Question1,
        Answer1 = fields.Answer1,
        Question2 = fields.Question2,
        Answer2 = fields.Answer2,
        Rating = fields.Rating,
        AccountLocked = fields.AccountLocked
      };
    }

    internal static rbnBLL.Models.UserAccount TransformToBLLModel( UserAccountModel fields )
    {
      return new rbnBLL.Models.UserAccount
      {
        UserId = fields.UserId,
        FirstName = fields.FirstName,
        LastName = fields.LastName,
        DateOfBirth = fields.DateOfBirth,
        EmailAddress = fields.EmailAddress,
        Country = fields.Country,
        Question1 = fields.Question1,
        Answer1 = fields.Answer1,
        Question2 = fields.Question2,
        Answer2 = fields.Answer2,
        AccountLocked = fields.AccountLocked
      };
    }
  }
}