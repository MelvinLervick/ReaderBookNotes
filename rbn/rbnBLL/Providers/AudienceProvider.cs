using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rbnDLL;

namespace rbnBLL.Providers
{
  public class AudienceProvider : IAudienceProvider
  {
    #region IAudienceProvider Members

    public IEnumerable<Models.Audience> GetAudienceList()
    {
      using (var db = new rbndbEntities())
      {
        var fieldData = (from ua in db.Audiences
                         orderby ua.Name
                         select new Models.Audience
                         {
                           AudienceId = ua.AudienceId,
                           Name = ua.Name
                         }).ToList();

        return fieldData;
      }
    }

    public Models.Audience GetAudienceName( int audienceId )
    {
      throw new NotImplementedException();
    }

    public void EnableAudience( int audienceId, bool enableFlag )
    {
      throw new NotImplementedException();
    }

    #endregion
  }
}
