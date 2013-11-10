using System;
using System.Collections.Generic;
using System.Linq;
using rbn.Models;

namespace rbn.Providers.RbnBLL.Adapters
{
  public class AuthorAdapter 
  {
    internal static AuthorModel TransformToUiModel( rbnBLL.Models.Author fields )
    {
      return new AuthorModel
      {
        AuthorId = fields.AuthorId,
        FirstName = fields.FirstName,
        MiddleName = fields.MiddleName,
        LastName = fields.LastName,
        Rating = fields.Rating,
        Enabled = fields.Enabled
      };
    }

    internal static List<AuthorModel> TransformToUiModel( IEnumerable<rbnBLL.Models.Author> authorList )
    {
      return authorList.Select(TransformToUiModel).ToList();
    }

    internal static AuthorSelectorModel TransformToUiSelectorModel( rbnBLL.Models.Author fields )
    {
      return new AuthorSelectorModel
      {
        AuthorId = fields.AuthorId,
        AuthorName = String.Format( "{0}, {1} {2}", fields.LastName, fields.FirstName, fields.MiddleName )
      };
    }

    internal static List<AuthorSelectorModel> TransformToUiSelectorModel( IEnumerable<rbnBLL.Models.Author> authorList )
    {
      return authorList.Select( TransformToUiSelectorModel ).ToList();
    }

    internal static rbnBLL.Models.Author TransformToBLLModel( AuthorModel fields )
    {
      return new rbnBLL.Models.Author
      {
        AuthorId = fields.AuthorId,
        FirstName = fields.FirstName,
        MiddleName = fields.MiddleName,
        LastName = fields.LastName,
        Rating = fields.Rating,
        Enabled = fields.Enabled
      };
    }
  }
}