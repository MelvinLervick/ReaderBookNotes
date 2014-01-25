using System.Collections.Generic;
using LibraryDAO.Models;

namespace LibraryDAO
{
    public class Library
    {
        public bool GetDigitalBook { get; protected set; }
        public bool GetPrintedBook { get; protected set; }

        public Library( bool digital = true, bool printed = false )
        {
            GetDigitalBook = digital;
            GetPrintedBook = printed;
        }
        public IEnumerable<Book> GetBooks( string isbn )
        {
            var bookProvider = new BookProvider
            {
                GetDigitalBook = GetDigitalBook,
                GetPrintedBook = GetPrintedBook
            };

            return bookProvider.GetBooks( isbn );
        }
    }
}
