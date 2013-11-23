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
      ViewBag.Message = READER_BOOK_NOTES;
      var model = new ReaderNotesModel
      {
        AudienceId = 1,
        AuthorId = 1,
        AuthorName = "Doe, John",
        BookId = id ?? 0,
        Title = "Test Title",
        Rating = 1,
        ReaderId = 4,
        ReaderNoteId = 1,
        Notify = true
      };
      ViewBag.ReaderId = FillReaderAliasList( model.ReaderId );
      ViewBag.AudienceId = new SelectList( AudienceProvider.GetAudienceList(), "AudienceId", "Name", model.AudienceId );

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

    [HttpPost]
    public ActionResult BookNotes( ReaderNotesModel model, string buttons )
    {
      ViewBag.Message = READER_BOOK_NOTES;
      ViewBag.ReaderId = FillReaderAliasList( model.ReaderId );
      ViewBag.AudienceId = new SelectList( AudienceProvider.GetAudienceList(), "AudienceId", "Name", model.AudienceId );

      return View( "BookNotes", model );
    }

    [HttpPost]
    public PartialViewResult Search( SearchBarModel search )
    {
      ViewBag.Message = "Search Book Notes";

      return PartialView( "BookNotes" );
    }

    public PartialViewResult GetReader( ReaderNotesModel readerNotes )
    {

      return PartialView( "BookNotes" );
    }
  }
}
