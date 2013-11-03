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
      var model = new AuthorListViewModel();

      return View(model);
    }

    [HttpPost]
    public ActionResult Index( AuthorListViewModel model, string authorId )
    {
      string[] actionWithAuthorId = authorId.Split(',');
      //TODO: Redirect to Booklist for selected Author
      // RedirectToAction( <book list index>, authorId );

      model.Message = actionWithAuthorId[0] == "show"
        ? "The Author Book List has not yet been implemented."
        : "The Delete Author option is not yet implemented.";
      
      return View(model);
    }

    public ActionResult AddAuthorView()
    {
      var model = new AuthorViewModel();
      return View(model);
    }

    [HttpPost]
    public ActionResult AddAuthorView( AuthorListViewModel model )
    {
      // TODO: Add Author to database

      return View( "Index", new AuthorViewModel() );
    }

    [HttpPost]
    public PartialViewResult Search( SearchBarModel search )
    {
      ViewBag.Message = "Search Book Notes";

      return PartialView( "Index" );
    }

    protected internal void DeleteAuthor(string authorId)
    {
      
    }
  }
}
