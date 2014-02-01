using System.Collections.Generic;
using LibraryDAO.Models;

namespace LibraryDAO
{
    internal interface IBookProvider
    {
        Book GetBook(string isbn, SearchType getBy);
        IEnumerable<Book> GetBooks(string isbn, SearchType getBy);
    }
}
