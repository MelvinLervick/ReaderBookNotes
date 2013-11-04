using System.Collections.Generic;
using rbnBLL.Models;

namespace rbnBLL
{
  public interface IAuthor
  {
    IEnumerable<Author> GetAuthorList();
    Author GetAuthorDetails(int authorId);
    void SaveAuthor(Author authorDetails);
    void EnableAuthor( int authorId, bool enableFlag );
  }
}