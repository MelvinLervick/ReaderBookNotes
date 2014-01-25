using System.Collections.Generic;
using LibraryDAO.Models;

namespace LibraryDAO
{
    public interface IBookProvider
    {
        IEnumerable<Book> GetBooks( string isbn );
    }
}
