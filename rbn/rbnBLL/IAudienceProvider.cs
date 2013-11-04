using System.Collections.Generic;
using rbnBLL.Models;

namespace rbnBLL
{
  public interface IAudienceProvider
  {
    IEnumerable<Audience> GetAudienceList();
    Audience GetAudienceName(int audienceId);
    void EnableAudience( int audienceId, bool enableFlag );
  }
}