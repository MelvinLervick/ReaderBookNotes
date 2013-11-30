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
    public int ReaderNoteId { get; set; }

    [Required]
    public int ReaderId { get; set; }

    public int BookId { get; set; }

    [Display(Name = "Title:")]
    public string Title { get; set; }

    public int AuthorId { get; set; }

    [Display( Name = "Author:" )]
    public string AuthorName { get; set; }

    [Display( Name = "Reader Rating:" )]
    public int ReaderRating { get; set; }

    [Display( Name = "Book Rating:" )]
    public int BookRating { get; set; }

    [Required]
    [MinLength( 50 )]
    public string Note { get; set; }

    [Display( Name = "Comment:" )]
    [Range( 1, 9 )]
    public int ReviewerCommentRating { get; set; }
    [Display( Name = "Book:" )]
    [Range( 1, 9 )]
    public int ReviewerBookRating { get; set; }

    [Display( Name = "Audience:" )]
    public int AudienceId { get; set; }

    [Display( Name = "Notify:" )]
    public bool Notify { get; set; }

    public int NotesThatCanBeViewed { get; set; }
    public int Page { get; set; }
    public int TotalPages { get; set; }
    public bool NextPage { get; set; } // true - next page, false - previous page
  }
}