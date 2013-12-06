using System.Collections.Generic;
using System.Deployment.Internal;
using rbnBLL.Models;

namespace rbnBLL
{
  public interface IRatingsProvider
  {
    void SaveReaderRating( Ratings rating );
    void SaveBookRating( Ratings rating );
  }
}