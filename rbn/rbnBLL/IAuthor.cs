using System.Collections.Generic;
using rbnBLL.Models;

namespace rbnBLL
{
  public interface IAuthor
  {
    IEnumerable<Author> AuthorList();
    Author AuthorDetails(int authorId);
    void AuthorCreate(Author newAuthor);
    void AuthorUpdate(Author author);
    void AuthorEnable(int authorId, bool enableFlag);
  }
}