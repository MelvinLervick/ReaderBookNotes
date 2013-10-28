using System.Web.Mvc;
using rbn.Models;
using rbn.Views.ViewModels;

namespace rbn.Controllers
{
  public class AuthorController : Controller
  {
    //
    // GET: /Author/

    public ActionResult Index()
    {
      var model = new AuthorViewModel();

      return View(model);
    }

    [HttpPost]
    public PartialViewResult Search( SearchBarModel search )
    {
      ViewBag.Message = "Search Book Notes";

      return PartialView( "Index" );
    }
  }
}
