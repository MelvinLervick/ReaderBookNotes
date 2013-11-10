using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rbnBLL.Models
{
  public class Audience
  {
    public int AudienceId { get; set; }
    public string Name { get; set; }
    public bool Enabled { get; set; }

    //public virtual ICollection<Book> Books { get; set; }
    //public virtual ICollection<ReaderNotes> ReaderNotes { get; set; }
    //public virtual ICollection<Ratings> Ratings { get; set; }
  }
}
