using System;
using System.Collections.Generic;
using LibraryDAO.Api;
using LibraryDAO.Models;

namespace LibraryDAO
{
    public class BookProvider : IBookProvider
    {
        public bool GetDigitalBook { get; set; }
        public bool GetPrintedBook { get; set; }

        public BookProvider() { }

        public IEnumerable<Book> GetBooks(string isbn)
        {
            // Test ISBNDB API Request
            string apiKey = "W7M9VQ8L";
            string urlForApi = string.Format("http://isbndb.com/api/v2/json/{0}/book/{1}", apiKey, isbn);
            var request = new WebRequestApiProvider(urlForApi);
            var value = request.GetResponse();
            throw new NotImplementedException();
        }
    }
}
