using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using backend.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace backend.Controllers
{
    public class HomeController : Controller
    {
        private mummyContext _mummyContext { get; set; }
        private RoleManager<IdentityRole> _roleManager { get; set; }
        private UserManager<IdentityUser> _userManager { get; set; }

        public HomeController(mummyContext data, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager) //Bring in the _mummyContext.
        {
            _mummyContext = data;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        { 
            if (User.Identity.IsAuthenticated)
            {
                var user = _userManager.FindByNameAsync(User.Identity.Name);
                if (User.IsInRole("authenticated") && !user.Result.TwoFactorEnabled)
                {
                    return Redirect("/Identity/Account/Manage/TwoFactorAuthentication");
                }
                else
                {
                    ViewData["ViewName"] = "Index";
                    return View();
                }
            }
            else
            {
                ViewData["ViewName"] = "Index";
                return View();
            }
        }

        public IActionResult Summary(string sex, string HeadDirection, string BurialDepth, string haircolor, string age, int pageNum = 1)
        {
            int pageSize = 25;

            //need to add a new query to accomodate the Color table for textilecolor, the Function table for textile function, and the Structure table for textilestructure

            var x = new BurialViewModel
            {
                Burialmains = _mummyContext.Burialmain
                    .Where(bury => bury.Sex == sex || sex == null && bury.Headdirection == HeadDirection || HeadDirection == null && bury.BurialDepth == BurialDepth || BurialDepth == null && bury.Haircolor == haircolor || haircolor == null && bury.Ageatdeath == age || age == null)
                    .OrderBy(bury => bury.Id)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = (sex == null
                        ? _mummyContext.Burialmain.Count()
                        : _mummyContext.Burialmain.Where(x => x.Sex == sex).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };
            return View(x);
        }

        






        //var GetAll = from E in _mummyContext.Burialmain join BACJ in BurialmainBodyanalysischart on BurialmainBodyanalysischart.MainBurialmainid equals Burialmain.Burialid
        //             from BACJ in _mummyContext.BurialmainBodyanalysischart join BAC in Bodyanalysischart on BACJ.MainBodyanalysischartid equals BAC.Id

        //var GetAll = from E in _mummyContext.Burialmain
        //             join BT in _mummyContext.BurialmainTextile on _mummyContext.BurialmainTextile.MainBurialmainid equals _mummyContext.Burialmain.Id
        //             join T in _mummyContext.Textile on _mummyContext.BurialmainTextile.MainTextileid equals T.Id
        //             select new BurialViewModel { Burialmains = E, BurialmainTextiles = BT, Textiles = T };

        //return View(GetAll);



        public IActionResult Supervised()
        {
            return View();
        }

        public IActionResult Unsupervised()
        {
            return View();
        }

        [Authorize(Roles="authenticated")]
        public IActionResult CreateRole()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = _userManager.FindByNameAsync(User.Identity.Name);
                if (User.IsInRole("authenticated") && !user.Result.TwoFactorEnabled)
                {
                    return Redirect("/Identity/Account/Manage/TwoFactorAuthentication");
                }
                else
                {
                    return View(new IdentityRole());
                }
            }
            else
            {
                return View(new IdentityRole());
            }
        }

        [Authorize(Roles = "authenticated")]
        [HttpPost]
        public async Task<IActionResult> CreateRole(IdentityRole role)
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name);
            if (!user.Result.TwoFactorEnabled)
            {
                return Redirect("/Identity/Account/Manage/TwoFactorAuthentication");
            }
            else
            {
                await _roleManager.CreateAsync(role);
                return RedirectToAction("CreateRole");
            }
        }

        [Authorize(Roles = "authenticated")]
        public IActionResult ViewRoles()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name);
            if (!user.Result.TwoFactorEnabled)
            {
                return Redirect("/Identity/Account/Manage/TwoFactorAuthentication");
            }
            else
            {
                var roles = _roleManager.Roles.ToList();
                return View(roles);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
