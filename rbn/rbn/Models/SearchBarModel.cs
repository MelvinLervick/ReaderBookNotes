using System.ComponentModel.DataAnnotations;

namespace rbn.Models
{
  public class SearchBarModel
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

    [Display( Name = "Display:" )]
    public string Display
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

    [Display( Name = "Notes" )]
    public bool ReaderNotes
    {
      get;
      set;
    }
  }
}