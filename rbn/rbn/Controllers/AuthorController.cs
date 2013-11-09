using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using rbn.Models;
using rbn.Providers;
using rbn.Providers.RbnBLL;

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
      var model = AuthorProvider.GetAuthorList( Roles.GetRolesForUser( User.Identity.Name ).Contains( "Administrator" ) );

      return View(model);
    }

    //[HttpPost]
    //public ActionResult Index( AuthorModel model, string authorId )
    //{
    //  string[] actionWithAuthorId = authorId.Split(',');
    //  //TODO: Redirect to Booklist for selected Author
    //  // RedirectToAction( <book list index>, authorId );

    //  model.Message = actionWithAuthorId[0] == "show"
    //    ? "The Author Book List has not yet been implemented."
    //    : "The Delete Author option is not yet implemented.";
      
    //  return View(model);
    //}

    public ActionResult Create( int id )
    {
      var model = new AuthorModel();
      model.Enabled = true;
      return View( model );
    }

    [HttpPost]
    public ActionResult Create( AuthorModel model )
    {
      AuthorProvider.SaveAuthorDetails( model );
      return View( "Index", AuthorProvider.GetAuthorList( Roles.GetRolesForUser( User.Identity.Name ).Contains( "Administrator" ) ) );
    }

    public ActionResult Update( int id )
    {
      var model = AuthorProvider.GetAuthorDetails( id );
      return View( model );
    }

    [HttpPost]
    public ActionResult Update( AuthorModel model )
    {
      AuthorProvider.SaveAuthorDetails( model );
      return View( "Index", AuthorProvider.GetAuthorList( Roles.GetRolesForUser( User.Identity.Name ).Contains( "Administrator" ) ) );
    }


    [HttpPost]
    public PartialViewResult Search( SearchBarModel search )
    {
      ViewBag.Message = "Search Book Notes";

      return PartialView( "Index" );
    }

    public ActionResult Delete( int id = 0, int enabled = 0 )
    {
      if (id > 0)
      {
        AuthorProvider.EnableAuthor( id, (enabled == 1) );
      }

      return View( "Index", AuthorProvider.GetAuthorList( Roles.GetRolesForUser( User.Identity.Name ).Contains( "Administrator" ) ) );
    }
  }
}
