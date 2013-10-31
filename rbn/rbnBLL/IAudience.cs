using System.Collections.Generic;
using rbnBLL.Models;

namespace rbnBLL
{
  public interface IAudience
  {
    IEnumerable<Audience> AudienceList();
    Audience AudienceDetails(int audienceId);
  }
}