using System.Collections.Generic;
using rbn.Models;

namespace rbn.Providers
{
  public interface IAuthorProvider
  {
    List<AuthorModel> GetAuthorList( bool adminUser );
    List<AuthorModel> SearchForAuthor( string searchFor, bool adminUser );
    List<AuthorSelectorModel> GetAuthorSelectorList();
    AuthorModel GetAuthorDetails(int authorId);
    void SaveAuthorDetails(AuthorModel authorDetails);
    void EnableAuthor( int authorId, bool enabled );
  }
}