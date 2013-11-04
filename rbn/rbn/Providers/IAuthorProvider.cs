using System.Collections.Generic;
using rbn.Models;

namespace rbn.Providers
{
  public interface IAuthorProvider
  {
    List<AuthorModel> GetAuthorList();
    AuthorModel GetAuthorDetails(int authorId);
    void SaveAuthorDetails(AuthorModel authorDetails);
  }
}