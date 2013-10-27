using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

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

    [Display( Name = "Author" )]
    public int AuthorId
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
    public int Rating
    {
      get;
      set;
    }
  }
}