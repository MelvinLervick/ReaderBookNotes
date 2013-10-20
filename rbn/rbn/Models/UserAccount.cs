using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

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
    [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Invalid Email Address")]
    public string EmailAddress
    {
      get;
      set;
    }

    [Display( Name = "Country" )]
    public string Country
    {
      get;
      set;
    }

    [Display( Name = "Question 1" )]
    public string Question1
    {
      get;
      set;
    }

    [Display( Name = "Answer 1" )]
    public string Answer1
    {
      get;
      set;
    }

    [Display( Name = "Question 2" )]
    public string Question2
    {
      get;
      set;
    }

    [Display( Name = "Answer 2" )]
    public string Answer2
    {
      get;
      set;
    }

    public bool AccountLocked
    {
      get;
      set;
    }

    public int AccountUserId
    {
      get;
      set;
    }
  }
}