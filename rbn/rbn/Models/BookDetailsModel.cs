using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web.Mvc;

namespace rbn.Models
{
  [Table( "Book" )]
  public class BookDetailsModel : BaseModel
  {
    [Key]
    public int BookId
    {
      get;
      set;
    }

    [Required]
    [Display( Name = "Title" )]
    [StringLength( 50 )]
    public string Title
    {
      get;
      set;
    }

    [Required]
    [Display( Name = "ISBN" )]
    [StringLength( 32 )]
    public string ISBN
    {
      get;
      set;
    }

    [Required]
    [Display( Name = "Author Name" )]
    public int AuthorId
    {
      get;
      set;
    }

    [Required]
    [Display( Name = "Audience" )]
    public int AudienceId
    {
      get;
      set;
    }

    [Display( Name = "Rating" )]
    [Range( 1, 9 )]
    public int Rating
    {
      get;
      set;
    }
  }
}