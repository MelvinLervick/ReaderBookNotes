using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace rbn.Models
{
  [Table( "Author" )]
  public class AuthorModel
  {
    [Key]
    public int AuthorId
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

    [Display( Name = "Middle Name" )]
    [StringLength( 30 )]
    public string MiddleName
    {
      get;
      set;
    }

    [Required]
    [Display( Name = "Last Name" )]
    [StringLength( 50 )]
    public string LastName
    {
      get;
      set;
    }

    [Display( Name = "Rating" )]
    public int Rating
    {
      get;
      set;
    }
  }
}