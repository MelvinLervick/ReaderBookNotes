using System;
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

    public ActionResult Create( int id )
    {
      var model = new AuthorModel{Rating = 1, Enabled = true};

      return View( model );
    }

    [HttpPost]
    public ActionResult Create( AuthorModel model )
    {
      try
      {
        AuthorProvider.SaveAuthorDetails( model );
        return View( "Index", AuthorProvider.GetAuthorList( Roles.GetRolesForUser( User.Identity.Name ).Contains( "Administrator" ) ) );
      }
      catch (Exception ex)
      {
        ModelState.AddModelError( "error", ex.Message );
        return View( model );
      }
    }

    public ActionResult Update( int id )
    {
      var model = AuthorProvider.GetAuthorDetails( id );
      return View( model );
    }

    [HttpPost]
    public ActionResult Update( AuthorModel model )
    {
      try
      {
        AuthorProvider.SaveAuthorDetails( model );
        return View( "Index", AuthorProvider.GetAuthorList( Roles.GetRolesForUser( User.Identity.Name ).Contains( "Administrator" ) ) );
      }
      catch (Exception ex)
      {
        ModelState.AddModelError( "error", ex.Message );
        return View(model);
      }
    }

    public ActionResult Delete( int id = 0, int enabled = 0 )
    {
      if (id > 0)
      {
        try
        {
          AuthorProvider.EnableAuthor( id, (enabled == 1) );
        }
        catch (Exception ex)
        {
          ModelState.AddModelError( "error", ex.Message );
        }
      }

      return View( "Index", AuthorProvider.GetAuthorList( Roles.GetRolesForUser( User.Identity.Name ).Contains( "Administrator" ) ) );
    }
  }
}
