using System.Collections.Generic;

namespace rbnBLL.Models
{
  public class Author
  {
    public int AuthorId { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public int Rating { get; set; }
    public System.DateTime LastModifiedDate { get; set; }
    public bool Enabled { get; set; }

    //public virtual ICollection<Book> Books { get; set; }
  }
}
