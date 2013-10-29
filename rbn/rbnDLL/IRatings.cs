using System.Collections.Generic;

namespace rbnDLL
{
  public interface IRatings
  {
    IEnumerable<Ratings> AuthorRatingsList(int authorId);
    void RatingsCreate( Ratings newRating );
  }
}