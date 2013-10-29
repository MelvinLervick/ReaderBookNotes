using System;
using System.Collections.Generic;

namespace rbnDLL.Providers
{
  public class AudienceProvider : IAudience
  {
    #region IAudience Members

    public IEnumerable<Audience> AudienceList()
    {
      throw new NotImplementedException();
    }

    public Audience AudienceDetails( int audienceId )
    {
      throw new NotImplementedException();
    }

    #endregion
  }
}
