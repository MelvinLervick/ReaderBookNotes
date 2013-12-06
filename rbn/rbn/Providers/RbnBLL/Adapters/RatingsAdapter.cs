using rbn.Models;

namespace rbn.Providers.RbnBLL.Adapters
{
  public class RatingsAdapter
  {
    internal static rbnBLL.Models.Ratings TransformToBLLModel( RatingsModel fields )
    {
      return new rbnBLL.Models.Ratings
      {
        RatingId = fields.RatingId,
        UserId = fields.UserId,
        IdBeingRated = fields.IdBeingRated,
        Rating = fields.Rating
      };
    }
  }
}