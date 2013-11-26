using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using rbn.Models;

namespace rbn.Providers.RbnBLL.Adapters
{
  public class ReaderNotesAdapter
  {
    internal static ReaderNotesModel TransformToUiModel( rbnBLL.Models.ReaderNotes fields )
    {
      return new ReaderNotesModel
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

    internal static rbnBLL.Models.ReaderNotes TransformToBLLModel( PageSelectorModel fields )
    {
      return new rbnBLL.Models.ReaderNotes
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

    internal static rbnBLL.Models.ReaderNotes TransformToBLLModel( ReaderNotesModel fields )
    {
      return new rbnBLL.Models.ReaderNotes
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