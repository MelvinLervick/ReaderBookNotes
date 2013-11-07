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

    public List<Models.BookModel> GetBookList()
    {
      return BookAdapter.TransformToUiModel( Provider.GetBookList() );
    }

    public Models.BookModel GetBookDetails( int bookId )
    {
      var bookDetails = Provider.GetBookDetails( bookId );
      return BookAdapter.TransformToUiModel( bookDetails );
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

    #endregion

    private rbnBLL.Providers.BookProvider provider;
    internal rbnBLL.Providers.BookProvider Provider
    {
      get { return provider ?? (provider = new rbnBLL.Providers.BookProvider()); }
    }
  }
}