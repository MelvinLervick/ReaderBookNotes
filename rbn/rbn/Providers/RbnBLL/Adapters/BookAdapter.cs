using System;
using System.Collections.Generic;
using System.Linq;
using rbn.Models;

namespace rbn.Providers.RbnBLL.Adapters
{
  public class BookAdapter
  {
    internal static BookModel TransformToUiModel( rbnBLL.Models.Book fields )
    {
      return new BookModel
      {
        BookId = fields.BookId,
        Title = fields.Title,
        ISBN = fields.ISBN,
        AuthorId = fields.AuthorId ?? 0,
        AuthorName = String.Format( "{0}, {1} {2}", fields.Author.LastName, fields.Author.FirstName, fields.Author.MiddleName ),
        AudienceId = fields.AudienceId ?? 0,
        AudienceName = fields.Audience.Name,
        Rating = fields.Rating,
        Enabled = fields.Enabled
      };
    }

    internal static List<BookModel> TransformToUiModel( IEnumerable<rbnBLL.Models.Book> bookList )
    {
      return bookList.Select(TransformToUiModel).ToList();
      
      //return bookList.Select( book => new BookModel
      //{
      //  BookId = book.BookId,
      //  Title = book.Title,
      //  ISBN = book.ISBN,
      //  AuthorId = book.AuthorId ?? 0,
      //  AuthorName = String.Format( "{0}, {1} {2}", book.Author.LastName, book.Author.FirstName, book.Author.MiddleName ),
      //  AudienceId = book.AudienceId ?? 0,
      //  AudienceName = book.Audience.Name,
      //  Rating = book.Rating,
      //  Enabled = book.Enabled
      //} ).ToList();
    }

    internal static rbnBLL.Models.Book TransformToBLLModel( BookModel fields )
    {
      return new rbnBLL.Models.Book
      {
        BookId = fields.BookId,
        Title = fields.Title,
        ISBN = fields.ISBN,
        AuthorId = fields.AuthorId,
        AudienceId = fields.AudienceId,
        Rating = fields.Rating,
        Enabled = fields.Enabled
      };
    }
  }
}