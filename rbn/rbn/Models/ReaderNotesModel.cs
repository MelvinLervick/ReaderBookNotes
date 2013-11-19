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

    [Display( Name = "Rating:" )]
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