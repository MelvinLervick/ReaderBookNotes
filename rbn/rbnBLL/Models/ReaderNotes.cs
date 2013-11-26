using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rbnBLL.Models
{
  public class ReaderNotes
  {
    public int ReaderNoteId { get; set; }
    public int ReaderId { get; set; }
    public int BookId { get; set; }
    public string Title { get; set; }
    public int AuthorId { get; set; }
    public string AuthorName { get; set; }
    public int ReaderRating { get; set; }
    public int BookRating { get; set; }
    public int ReviewerCommentRating { get; set; }
    public int ReviewerBookRating { get; set; }
    public int AudienceId { get; set; }
    public string Note { get; set; }
    public bool Notify { get; set; }
    public PageSelector Page { get; set; }
  }
}
