using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
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
        throw new Exception( string.Format( "The requested author ({0}) was not found", authorId ) );
      }
      author.Enabled = enableFlag;

      SaveAuthor( author );
    }

    #endregion
  }
}
