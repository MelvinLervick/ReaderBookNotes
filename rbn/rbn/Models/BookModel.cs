using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rbn.Models
{
  [Table( "Book" )]
  public class BookModel
  {
    [Key]
    public int BookId
    {
      get;
      set;
    }

    [Display( Name = "Title" )]
    [StringLength( 50 )]
    public string Title
    {
      get;
      set;
    }

    [Display( Name = "ISBN" )]
    [StringLength( 32 )]
    public string ISBN
    {
      get;
      set;
    }

    [Display( Name = "Author Name" )]
    public int AuthorId
    {
      get;
      set;
    }

    [Display( Name = "Author Name" )]
    public string AuthorName
    {
      get;
      set;
    }

    [Display( Name = "Audience" )]
    public int AudienceId
    {
      get;
      set;
    }

    [Display( Name = "Audience" )]
    public string AudienceName
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

    [Display( Name = "Enabled" )]
    public bool Enabled
    {
      get;
      set;
    }
  }
}