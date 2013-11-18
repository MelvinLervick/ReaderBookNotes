using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rbn.Models
{
  public class ReaderAliasModel
  {
    public int ReaderId { get; set; }

    public string Alias { get; set; }
  }
}