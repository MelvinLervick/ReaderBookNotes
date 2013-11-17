using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using rbn.Models;
using rbn.Providers;
using rbn.Providers.RbnBLL;

namespace rbn.Controllers
{
	public class HomeController : Controller
	{
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

    public ActionResult Index()
		{
			ViewBag.Message = "Read what other readers have to say about your favorite book.";
			ViewBag.Message1 = "If you want to add notes for others to read, please register or Sign In.";

			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Reader Book Notes";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Contact Us";

			return View();
		}

    public ActionResult BookNotes()
    {
      var selectUserId = 0;
      ViewBag.Message = "Reader Book Notes";
      if (Roles.GetRolesForUser(User.Identity.Name).Contains("Administrator") ||
          Roles.GetRolesForUser(User.Identity.Name).Contains("Contributor"))
      {
        selectUserId = AccountProvider.GetUserManagedFieldsFromUserAccount(User.Identity.Name).UserId;
      }
      ViewBag.ReaderId = new SelectList(ReaderAliasProvider.GetReaderAliases(), "ReaderId", "Alias",
        selectUserId);

      return View();
    }

    [HttpPost]
    public ActionResult BookNotes( ReaderNotesModel model )
	  {
      ViewBag.ReaderId = new SelectList( ReaderAliasProvider.GetReaderAliases(), "ReaderId", "Alias",
        model.ReaderId );

      return View();
    }

	  [HttpPost]
    public PartialViewResult Search( SearchBarModel search )
    {
      ViewBag.Message = "Search Book Notes";

      return PartialView("BookNotes");
    }

    public PartialViewResult GetReader( ReaderNotesModel readerNotes )
    {

      return PartialView( "BookNotes" );
    }
  }
}
