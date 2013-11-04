using System.Collections.Generic;
using rbnBLL.Models;

namespace rbnBLL
{
  public interface IRatingsProvider
  {
    IEnumerable<Ratings> GetAuthorRatingsList( int authorId );
    void CreateAuthorRating( Ratings newRating );
  }
}