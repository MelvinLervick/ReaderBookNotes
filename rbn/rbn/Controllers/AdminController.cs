using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using rbn.Models;
using rbn.Providers;
using rbn.Providers.RbnBLL;

namespace rbn.Controllers
{
    public class AdminController : Controller
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
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            if (Roles.GetRolesForUser(User.Identity.Name).Contains("Administrator"))
            {
                ViewBag.ReaderId = FillReaderAliasList();
                ViewBag.Roles = FillListOfRoles();
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index( int id )
        {
            return View();
        }

        private IEnumerable<SelectListItem> FillReaderAliasList()
        {
            List<SelectListItem> items = (from value in ReaderAliasProvider.GetReaderAliases()
                select new SelectListItem
                {
                    Text = value.Alias,
                    Value = value.ReaderId.ToString()
                }).ToList();

            return items;
        }

        private dynamic FillListOfRoles()
        {
            List<SelectListItem> items = (from value in Roles.GetAllRoles()
                                          select new SelectListItem
                                          {
                                              Text = value,
                                              Value = value
                                          }).ToList();

            return items;
        }
    }
}
