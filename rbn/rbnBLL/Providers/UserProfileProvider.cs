using System.Collections.Generic;
using System.Linq;
using rbnDLL;

namespace rbnBLL.Providers
{
  public class UserProfileProvider : IUserProfile
  {

    #region IUserProfile Members

    public IEnumerable<Models.UserProfile> GetReaderAliases()
    {
      using (var db = new rbndbEntities())
      {
        var readerAliases = (from up in db.UserProfiles
                         orderby up.UserName
                         select new Models.UserProfile()
                         {
                           UserId = up.UserId,
                           UserName = up.UserName
                         }).ToList();

        return readerAliases;
      }
    }

    public IEnumerable<Models.UserProfile> GetReaderAliases( int bookId )
    {
      using (var db = new rbndbEntities())
      {
        var readerAliases = (from up in db.GetReaderAliasesForBook( bookId )
                             select new Models.UserProfile()
                             {
                               UserId = up.UserId,
                               UserName = up.UserName
                             }).ToList();

        return readerAliases;
      }
    }

    #endregion
  }
}