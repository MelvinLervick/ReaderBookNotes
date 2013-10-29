using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rbnDLL.Providers
{
  public class RatingsProvider : IRatings
  {
    #region IRatings Members

    public IEnumerable<Ratings> AuthorRatingsList( int authorId )
    {
      throw new NotImplementedException();
    }

    public void RatingsCreate( Ratings newRating )
    {
      throw new NotImplementedException();
    }

    #endregion
  }
}
