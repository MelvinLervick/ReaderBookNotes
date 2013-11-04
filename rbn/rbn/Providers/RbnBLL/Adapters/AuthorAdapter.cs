using System.Collections.Generic;
using System.Linq;
using rbn.Models;
using rbnBLL.Models;

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
        Enabled = fields.Enabled
      };
    }

    internal static List<AuthorModel> TransformToUiModel( IEnumerable<rbnBLL.Models.Author> authorList )
    {
      return authorList.Select(author => new AuthorModel
      {
        AuthorId = author.AuthorId,
        FirstName = author.FirstName,
        MiddleName = author.MiddleName,
        LastName = author.LastName,
        Enabled = author.Enabled
      }).ToList();
    }

    internal static rbnBLL.Models.Author TransformToBLLModel( AuthorModel fields )
    {
      return new rbnBLL.Models.Author
      {
        AuthorId = fields.AuthorId,
        FirstName = fields.FirstName,
        MiddleName = fields.MiddleName,
        LastName = fields.LastName,
        Enabled = fields.Enabled
      };
    }
  }
}