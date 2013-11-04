using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rbnBLL.Models;
using rbnDLL;
using Book = rbnDLL.Book;

namespace rbnBLL.Providers
{
  public class BookProvider : IBookProvider
  {
    #region IBook Members

    public IEnumerable<Models.Book> GetBookList()
    {
      using (var db = new rbndbEntities())
      {
        var fieldData = (from ua in db.Books
                         orderby ua.Title
                         select new Models.Book()
                         {
                           BookId = ua.BookId,
                           ISBN = ua.ISBN,
                           Title = ua.Title,
                           AuthorId = ua.AuthorId,
                           Author = new rbnBLL.Models.Author
                           {
                             AuthorId = ua.Author.AuthorId,
                             FirstName = ua.Author.FirstName,
                             MiddleName = ua.Author.MiddleName,
                             LastName = ua.Author.LastName
                           },
                           AudienceId = ua.AudienceId,
                           Audience = new rbnBLL.Models.Audience
                           {
                             AudienceId = ua.Audience.AudienceId,
                             Name = ua.Audience.Name
                           },
                           Enabled = ua.Enabled
                         }).ToList();

        return fieldData;
      }
    }

    public Models.Book GetBookDetails( int bookId )
    {
      using (var db = new rbndbEntities())
      {
        var fieldData = (from ua in db.Books
                         where ua.BookId == bookId
                         select new Models.Book()
                         {
                           BookId = ua.BookId,
                           ISBN = ua.ISBN,
                           Title = ua.Title,
                           AuthorId = ua.AuthorId,
                           Author = new rbnBLL.Models.Author
                           {
                             AuthorId = ua.Author.AuthorId,
                             FirstName = ua.Author.FirstName,
                             MiddleName = ua.Author.MiddleName,
                             LastName = ua.Author.LastName
                           },
                           AudienceId = ua.AudienceId,
                           Audience = new rbnBLL.Models.Audience
                           {
                             AudienceId = ua.Audience.AudienceId,
                             Name = ua.Audience.Name
                           },
                           Enabled = ua.Enabled
                         }).FirstOrDefault();

        return fieldData;
      }
    }

    public void SaveBook( Models.Book book )
    {
      using (var db = new rbndbEntities())
      {
        db.Books.AddOrUpdate( new Book
        {
          BookId = book.BookId,
          ISBN = book.ISBN,
          Title = book.Title,
          AuthorId = book.AuthorId,
          AudienceId = book.AudienceId,
          Rating = book.Rating,
          Enabled = book.Enabled,
          LastModifiedDate = DateTime.Now
        } );

        db.SaveChanges();
      }
    }

    public void EnableBook( int bookId, bool enableFlag )
    {
      using (var db = new rbndbEntities())
      {
        db.Books.AddOrUpdate( new Book
        {
          BookId = bookId,
          Enabled = enableFlag,
          LastModifiedDate = DateTime.Now
        } );

        db.SaveChanges();
      }
    }

    #endregion
  }
}
