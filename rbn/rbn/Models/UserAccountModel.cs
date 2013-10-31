using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rbn.Models
{
  [Table( "UserAccount" )]
  public class UserAccountModel
  {
    [Key]
    public int UserId
    {
      get;
      set;
    }

    [Display( Name = "First Name" )]
    [StringLength( 50 )]
    public string FirstName
    {
      get;
      set;
    }

    [Display( Name = "Last Name" )]
    [StringLength( 50 )]
    public string LastName
    {
      get;
      set;
    }

    [Display( Name = "Date of Birth" )]
    [DataType( DataType.Date )]
    public DateTime DateOfBirth
    {
      get;
      set;
    }

    [Display( Name = "Email Address" )]
    [StringLength( 100 )]
    [RegularExpression( @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Invalid Email Address" )]
    public string EmailAddress
    {
      get;
      set;
    }

    [Display( Name = "Country" )]
    [StringLength( 50 )]
    public string Country
    {
      get;
      set;
    }

    [Display( Name = "Question 1" )]
    [StringLength( 100 )]
    public string Question1
    {
      get;
      set;
    }

    [Display( Name = "Answer 1" )]
    [StringLength( 100 )]
    public string Answer1
    {
      get;
      set;
    }

    [Display( Name = "Question 2" )]
    [StringLength( 100 )]
    public string Question2
    {
      get;
      set;
    }

    [Display( Name = "Answer 2" )]
    [StringLength( 100 )]
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
  }
}