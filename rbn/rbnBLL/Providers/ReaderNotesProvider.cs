using System;
using System.Collections.Generic;
using System.Data.Common.CommandTrees;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rbnBLL.Models;
using rbnDLL;

namespace rbnBLL.Providers
{
  public class ReaderNotesProvider : IReaderNotesProvider
  {
    #region IReaderNotesProvider Members

    public Models.ReaderNotes GetReaderNote( Models.PageSelector page )
    {
      using (var db = new rbndbEntities())
      {
        Models.ReaderNotes readerNote;

        var result = (from rn in db.GetNextReaderNote( page.BookId,
          page.NotesThatCanBeViewed, page.Page,
          page.TotalPages, page.NextPage )
          select rn).FirstOrDefault();

        if ( result == null )
        {
          readerNote = new Models.ReaderNotes
          {
            ReaderNoteId = 0,
            ReaderId = 0,
            Book = new BookProvider().GetBookDetails( page.BookId ),
            ReaderRating = 0,
            Note = string.Empty,
            AudienceId = 0,
            ReviewerBookRating = 0,
            ReviewerCommentRating = 0,
            Notify = false,
            Page = page
          };
          readerNote.Author = readerNote.Book.Author;
          readerNote.Page.Page = 0;
          readerNote.Page.TotalPages = 0;
        }
        else
        {
          readerNote = new Models.ReaderNotes
          {
            ReaderNoteId = result.ReaderNoteId,
            ReaderId = result.ReaderId,
            Book = new BookProvider().GetBookDetails(result.BookId),
            ReaderRating = result.ReaderRating ?? 0,
            Note = result.Note,
            AudienceId = result.AudienceId,
            ReviewerBookRating = 0,
            ReviewerCommentRating = 0,
            Notify = false,
            Page = page
          };
          readerNote.Author = readerNote.Book.Author;
          readerNote.Page.Page = ((int? )result.Page ?? 0);
          readerNote.Page.TotalPages = (result.TotalNotes ?? 0);
        }

        return readerNote;
      }
    }

    public void SaveReaderNotes( Models.ReaderNotes readerNotes )
    {
      using (var db = new rbndbEntities())
      {
        db.ReaderNotes.AddOrUpdate( new rbnDLL.ReaderNotes
        {
          ReaderNoteId = readerNotes.ReaderNoteId,
          ReaderId = readerNotes.ReaderId,
          BookId = readerNotes.Book.BookId,
          Rating = readerNotes.ReviewerCommentRating,
          AudienceId = readerNotes.AudienceId,
          Note = readerNotes.Note,
          Notify = readerNotes.Notify,
          Enabled = true,
          LastModifiedDate = DateTime.UtcNow
        } );

        db.SaveChanges();
      }
    }

    public void EnableReaderNotes( int readerNotesId, bool enableFlag )
    {
      if (readerNotesId < 1) { return; }

      using (var db = new rbndbEntities())
      {
        var note = (from rn in db.ReaderNotes
                    where rn.ReaderNoteId == readerNotesId
                    select rn).FirstOrDefault();

        if ( note == null )
        {
          throw new Exception( string.Format( "The requested Reader Note ({0}) was not found", readerNotesId ) );
        }
        note.Enabled = enableFlag;

        db.SaveChanges();
      }
    }

    #endregion
  }
}
