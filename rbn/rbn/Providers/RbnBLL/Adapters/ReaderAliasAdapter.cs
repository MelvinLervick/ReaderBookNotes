using System.Collections.Generic;
using System.Linq;
using rbn.Models;

namespace rbn.Providers.RbnBLL.Adapters
{
  public class ReaderAliasAdapter
  {
    internal static ReaderAliasModel TransformToUiModel( rbnBLL.Models.UserProfile fields )
    {
      return new ReaderAliasModel
      {
        UserId = fields.UserId,
        UserName = fields.UserName
      };
    }

    internal static List<ReaderAliasModel> TransformToUiModel( IEnumerable<rbnBLL.Models.UserProfile> readerAliasList )
    {
      return readerAliasList.Select( TransformToUiModel ).ToList();
    }
  }
}