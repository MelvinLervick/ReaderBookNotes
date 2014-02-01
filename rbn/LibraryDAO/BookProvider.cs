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
        public SearchType GetBy { get; set; }

        protected IDAOProvider Service = null;

        public BookProvider(IDAOProvider service)
        {
            Service = service;
            GetBy = SearchType.Isbn;
        }

        public Book GetBook(string searchFor, SearchType getBy = SearchType.Isbn)
        {
            return Service.GetBook(GetBy, searchFor);
        }

        public IEnumerable<Book> GetBooks(string searchFor, SearchType getBy = SearchType.Isbn)
        {
            return Service.GetBooks(GetBy, searchFor);
        }
    }
}
