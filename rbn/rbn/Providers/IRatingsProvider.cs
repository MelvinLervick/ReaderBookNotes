using rbn.Models;

namespace rbn.Providers
{
  public interface IRatingsProvider
  {
    void SaveReaderRating( RatingsModel rating );
    void SaveBookRating( RatingsModel rating );
  }
}