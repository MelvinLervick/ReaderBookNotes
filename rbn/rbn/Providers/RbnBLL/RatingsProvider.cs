using rbn.Providers.RbnBLL.Adapters;

namespace rbn.Providers.RbnBLL
{
  public class RatingsProvider : IRatingsProvider
  {
    public RatingsProvider()
    {
    }

    #region IRatingsProvider Members

    public void SaveReaderRating( Models.RatingsModel rating )
    {
      Provider.SaveReaderRating( RatingsAdapter.TransformToBLLModel( rating ) );
    }

    public void SaveBookRating( Models.RatingsModel rating )
    {
      Provider.SaveBookRating( RatingsAdapter.TransformToBLLModel( rating ) );
    }

    #endregion

    private rbnBLL.Providers.RatingsProvider provider;
    internal rbnBLL.Providers.RatingsProvider Provider
    {
      get { return provider ?? (provider = new rbnBLL.Providers.RatingsProvider()); }
    }
  }
}