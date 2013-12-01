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
    public int RatingId
    {
      get;
      set;
    }

    [Display( Name = "ReaderId" )]
    public int UserId
    {
      get;
      set;
    }

    [Display( Name = "NoteId" )]
    public int ReaderNoteId
    {
      get;
      set;
    }

    [Display( Name = "Audience" )]
    public int AudienceId
    {
      get;
      set;
    }

    [Display( Name = "Rating" )]
    [Range( 1, 9 )]
    public int Rating
    {
      get;
      set;
    }
  }
}