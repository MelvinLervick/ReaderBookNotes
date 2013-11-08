using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using rbn.Models;
using rbn.Providers;
using rbn.Providers.RbnBLL;

namespace rbn.Controllers
{
  public class BookController : Controller
  {
    public BookController()
    {
    }

    internal BookController( IBookProvider bookProvider )
    {
      this.bookProvider = bookProvider;
    }

    private IBookProvider bookProvider;
    internal IBookProvider BookProvider
    {
      get
      {
        return bookProvider ?? (bookProvider = new BookProvider());
      }
    }

    //
    // GET: /Book/

    public ActionResult Index()
    {
      var model = BookProvider.GetBookList( Roles.GetRolesForUser( User.Identity.Name ).Contains( "Administrator" ) );
      return View( model );
    }

    public ActionResult Create( int id )
    {
      var model = new BookModel();
      return View( model );
    }

    [HttpPost]
    public ActionResult Create( BookModel model )
    {
      BookProvider.SaveBookDetails( model );
      return View( "Index", BookProvider.GetBookList( Roles.GetRolesForUser( User.Identity.Name ).Contains( "Administrator" ) ) );
    }

    public ActionResult Update( int id )
    {
      var model = BookProvider.GetBookDetails( id );
      return View( model );
    }

    [HttpPost]
    public ActionResult Update( BookModel model )
    {
      BookProvider.SaveBookDetails( model );
      return View( "Index", BookProvider.GetBookList( Roles.GetRolesForUser( User.Identity.Name ).Contains( "Administrator" ) ) );
    }

    public ActionResult Delete( int id, int enabled )
    {
      BookProvider.EnableBook( id, (enabled == 1) );
      return View( "Index", BookProvider.GetBookList( Roles.GetRolesForUser( User.Identity.Name ).Contains( "Administrator" ) ) );
    }
  }
}
