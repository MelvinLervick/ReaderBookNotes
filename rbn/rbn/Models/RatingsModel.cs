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

    [Display( Name = "Reader" )]
    public int UserId
    {
      get;
      set;
    }

    [Display( Name = "Notes" )]
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
    public int Rating
    {
      get;
      set;
    }

    [Display( Name = "Note" )]
    public string Note
    {
      get;
      set;
    }

    [Display( Name = "Notify" )]
    public bool Notify
    {
      get;
      set;
    }
  }
}