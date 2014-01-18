using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rbn.Models
{
  [Table( "Ratings" )]
  public class RatingsModel
  {
    [Key]
    public int RatingId { get; set; }

    public int UserId { get; set; }

    public int IdBeingRated { get; set; }

    public int Rating { get; set; }
  }
}