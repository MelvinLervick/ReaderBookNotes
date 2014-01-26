using System.Collections.Generic;
using LibraryDAO.Models;

namespace LibraryDAO
{
    internal interface IBookProvider
    {
        IEnumerable<Book> GetBooks( string isbn );
    }
}
