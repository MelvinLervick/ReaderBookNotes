using System.ComponentModel.DataAnnotations;

namespace rbn.Models
{
  public class SearchBar
  {
    [Display( Name = "Search" )]
    public string SearchFor
    {
      get;
      set;
    }

    [Display( Name = "SearchBy" )]
    public string SearchBy
    {
      get;
      set;
    }

    [Display( Name = "Title" )]
    public bool BookTitle
    {
      get;
      set;
    }

    [Display( Name = "Author" )]
    public bool BookAuthor
    {
      get;
      set;
    }

    [Display( Name = "ISBN" )]
    public bool BookIsbn
    {
      get;
      set;
    }
  }
}