using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rbn.Models
{
  [Table( "RatingNotes" )]
  public class ReaderNotesModel
  {
    [Key]
    public int RatingNoteId
    {
      get;
      set;
    }

    public int BookId
    {
      get;
      set;
    }

    public int ReaderId
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

    public int AudienceId
    {
      get;
      set;
    }
  }
}