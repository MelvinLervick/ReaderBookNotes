using System;

namespace rbnBLL.Models
{
  public class Ratings
  {
    public int RatingId { get; set; }
    public int UserId { get; set; }
    public string RatingType { get; set; }
    public int IdBeingRated { get; set; }
    public int Rating { get; set; }
    public DateTime CreatedDate { get; set; }
  }
}
