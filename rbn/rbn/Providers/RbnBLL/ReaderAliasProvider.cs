using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using rbn.Providers.RbnBLL.Adapters;

namespace rbn.Providers.RbnBLL
{
  public class ReaderAliasProvider : IReaderAliasProvider
  {
    public ReaderAliasProvider()
    {
    }

    #region IReaderAliases Members

    public List<Models.ReaderAliasModel> GetReaderAliases()
    {
      return ReaderAliasAdapter.TransformToUiModel( Provider.GetReaderAliases() );
    }

    public List<Models.ReaderAliasModel> GetReaderAliases( int bookId )
    {
      return ReaderAliasAdapter.TransformToUiModel( Provider.GetReaderAliases( bookId ) );
    }

    #endregion

    private rbnBLL.Providers.UserProfileProvider provider;
    internal rbnBLL.Providers.UserProfileProvider Provider
    {
      get { return provider ?? (provider = new rbnBLL.Providers.UserProfileProvider()); }
    }
  }
}