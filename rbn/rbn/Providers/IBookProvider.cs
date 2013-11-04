using System.Collections.Generic;
using rbn.Models;

namespace rbn.Providers
{
  public interface IBookProvider
  {
    List<BookModel> GetBookList();
    BookModel GetBookDetails( int bookId );
    void SaveAuthorDetails( BookModel bookDetails );
  }
}