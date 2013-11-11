using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extensions;
using rbnBLL.Models;
using rbnDLL;
using Book = rbnDLL.Book;

namespace rbnBLL.Providers
{
  public class BookProvider : IBookProvider
  {
    #region IBook Members

    public IEnumerable<Models.Book> GetBookList( bool adminUser = false )
    {
      using (var db = new rbndbEntities())
      {
        var fieldData = (from ua in db.Books
                         where ua.Enabled == !adminUser || ua.Enabled
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
                           Rating = ua.Rating,
                           Enabled = ua.Enabled
                         }).ToList();

        return fieldData;
      }
    }

    public Models.Book GetBookDetails( int bookId )
    {
      if (bookId < 1) { return new Models.Book(); }

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
                           Rating = ua.Rating,
                           Enabled = ua.Enabled
                         }).FirstOrDefault();

        return fieldData;
      }
    }

    public void SaveBook( Models.Book book )
    {
      using (var db = new rbndbEntities())
      {
        var bookList = (from ua in db.Books
                        orderby ua.Title
                        select new
                        {
                          ua.BookId,
                          ua.Title,
                          ua.ISBN
                        }).ToList();
        foreach (var existingBook in bookList)
        {
          if ((book.ISBN == existingBook.ISBN) && (book.BookId != existingBook.BookId) && !string.IsNullOrWhiteSpace( book.ISBN ))
          {
            if (book.BookId == 0)
            {
              throw new Exception( string.Format( "You are trying to add a book with an ISBN that already exists [{0}].",
                existingBook.Title ) );
            }
            else
            {
              throw new Exception( string.Format( "A book with the specified ISBN already exists [{0}].",
                existingBook.Title ) );
            }
          }

          if (book.Title.IsSimilarTo( existingBook.Title ) && (book.BookId != existingBook.BookId) && (book.ISBN == existingBook.ISBN))
          {
            if (book.BookId == 0)
            {
              throw new Exception( string.Format( "You are trying to add a book that already exists [{0}].",
                existingBook.Title ) );
            }
            else
            {
              throw new Exception( string.Format( "A book with the modified Title already exists [{0}].",
                existingBook.Title ) );
            }
          }
        }

        db.Books.AddOrUpdate( new Book
        {
          BookId = book.BookId,
          ISBN = book.ISBN,
          Title = book.Title,
          AuthorId = book.AuthorId,
          AudienceId = book.AudienceId,
          Rating = book.Rating,
          Enabled = book.Enabled,
          LastModifiedDate = DateTime.UtcNow
        } );

        db.SaveChanges();
      }
    }

    public void EnableBook( int bookId, bool enableFlag )
    {
      if (bookId < 1) { return; }

      var book = GetBookDetails( bookId );

      if (book == null)
      {
        throw new Exception( string.Format( "The requested book ({0}) was not found", bookId ) );
      }
      book.Enabled = enableFlag;

      SaveBook( book );
    }

    #endregion
  }
}
