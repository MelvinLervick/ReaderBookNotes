using System;
using System.Collections.Generic;
using LibraryDAO.Api;
using LibraryDAO.Models;

namespace LibraryDAO
{
    internal class IsbndbBookProvider : IBookProvider
    {
        private const string ApiKey = "W7M9VQ8L";
        private const string HttpIsbndbComApiV2Book = "http://isbndb.com/api/v2/json/{0}/book/{1}";
        public bool GetDigitalBook { get; set; }
        public bool GetPrintedBook { get; set; }

        public IsbndbBookProvider() { }

        public IEnumerable<Book> GetBooks(string isbn)
        {
            // Test ISBNDB API Request
            string urlForApi = string.Format(HttpIsbndbComApiV2Book, ApiKey, isbn);
            var request = new WebRequestApiProvider(urlForApi);

            var value = request.GetResponse();

            return new List<Book>();
        }
    }
}
