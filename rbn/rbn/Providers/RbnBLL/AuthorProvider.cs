using System;
using System.Collections.Generic;
using rbn.Models;
using rbn.Providers.RbnBLL.Adapters;

namespace rbn.Providers.RbnBLL
{
  public class AuthorProvider : IAuthorProvider
  {
    public AuthorProvider()
    {
    }

    #region IAuthorProvider Members

    public List<AuthorModel> GetAuthorList( bool adminUser )
    {
      return AuthorAdapter.TransformToUiModel(Provider.GetAuthorList( adminUser ));
    }

    public AuthorModel GetAuthorDetails( int authorId )
    {
      var authorDetails = Provider.GetAuthorDetails( authorId );
      return AuthorAdapter.TransformToUiModel(authorDetails);
    }

    public void SaveAuthorDetails( AuthorModel authorDetails )
    {
      if (string.IsNullOrEmpty(authorDetails.FirstName) && string.IsNullOrEmpty(authorDetails.LastName))
      {
        throw new Exception("Unable to save the Author Details because first and last name fields are empty.");
      }
      var authorBLL = AuthorAdapter.TransformToBLLModel(authorDetails);
      Provider.SaveAuthor(authorBLL);
    }

    public void EnableAuthor( int authorId, bool enabled )
    {
      Provider.EnableAuthor( authorId, enabled );
    }

    #endregion

    private rbnBLL.Providers.AuthorProvider provider;
    internal rbnBLL.Providers.AuthorProvider Provider
    {
      get { return provider ?? (provider = new rbnBLL.Providers.AuthorProvider()); }
    }
  }
}