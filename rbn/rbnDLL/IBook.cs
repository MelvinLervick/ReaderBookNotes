using System.Collections.Generic;

namespace rbnDLL
{
  public interface IBook
  {
    IEnumerable<Book> BookList();
    Book BookDetails( int bookId );
    void BookCreate( Book newBook );
    void BookUpdate( Book book );
    void BookEnable( int bookId, bool enableFlag );
  }
}