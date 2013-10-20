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
    public static UserAccountUserFields GetUserManagedFieldsFromUserAccount( int userId )
    {
      using (var db = new rbndbEntities())
      {
        var userFieldData = (from ua in db.UserAccounts
                             where ua.UserId == userId
                             select new UserAccountUserFields
                             {
                               UserId = ua.UserId,
                               FirstName = ua.FirstName,
                               LastName = ua.LastName,
                               EmailAddress = ua.EmailAddress
                             }).FirstOrDefault();

        return userFieldData;
      }
    }
  }
}
