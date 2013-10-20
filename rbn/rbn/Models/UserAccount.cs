using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rbn.Models
{
  [Table( "UserAccount" )]
  public class UserAccount
  {
    [Key]
    public int UserId
    {
      get;
      set;
    }
    [Display( Name = "First Name" )]
    public string FirstName
    {
      get;
      set;
    }

    [Display( Name = "Last Name" )]
    public string LastName
    {
      get;
      set;
    }

    [Display( Name = "Email Address" )]
    public string EmailAddress
    {
      get;
      set;
    }
  }
}