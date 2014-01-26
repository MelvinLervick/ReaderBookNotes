using System;
using System.Collections.Generic;
using LibraryDAO.Api;
using LibraryDAO.Models;

namespace LibraryDAO
{
    internal class BookProvider : IBookProvider
    {
        public bool GetDigitalBook { get; set; }
        public bool GetPrintedBook { get; set; }
        public SearchType GetBy = SearchType.Isbn;

        protected IDAOProvider Service = null;

        public BookProvider(IDAOProvider service)
        {
            Service = service;
        }

        public IEnumerable<Book> GetBooks(string isbn)
        {
            return Service.GetBooks( GetBy, isbn );
        }
    }
}
