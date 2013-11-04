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

    public IEnumerable<Models.Author> GetAuthorList()
    {
      using (var db = new rbndbEntities())
      {
        var fieldData = (from ua in db.Authors
                         orderby ua.LastName
                         select new Models.Author
                         {
                           AuthorId = ua.AuthorId,
                           FirstName = ua.FirstName,
                           MiddleName = ua.MiddleName,
                           LastName = ua.LastName,
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
          LastModifiedDate = DateTime.Now
        } );

        db.SaveChanges();
      }
    }

    public void EnableAuthor( int authorId, bool enableFlag )
    {
      using (var db = new rbndbEntities())
      {
        db.Authors.AddOrUpdate( new Author
        {
          AuthorId = authorId,
          Enabled = enableFlag,
          LastModifiedDate = DateTime.Now
        } );

        db.SaveChanges();
      }
    }

    #endregion
  }
}
