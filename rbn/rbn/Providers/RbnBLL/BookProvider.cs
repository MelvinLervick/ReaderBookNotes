using System;
using System.Collections.Generic;
using rbn.Providers.RbnBLL.Adapters;

namespace rbn.Providers.RbnBLL
{
  public class BookProvider : IBookProvider
  {
    public BookProvider()
    {
    }

    #region IBookProvider Members

    public List<Models.BookModel> GetBookList( bool adminUser )
    {
      return BookAdapter.TransformToUiModel( Provider.GetBookList( adminUser ) );
    }

    public List<Models.BookModel> GetBookListForAuthor( int authorId, bool adminUser )
    {
      return BookAdapter.TransformToUiModel( Provider.GetBookListForAuthor( authorId, adminUser ) );
    }

    public List<Models.BookModel> SearchForBooksByTitle( string searchFor, bool adminUser )
    {
      return BookAdapter.TransformToUiModel( Provider.SearchForBooksByTitle( searchFor, adminUser ) );
    }

    public List<Models.BookModel> SearchForBooksByISBN( string searchFor, bool adminUser )
    {
      return BookAdapter.TransformToUiModel( Provider.SearchForBooksByISBN( searchFor, adminUser ) );
    }

    public Models.BookDetailsModel GetBookDetails( int bookId )
    {
      var bookDetails = Provider.GetBookDetails( bookId );
      return BookAdapter.TransformToUiDetailsModel( bookDetails );
    }

    public void SaveBookDetails( Models.BookModel bookDetails )
    {
      if (string.IsNullOrEmpty( bookDetails.Title ) && (bookDetails.AuthorId == 0))
      {
        throw new Exception( "Unable to save the Book Details because both Title and Author are required." );
      }
      var bookBLL = BookAdapter.TransformToBLLModel( bookDetails );
      Provider.SaveBook( bookBLL );
    }
    public void SaveBookDetails( Models.BookDetailsModel bookDetails )
    {
      if (string.IsNullOrEmpty( bookDetails.Title ) && (bookDetails.AuthorId == 0))
      {
        throw new Exception( "Unable to save the Book Details because both Title and Author are required." );
      }
      var bookBLL = BookAdapter.TransformToBLLModel( bookDetails );
      Provider.SaveBook( bookBLL );
    }


    public void EnableBook( int bookId, bool enabled )
    {
      Provider.EnableBook( bookId, enabled );
    }

    #endregion

    private rbnBLL.Providers.BookProvider provider;
    internal rbnBLL.Providers.BookProvider Provider
    {
      get { return provider ?? (provider = new rbnBLL.Providers.BookProvider()); }
    }
  }
}