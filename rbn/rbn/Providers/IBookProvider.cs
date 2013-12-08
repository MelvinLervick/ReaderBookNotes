using System.Collections.Generic;
using rbn.Models;

namespace rbn.Providers
{
  public interface IBookProvider
  {
    List<BookModel> GetBookList( bool adminUser );
    List<BookModel> GetBookListForAuthor( int authorId, bool adminUser );
    List<BookModel> SearchForBooksByTitle( string searchFor, bool adminUser );
    List<BookModel> SearchForBooksByISBN( string searchFor, bool adminUser );
    BookDetailsModel GetBookDetails( int bookId );
    void SaveBookDetails( BookDetailsModel bookDetails );
    void EnableBook( int bookId, bool enabled );
  }
}