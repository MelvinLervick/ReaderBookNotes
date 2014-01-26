using System.Collections.Generic;
using LibraryDAO.Api;
using LibraryDAO.Models;

namespace LibraryDAO
{
    /// <summary>
    /// Use ISBNDB Site to Retrieve Data
    /// </summary>
    class IsbndbProvider : IDAOProvider
    {
        private const string ApiKey = "W7M9VQ8L";
        private const string HttpIsbndbComApiV2Book = "http://isbndb.com/api/v2/json/{0}/book/{1}";
        private const string HttpIsbndbComApiV2Author = "http://isbndb.com/api/v2/json/{0}/author/{1}";
        private const string HttpIsbndbComApiV2BooksByTitle = "http://isbndb.com/api/v2/json/{0}/books?q={1}";
        private const string HttpIsbndbComApiV2BooksByAuthor = "http://isbndb.com/api/v2/json/{0}/books?q={1}&i=author_name";
        private const string HttpIsbndbComApiV2Authors = "http://isbndb.com/api/v2/json/{0}/authors?q={1}";

        public IsbndbProvider() { }

        public Book GetBook(SearchType searchBy, string searchFor)
        {
            string urlForApi = "";

            switch (searchBy)
            {
                case SearchType.Title:
                case SearchType.Isbn:
                    urlForApi = string.Format(HttpIsbndbComApiV2Book, ApiKey, searchFor);
                    break;
                case SearchType.Author:
                    urlForApi = string.Format(HttpIsbndbComApiV2Author, ApiKey, searchFor);
                    break;
            }

            var request = new WebRequestApiProvider(urlForApi);

            var value = request.GetResponse();

            return new Book();
        }

        public IEnumerable<Book> GetBooks(SearchType searchBy, string searchFor)
        {
            string urlForApi = "";

            switch (searchBy)
            {
                case SearchType.Author:
                    urlForApi = string.Format(HttpIsbndbComApiV2BooksByAuthor, ApiKey, searchFor);
                    break;
                case SearchType.Title:
                    urlForApi = string.Format(HttpIsbndbComApiV2BooksByTitle, ApiKey, searchFor);
                    break;
            }

            var request = new WebRequestApiProvider(urlForApi);

            var value = request.GetResponse();

            return new List<Book>();
        }
    }
}
