using System.Collections.Generic;
using rbn.Models;

namespace rbn.Providers
{
  public interface IBookProvider
  {
    List<BookModel> GetBookList( bool adminUser );
    BookModel GetBookDetails( int bookId );
    void SaveBookDetails( BookModel bookDetails );
    void EnableBook( int bookId, bool enabled );
  }
}