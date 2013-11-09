using System.ComponentModel.DataAnnotations;

namespace rbn.Models
{
  public class BaseModel
  {
    [Display( Name = "Enabled" )]
    public bool Enabled
    {
      get;
      set;
    }

    [Display( Name = "Error Message" )]
    public string Message { get; set; }
  }
}