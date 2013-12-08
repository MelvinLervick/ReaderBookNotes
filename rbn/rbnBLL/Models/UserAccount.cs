using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rbnBLL.Models
{
  public class UserAccount
  {
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public int Rating { get; set; }
    public bool NeedsApproval { get; set; }
    public bool AccountLocked { get; set; }
    public string Country { get; set; }
    public string Question1 { get; set; }
    public string Answer1 { get; set; }
    public string Question2 { get; set; }
    public string Answer2 { get; set; }
    public System.DateTime LastModifiedDate { get; set; }
    public System.DateTime DateOfBirth { get; set; }
  }
}
