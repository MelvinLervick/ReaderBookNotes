using System;
using System.Data.Entity.Migrations;
using System.Linq;
using rbnDLL;

namespace rbnBLL.Providers
{
  public class UserAccountProvider : IUserAccount
  {
    #region IUserAccount Members

    public Models.UserAccount GetUserManagedFieldsFromUserAccount( string userName )
    {
      using (var db = new rbndbEntities())
      {
        var userFieldData = (from ua in db.GetUserAccountUsingUserName( userName )
                             select new Models.UserAccount
                             {
                               UserId = ua.UserId,
                               FirstName = ua.FirstName,
                               LastName = ua.LastName,
                               DateOfBirth = ua.DateOfBirth ?? DateTime.Parse("1/1/0001"),
                               EmailAddress = ua.EmailAddress,
                               Country = ua.Country,
                               Question1 = ua.Question1,
                               Answer1 = ua.Answer1,
                               Question2 = ua.Question2,
                               Answer2 = ua.Answer2,
                               Rating = ua.Rating ?? 0,
                               AccountLocked = ua.AccountLocked ?? false
                             }).FirstOrDefault();

        return userFieldData;
      }
    }

    public void SaveUserManagedFieldsInUserAccount(Models.UserAccount fieldValues)
    {
      using (var db = new rbndbEntities())
      {
        db.UserAccounts.AddOrUpdate(new UserAccount
        {
          UserId = fieldValues.UserId,
          FirstName = fieldValues.FirstName,
          LastName = fieldValues.LastName,
          DateOfBirth = fieldValues.DateOfBirth,
          EmailAddress = fieldValues.EmailAddress,
          Country = fieldValues.Country,
          Question1 = fieldValues.Question1,
          Answer1 = fieldValues.Answer1,
          Question2 = fieldValues.Question2,
          Answer2 = fieldValues.Answer2,
          AccountLocked = fieldValues.AccountLocked,
          LastModifiedDate = DateTime.Now
        });

        db.SaveChanges();
      }
    }

    #endregion
  }
}
