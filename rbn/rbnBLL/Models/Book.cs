using System.Collections.Generic;

namespace rbnBLL.Models
{
  public class Book
  {
    public int BookId { get; set; }
    public string ISBN { get; set; }
    public string Title { get; set; }
    public int? AuthorId { get; set; }
    public int? AudienceId { get; set; }
    public int Rating { get; set; }
    public System.DateTime LastModifiedDate { get; set; }
    public bool Enabled { get; set; }

    public virtual Audience Audience { get; set; }
    public virtual Author Author { get; set; }
    //public virtual ICollection<ReaderNotes> ReaderNotes { get; set; }
  }
}
