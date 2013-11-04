using System.Web.Mvc;
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
      var model = BookProvider.GetBookList();
      return View(model);
    }

    public ActionResult Create()
    {
      var model = new BookModel();
      return View(model);
    }


    public ActionResult Update( int id )
    {
      var model = BookProvider.GetBookDetails(id);
      return View( model );
    }
  }
}
