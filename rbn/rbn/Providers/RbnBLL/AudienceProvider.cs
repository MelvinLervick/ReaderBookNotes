using System.Collections.Generic;
using rbn.Providers.RbnBLL.Adapters;

namespace rbn.Providers.RbnBLL
{
  public class AudienceProvider : IAudienceProvider
  {
    public AudienceProvider()
    {
    }

    #region IAudienceProvider Members

    public List<Models.AudienceModel> GetAudienceList()
    {
      return AudienceAdapter.TransformToUiModel( Provider.GetAudienceList() );
    }

    #endregion

    private rbnBLL.Providers.AudienceProvider provider;
    internal rbnBLL.Providers.AudienceProvider Provider
    {
      get { return provider ?? (provider = new rbnBLL.Providers.AudienceProvider()); }
    }
  }
}