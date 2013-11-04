using System;
using System.Web.Mvc;
using rbn.Models;
using rbn.Providers;
using rbn.Providers.RbnBLL;
using rbn.Views.ViewModels;
using rbnBLL.Models;

namespace rbn.Controllers
{
  public class AuthorController : Controller
  {
    public AuthorController()
    {
    }

    internal AuthorController( IAuthorProvider authorProvider )
    {
      this.authorProvider = authorProvider;
    }

    private IAuthorProvider authorProvider;
    internal IAuthorProvider AuthorProvider
    {
      get
      {
        return authorProvider ?? (authorProvider = new AuthorProvider());
      }
    }

    //
    // GET: /Author/

    public ActionResult Index()
    {
      var model = new AuthorListViewModel{AuthorsList = AuthorProvider.GetAuthorList()};

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
    [ValidateAntiForgeryToken]
    public ActionResult AddAuthorView( string saveAuthorDetails, AuthorViewModel model, FormCollection collection )
    {
      if (ModelState.IsValid)
      {
        try
        {
          model.Author.AuthorId = Convert.ToInt32(collection["Author.AuthorId"]);
          model.Author.Enabled = Convert.ToBoolean(collection["Author.Enabled"]);
          model.Author.FirstName = collection["Author.FirstName"];
          model.Author.MiddleName = collection["Author.MiddleName"];
          model.Author.LastName = collection["Author.LastName"];
          model.Author.Rating = Convert.ToInt32(collection["Author.Rating"]);

          AuthorProvider.SaveAuthorDetails( model.Author );
        }
        catch (Exception ex)
        {
          model.Message = ex.Message;
          return View(model);
        }
      }

      return View( "Index", new AuthorListViewModel{AuthorsList = AuthorProvider.GetAuthorList()} );
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
