using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryDAO.Models;

namespace LibraryDAO
{
    interface IDAOProvider
    {
        Book GetBook(SearchType searchBy, string searchFor);
        IEnumerable<Book> GetBooks(SearchType searchBy, string searchFor);
    }
}
