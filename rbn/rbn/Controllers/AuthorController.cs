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
    public ActionResult Index( AuthorViewModel model, string authorId )
    {
      string[] actionWithAuthorId = authorId.Split(',');
      //TODO: Redirect to Booklist for selected Author
      // RedirectToAction( <book list index>, authorId );

      model.Message = actionWithAuthorId[0] == "show"
        ? "The Author Book List has not yet been implemented."
        : "The Delete Author option is not yet implemented.";
      
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
