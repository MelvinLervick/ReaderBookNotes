using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using rbn.Models;
using rbnBLL.Models;

namespace rbn.Providers.RbnBLL.Adapters
{
  public class ReaderNotesAdapter
  {
    internal static ReaderNotesModel TransformToUiModel( rbnBLL.Models.ReaderNotes fields )
    {
      if (fields == null) return new ReaderNotesModel();

      return new ReaderNotesModel
      {
        ReaderNoteId = fields.ReaderNoteId,
        ReaderId = fields.ReaderId,
        BookId = fields.Book.BookId,
        Title = fields.Book.Title,
        AuthorId = fields.Author.AuthorId,
        AuthorName = String.Format( "{0}, {1} {2}", fields.Author.LastName, fields.Author.FirstName, fields.Author.MiddleName ),
        ReaderRating = fields.ReaderRating,
        BookRating = fields.Book.Rating,
        ReviewerCommentRating = 0,
        ReviewerBookRating = 0,
        AudienceId = fields.AudienceId,
        Note = fields.Note,
        Notify = false,
        NotesThatCanBeViewed = fields.Page.NotesThatCanBeViewed,
        Page = fields.Page.Page, 
        TotalPages = fields.Page.TotalPages, 
        NextPage = fields.Page.NextPage
      };
    }

    internal static rbnBLL.Models.PageSelector TransformToBLLModel( PageSelectorModel fields )
    {
      return new PageSelector( fields.BookId, fields.NotesThatCanBeViewed, fields.Page, fields.TotalPages, fields.NextPage );
    }

    internal static rbnBLL.Models.ReaderNotes TransformToBLLModel( ReaderNotesModel fields )
    {
      return new rbnBLL.Models.ReaderNotes
      {
        ReaderNoteId = fields.ReaderNoteId,
        ReaderId = fields.ReaderId,
        Book = new Book{ BookId = fields.BookId },
        ReaderRating = fields.ReaderRating,
        Note = fields.Note,
        ReviewerCommentRating = fields.ReviewerCommentRating,
        ReviewerBookRating = fields.ReviewerBookRating,
        AudienceId = fields.AudienceId,
        Notify = fields.Notify,
        Page = new PageSelector( fields.BookId, fields.NotesThatCanBeViewed, fields.Page, fields.TotalPages, fields.NextPage )
      };
    }
  }
}