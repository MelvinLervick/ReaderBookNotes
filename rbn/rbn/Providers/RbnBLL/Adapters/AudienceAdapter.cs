using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using rbn.Models;

namespace rbn.Providers.RbnBLL.Adapters
{
  public class AudienceAdapter
  {
    internal static AudienceModel TransformToUiModel( rbnBLL.Models.Audience fields )
    {
      return new AudienceModel
      {
        AudienceId = fields.AudienceId,
        Name = fields.Name
      };
    }

    internal static List<AudienceModel> TransformToUiModel( IEnumerable<rbnBLL.Models.Audience> audienceList )
    {
      return audienceList.Select( TransformToUiModel ).ToList();
    }
  }
}