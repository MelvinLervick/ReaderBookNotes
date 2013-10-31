using System.Collections.Generic;
using rbnBLL.Models;

namespace rbnBLL
{
  public interface IRatings
  {
    IEnumerable<Ratings> AuthorRatingsList(int authorId);
    void RatingsCreate( Ratings newRating );
  }
}