using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Security;
using rbn.Models;
using rbn.Providers;
using rbn.Providers.RbnBLL;

namespace rbn.Controllers
{
  public class HomeController : Controller
  {
    private const string READER_BOOK_NOTES = "Reader Book Notes";

    private IReaderAliasProvider readerAliasProvider;
    internal IReaderAliasProvider ReaderAliasProvider
    {
      get
      {
        return readerAliasProvider ?? (readerAliasProvider = new ReaderAliasProvider());
      }
    }
    private IUserAccountProvider accountProvider;
    internal IUserAccountProvider AccountProvider
    {
      get
      {
        return accountProvider ?? (accountProvider = new UserAccountProvider());
      }
    }

    private IAudienceProvider audienceProvider;
    internal IAudienceProvider AudienceProvider
    {
      get
      {
        return audienceProvider ?? (audienceProvider = new AudienceProvider());
      }
    }

    private IReaderNotesProvider readerNotesProvider;
    internal IReaderNotesProvider ReaderNotesProvider
    {
      get
      {
        return readerNotesProvider ?? (readerNotesProvider = new ReaderNotesProvider());
      }
    }

    public ActionResult Index()
    {
      ViewBag.Message = "Read what other readers have to say about your favorite book.";
      ViewBag.Message1 = "If you want to add notes for others to read, please register or Sign In.";

      return View();
    }

    public ActionResult About()
    {
      ViewBag.Message = READER_BOOK_NOTES;

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Contact Us";

      return View();
    }

    public ActionResult BookNotes( int? id )
    {
      var model = new ReaderNotesModel();
      ViewBag.Message = READER_BOOK_NOTES;
      if ( id != null && id > 0 )
      {
        model = ReaderNotesProvider.GetReaderNote( new PageSelectorModel( id ?? 0, 0, 0, 0, true ) );
        if ( model.ReaderNoteId == 0 )
        {
          model.CreateNewEmptyNote( AccountProvider, User.Identity.Name );
        }
      }
      ViewBag.ReaderId = FillReaderAliasList( model.ReaderId );
      ViewBag.AudienceId = FillAudienceList( model.AudienceId );

      return View( model );
    }

    private IEnumerable<SelectListItem> FillReaderAliasList( int id )
    {
      var items = from value in ReaderAliasProvider.GetReaderAliases()
                  select new SelectListItem
                  {
                    Text = value.Alias,
                    Value = value.ReaderId.ToString(),
                    Selected = value.ReaderId == id,
                  };

      return items; // INSTEAD OF:: new SelectList( ReaderAliasProvider.GetReaderAliases(), "ReaderId", "Alias", id );
    }

    private IEnumerable<SelectListItem> FillAudienceList( int id )
    {
      var items = from value in AudienceProvider.GetAudienceList()
                  select new SelectListItem
                  {
                    Text = value.Name,
                    Value = value.AudienceId.ToString(),
                    Selected = value.AudienceId == id,
                  };

      return items; // INSTEAD OF:: new SelectList( AudienceProvider.GetAudienceList(), "AudienceId", "Name", model.AudienceId );
    }

    /// <summary>
    /// Handle Drpodowl List (Reader Change) and Notes
    /// </summary>
    /// <param name="model"></param>
    /// <param name="buttons">
    /// null: reader change
    /// previous: display previous note
    /// next: display next note
    /// Add Note: if reader is registered, allow reader to add a new note.
    /// Save Changes: if reader is registered, allow the reader to save notes.
    /// </param>
    /// <param name="bookButtons"></param>
    /// <returns></returns>
    [HttpPost]
    public ActionResult BookNotes( ReaderNotesModel model, string buttons, string bookButtons )
    {
      ViewBag.Message = READER_BOOK_NOTES;
      if ( buttons != null )
      {
        switch ( buttons.ToLower() )
        {
          case "next":
            if ( model.BookId > 0 )
            {
              model =
                ReaderNotesProvider.GetReaderNote( new PageSelectorModel( model.BookId, model.NotesThatCanBeViewed,
                  model.Page, model.TotalPages, true ) );
            }
            break;
          case "previous":
            if ( model.BookId > 0 )
            {
              model =
                ReaderNotesProvider.GetReaderNote( new PageSelectorModel( model.BookId, model.NotesThatCanBeViewed,
                  model.Page, model.TotalPages, false ) );
            }
            break;
          case "add new note":
            model.CreateNewEmptyNote( AccountProvider, User.Identity.Name );
            break;
          case "save new note":
            ReaderNotesProvider.SaveReaderNote( model );
            model =
                ReaderNotesProvider.GetReaderNote( new PageSelectorModel( model.BookId, model.NotesThatCanBeViewed,
                  0, 0, true ) );
            break;
          case "cancel":
            if ( model.BookId > 0 )
            {
              model =
                ReaderNotesProvider.GetReaderNote( new PageSelectorModel( model.BookId, model.NotesThatCanBeViewed,
                  model.Page-1, model.TotalPages, true ) );
            }
            break;
        }
      }
      else
      {
        if ( bookButtons != null )
        {
          // Book Rating
        }
      }
      ViewBag.ReaderId = FillReaderAliasList( model.ReaderId );
      ViewBag.AudienceId = FillAudienceList( model.AudienceId );
      ModelState.Clear();

      return View( "BookNotes", model );
    }

    [HttpPost]
    public PartialViewResult Search( SearchBarModel search )
    {
      ViewBag.Message = "Search Book Notes";
      var model = new ReaderNotesModel
      {
        AudienceId = 2,
        AuthorId = 2,
        AuthorName = "Doe, Jack",
        BookId = 1,
        Title = "Test Title",
        ReaderRating = 2,
        BookRating = 2,
        ReaderId = 4,
        ReaderNoteId = 1,
        Notify = true
      };
      ViewBag.ReaderId = FillReaderAliasList( model.ReaderId );
      ViewBag.AudienceId = FillAudienceList( model.AudienceId );

      return PartialView( "BookNotes", model );
    }
  }

  public static class Extensions
  {
    public static ReaderNotesModel CreateNewEmptyNote( this ReaderNotesModel model, IUserAccountProvider provider, string userName )
    {
      var userAccount = provider.GetUserManagedFieldsFromUserAccount( userName );

      if ( model == null )
      {
        return model;
      }

      model.ReaderNoteId = 0;
      model.ReaderId = userAccount.UserId;
      model.Notify = false;
      model.Note = string.Empty;
      model.ReaderRating = userAccount.Rating;

      return model;
    }
  }
}
