using System.Collections.Generic;
using rbn.Models;

namespace rbn.Providers
{
  public interface IAudienceProvider
  {
    List<AudienceModel> GetAudienceList();
  }
}