using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rbnDLL.Models;

namespace rbnDLL
{
  public class Security
  {
    public static UserAccountUserFields GetUserManagedFieldsFromUserAccount( string userName )
    {
      using (var db = new rbndbEntities())
      {
        var userFieldData = (from ua in db.GetUserAccountUsingUserName(userName)
          select new UserAccountUserFields
          {
            UserId = ua.UserId,
            FirstName = ua.FirstName,
            LastName = ua.LastName,
            EmailAddress = ua.EmailAddress,
            Question1 = ua.Question1,
            Answer1 = ua.Answer1,
            Question2 = ua.Question2,
            Answer2 = ua.Answer2,
            AccountLocked = ua.AccountLocked ?? false,
            AccountUserId = ua.AccountUserId
          }).FirstOrDefault();

        return userFieldData;
      }
    }
  }
}
