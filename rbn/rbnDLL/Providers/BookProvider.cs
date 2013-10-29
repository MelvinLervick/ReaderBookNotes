using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rbnDLL.Providers
{
  public class BookProvider : IBook
  {
    #region IBook Members

    public IEnumerable<Book> BookList()
    {
      throw new NotImplementedException();
    }

    public Book BookDetails( int bookId )
    {
      throw new NotImplementedException();
    }

    public void BookCreate( Book newBook )
    {
      throw new NotImplementedException();
    }

    public void BookUpdate( Book book )
    {
      throw new NotImplementedException();
    }

    public void BookEnable( int bookId, bool enableFlag )
    {
      throw new NotImplementedException();
    }

    #endregion
  }
}
