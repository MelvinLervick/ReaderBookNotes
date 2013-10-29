using System.Collections;
using System.Collections.Generic;

namespace rbnDLL
{
  public interface IAudience
  {
    IEnumerable<Audience> AudienceList();
    Audience AudienceDetails(int audienceId);
  }
}