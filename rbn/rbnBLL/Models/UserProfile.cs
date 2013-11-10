using System.Collections.Generic;

namespace rbnBLL.Models
{
  public class UserProfile
  {
    public int UserId { get; set; }
    public string UserName { get; set; }
    public System.DateTime DateCreated { get; set; }

    //public virtual UserAccount UserAccount { get; set; }
    //public virtual ICollection<UserRoles> webpages_Roles { get; set; }
    //public virtual ICollection<ReaderNotes> ReaderNotes { get; set; }
    //public virtual ICollection<Ratings> Ratings { get; set; }
  }
}
