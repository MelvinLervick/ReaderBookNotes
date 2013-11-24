using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rbn.Models
{
  [Table( "ReaderNotes" )]
  public class ReaderNotesModel
  {
    [Key]
    public int ReaderNoteId
    {
      get;
      set;
    }

    [Required]
    public int ReaderId
    {
      get;
      set;
    }

    public int BookId
    {
      get;
      set;
    }

    [Display(Name = "Title:")]
    public string Title { get; set; }

    public int AuthorId { get; set; }

    [Display( Name = "Author:" )]
    public string AuthorName { get; set; }

    [Display( Name = "Reader Rating:" )]
    public int ReaderRating
    {
      get;
      set;
    }

    [Display( Name = "Please Rate the Comments on a Scale of 1-9 (where 9 is best):" )]
    [Range( 1, 9 )]
    public int Rating
    {
      get;
      set;
    }

    [Display( Name = "Audience:" )]
    public int AudienceId
    {
      get;
      set;
    }

    [Display( Name = "Notify:" )]
    public bool Notify
    {
      get;
      set;
    }
  }
}