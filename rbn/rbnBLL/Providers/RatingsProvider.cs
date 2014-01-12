using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rbnDLL;
using Ratings = rbnBLL.Models.Ratings;

namespace rbnBLL.Providers
{
  public class RatingsProvider : IRatingsProvider
  {
    private const string BOOK_RATING = "b";
    private const string READER_RATING = "r";

    #region IRatingsProvider Members

    public void SaveReaderRating( Models.Ratings rating )
    {
      rating.RatingType = READER_RATING;
      SaveRating( rating );
    }

    public void SaveBookRating( Models.Ratings rating )
    {
      rating.RatingType = BOOK_RATING;
      SaveRating( rating );
    }

    #endregion

    private static void SaveRating( Ratings rating )
    {
      using (var db = new rbndbEntities())
      {
        db.Ratings.AddOrUpdate( new rbnDLL.Ratings
        {
          RatingId = rating.RatingId,
          UserId = rating.UserId,
          RatingType = rating.RatingType,
          IdBeingRated = rating.IdBeingRated,
          Rating = rating.Rating,
          CreatedDate = DateTime.UtcNow
        } );

        db.SaveChanges();

        db.UpdateRatings();
      }
    }
  }
}
