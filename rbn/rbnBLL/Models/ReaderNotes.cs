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
    public int BookId { get; set; }
    public int ReaderId { get; set; }
    public int Rating { get; set; }
    public int AudienceId { get; set; }
    public string Note { get; set; }
    public bool Notify { get; set; }
    public DateTime? DateNotified { get; set; }
    public string EmailAddress { get; set; }
    public System.DateTime LastModifiedDate { get; set; }
    public bool Enabled { get; set; }

    //public virtual Audience Audience { get; set; }
    //public virtual Book Book { get; set; }
    //public virtual UserProfile UserProfile { get; set; }
    //public virtual ICollection<Ratings> Ratings { get; set; }
  }
}
