using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rbn.Models
{
  [Table( "UserProfile" )]
  public class ReaderAliasModel
  {
    [Key]
    public int UserId
    {
      get;
      set;
    }

    [Display( Name = "Reader Alias" )]
    [StringLength( 50 )]
    public string UserName
    {
      get;
      set;
    }
  }
}