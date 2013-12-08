using System.ComponentModel.DataAnnotations;

namespace rbn.Models
{
  public class SearchBarModel
  {
    [Display( Name = "Search" )]
    public string SearchFor{ get; set; }

    [Display( Name = "SearchBy" )]
    public string SearchBy{ get; set; }

    [Display( Name = "Display:" )]
    public string Display{ get; set; }

    public bool Book{ get; set; }

    public bool Author{ get; set; }

    public bool ReaderNotes{ get; set; }
  }
}