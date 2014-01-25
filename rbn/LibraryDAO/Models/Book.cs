namespace LibraryDAO.Models
{
    public class Book
    {
        public string Title
        {
            get;
            set;
        }

        public string Isbn10
        {
            get;
            set;
        }

        public string Isbn13
        {
            get;
            set;
        }

        public Author Author
        {
            get;
            set;
        }
    }
}
