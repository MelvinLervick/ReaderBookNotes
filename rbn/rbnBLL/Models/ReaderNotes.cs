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
    public Book Book { get; set; }
    public Author Author { get; set; }
    public int ReaderRating { get; set; }
    public string Note { get; set; }
    public int AudienceId { get; set; }
    public int ReviewerCommentRating { get; set; }
    public int ReviewerBookRating { get; set; }
    public bool Notify { get; set; }
    public PageSelector Page { get; set; }
  }
}
