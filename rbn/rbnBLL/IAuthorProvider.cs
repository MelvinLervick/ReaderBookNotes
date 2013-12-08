using System.Collections.Generic;
using rbnBLL.Models;

namespace rbnBLL
{
  public interface IAuthorProvider
  {
    IEnumerable<Author> GetAuthorList( bool adminUser );
    IEnumerable<Author> SearchForAuthor( string searchFor, bool adminUser );
    Author GetAuthorDetails(int authorId);
    void SaveAuthor(Author authorDetails);
    void EnableAuthor( int authorId, bool enableFlag );
  }
}