using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rbnBLL.Models
{
  public class Ratings
  {
    public int RatingId { get; set; }
    public int UserId { get; set; }
    public int ReaderNoteId { get; set; }
    public int Rating1 { get; set; }
    public int? AudienceId { get; set; }
    public System.DateTime CreatedDate { get; set; }

    //public virtual Audience Audience { get; set; }
    //public virtual ReaderNotes ReaderNote { get; set; }
    //public virtual UserProfile UserProfile { get; set; }
  }
}
