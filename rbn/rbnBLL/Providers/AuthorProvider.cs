using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Extensions;
using rbnDLL;

namespace rbnBLL.Providers
{
  public class AuthorProvider : IAuthorProvider
  {
    #region IAuthor Members

    public IEnumerable<Models.Author> GetAuthorList( bool adminUser = false )
    {
      using (var db = new rbndbEntities())
      {
        var fieldData = (from ua in db.Authors
                         where ua.Enabled == !adminUser || ua.Enabled
                         orderby ua.LastName
                         select new Models.Author
                         {
                           AuthorId = ua.AuthorId,
                           FirstName = ua.FirstName,
                           MiddleName = ua.MiddleName,
                           LastName = ua.LastName,
                           Rating = ua.Rating,
                           Enabled = ua.Enabled
                         }).ToList();

        return fieldData;
      }
    }

    public IEnumerable<Models.Author> SearchForAuthor( string searchFor, bool adminUser = false )
    {
      using (var db = new rbndbEntities())
      {
        var fieldData = (from ua in db.Authors
                         where (ua.Enabled == !adminUser || ua.Enabled) && (ua.FirstName.Contains( searchFor ) || ua.LastName.Contains( searchFor ) || ua.MiddleName.Contains( searchFor ) )
                         orderby ua.LastName
                         select new Models.Author
                         {
                           AuthorId = ua.AuthorId,
                           FirstName = ua.FirstName,
                           MiddleName = ua.MiddleName,
                           LastName = ua.LastName,
                           Rating = ua.Rating,
                           Enabled = ua.Enabled
                         }).ToList();

        return fieldData;
      }
    }

    public Models.Author GetAuthorDetails( int authorId )
    {
      using (var db = new rbndbEntities())
      {
        var fieldData = (from ua in db.Authors
                         where ua.AuthorId == authorId
                         select new Models.Author
                         {
                           AuthorId = ua.AuthorId,
                           FirstName = ua.FirstName,
                           MiddleName = ua.MiddleName,
                           LastName = ua.LastName,
                           Rating = ua.Rating,
                           Enabled = ua.Enabled
                         }).FirstOrDefault();

        return fieldData;
      }
    }

    public void SaveAuthor( Models.Author authorDetails )
    {
      using (var db = new rbndbEntities())
      {
        var fieldData = (from ua in db.Authors
                         orderby ua.LastName
                         select new 
                         {
                           ua.AuthorId,
                           ua.FirstName,
                           ua.MiddleName,
                           ua.LastName
                         }).ToList();
        var authorName = string.Format("{0}, {1} {2}", authorDetails.LastName, authorDetails.FirstName, authorDetails.MiddleName);
        foreach (var name in fieldData)
        {
          var authorNameFromList = string.Format( "{0}, {1} {2}", name.LastName, name.FirstName, name.MiddleName );
          if (authorName.IsSimilarTo(authorNameFromList) && (name.AuthorId != authorDetails.AuthorId))
          {
            if (authorDetails.AuthorId == 0)
            {
              throw new Exception(string.Format("You may be trying to add an existing Author {0}.", authorNameFromList));
            }
            else
            {
              throw new Exception(string.Format("Your changes cause this Author {0} to be similar to Author {1}.",
                authorName, authorNameFromList));
            }
          }
        }

        db.Authors.AddOrUpdate( new Author
        {
          AuthorId = authorDetails.AuthorId,
          FirstName = authorDetails.FirstName,
          MiddleName = authorDetails.MiddleName,
          LastName = authorDetails.LastName,
          Rating = authorDetails.Rating,
          Enabled = authorDetails.Enabled,
          LastModifiedDate = DateTime.UtcNow
        } );

        db.SaveChanges();
      }
    }

    public void EnableAuthor( int authorId, bool enableFlag )
    {
      if (authorId < 1) { return; }

      var author = GetAuthorDetails( authorId );

      if (author == null)
      {
        throw new Exception( string.Format( "The requested author's record ({0}) was not found", authorId ) );
      }
      author.Enabled = enableFlag;

      SaveAuthor( author );
    }

    #endregion
  }
}
