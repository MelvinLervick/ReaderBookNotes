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

        public IEnumerable<Book> GetBooksByIsbn( string searchFor )
        {
            var bookProvider = new BookProvider( new IsbndbProvider() )
            {
                GetDigitalBook = GetDigitalBook,
                GetPrintedBook = GetPrintedBook,
                GetBy = SearchType.Isbn
            };

            return bookProvider.GetBooks( searchFor );
        }

        public IEnumerable<Book> GetBooksByAuthor( string searchFor )
        {
            var bookProvider = new BookProvider( new IsbndbProvider() )
            {
                GetDigitalBook = GetDigitalBook,
                GetPrintedBook = GetPrintedBook,
                GetBy = SearchType.Author
            };

            return bookProvider.GetBooks( searchFor );
        }

        public IEnumerable<Book> GetBooksByTitle( string searchFor )
        {
            var bookProvider = new BookProvider(new IsbndbProvider())
            {
                GetDigitalBook = GetDigitalBook,
                GetPrintedBook = GetPrintedBook,
                GetBy = SearchType.Title
            };

            return bookProvider.GetBooks( searchFor );
        }
    }
}
