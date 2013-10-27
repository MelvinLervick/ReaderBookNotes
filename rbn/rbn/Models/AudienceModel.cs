using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace rbn.Models
{
  [Table( "Audience" )]
  public class AudienceModel
  {
    [Key]
    public int AudienceId
    {
      get;
      set;
    }

    [Display( Name = "Audience" )]
    public string Name
    {
      get;
      set;
    }
  }
}