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
using Microsoft.EntityFrameworkCore;

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

        public IActionResult Summary(string id, string sex, string headdirection, string burialdepth, string haircolor, string age, string textilecolor, string function, string structure, string estimatedstature, int pageNum = 1)
        {
            int pageSize = 25;

            IQueryable<Burialmain> burial_main = _mummyContext.Burialmain.AsQueryable();
            if (!string.IsNullOrWhiteSpace(sex)) { burial_main = sex != "empty" ? burial_main.Where(burial => burial.Sex == sex) : burial_main.Where(burial => burial.Sex == null); }
            if (!string.IsNullOrWhiteSpace(age)) { burial_main = burial_main.Where(burial => burial.Ageatdeath == age); }
            if (!string.IsNullOrWhiteSpace(id)) { burial_main = burial_main.Where(burial => Convert.ToString(burial.Id) == id); }
            if (!string.IsNullOrWhiteSpace(headdirection)) { burial_main = burial_main.Where(burial => burial.Headdirection == headdirection); }
            if (!string.IsNullOrWhiteSpace(burialdepth)) { burial_main = burial_main.Where(burial => burial.BurialDepth == burialdepth); }
            if (!string.IsNullOrWhiteSpace(haircolor)) { burial_main = burial_main.Where(burial => burial.Haircolor == haircolor); }

            IQueryable<Textile> textile = _mummyContext.Textile;
            IQueryable<ColorTextile> textile_color_intermediary = _mummyContext.ColorTextile;
            IQueryable<Color> color = _mummyContext.Color;
            IQueryable<BurialmainTextile> burial_main_textile_intermediary = _mummyContext.BurialmainTextile;
            if (!string.IsNullOrWhiteSpace(textilecolor))
            {
                //color = color.Where(c => c.Value == textilecolor).Distinct().ToList();
                //textile_color_intermediary = textile_color_intermediary.Where(tc => tc.MainColorid == color.First().Colorid);
                //var tc_list = textile_color_intermediary.Select(tc => tc.MainTextileid).ToList();
                //textile = textile.Where(t => tc_list.Contains(t.Id));
                //var t_list = textile.Select(t => t.Burialnumber).ToList();
                //textile = textile.Where(t => textile_color_intermediary.Select(tc => tc.MainTextileid).Distinct().ToList().Contains(t.Id));
                //burial_main_textile_intermediary = burial_main_textile_intermediary.Where(bt => bt.MainTextileid == textile.)
                //burial_main = burial_main.Where(burial => t_list.Contains(burial.Burialnumber));
            }

            IQueryable<TextilefunctionTextile> textile_function_intermediary = _mummyContext.TextilefunctionTextile.AsQueryable();
            IQueryable<Textilefunction> textile_function = _mummyContext.Textilefunction.AsQueryable();
            if (!string.IsNullOrWhiteSpace(function))
            {
                textile_function = textile_function.Where(tf => tf.Value == function).Distinct();
                textile_function_intermediary = textile_function_intermediary.Where(tfi => tfi.MainTextilefunctionid == textile_function.First().Textilefunctionid);
                textile = textile.Where(t => textile_function_intermediary.Select(tc => tc.MainTextileid).Distinct().ToList().Contains(t.Id));
                burial_main = burial_main.Where(burial => textile.Select(t => t.Burialnumber).Distinct().ToList().Contains(burial.Burialnumber));
            }

            IQueryable<StructureTextile> textile_structure_intermediary = _mummyContext.StructureTextile.AsQueryable();
            IQueryable<Structure> structure_list = _mummyContext.Structure.AsQueryable();
            if (!string.IsNullOrWhiteSpace(structure))
            {
                structure_list = structure_list.Where(s => s.Value == function).Distinct();
                textile_structure_intermediary = textile_structure_intermediary.Where(tsi => tsi.MainStructureid == structure_list.First().Structureid);
                textile = textile.Where(t => textile_structure_intermediary.Select(ts => ts.MainTextileid).Distinct().ToList().Contains(t.Id));
                burial_main = burial_main.Where(burial => textile.Select(t => t.Burialnumber).Distinct().ToList().Contains(burial.Burialnumber));
            }

            IQueryable<Bodyanalysischart> bodyanalysis = _mummyContext.Bodyanalysischart.AsQueryable();
            IQueryable<BurialmainBodyanalysischart> bodyanalysis_intermediary = _mummyContext.BurialmainBodyanalysischart.AsQueryable();
            if (!string.IsNullOrWhiteSpace(estimatedstature))
            {
                bodyanalysis = bodyanalysis.Where(b => Convert.ToString(b.Estimatestature) == estimatedstature);
                bodyanalysis_intermediary = bodyanalysis_intermediary.Where(bi => bi.MainBodyanalysischartid == bodyanalysis.First().Id);
                burial_main = burial_main.Where(burial => bodyanalysis_intermediary.Select(bi => bi.MainBurialmainid).Distinct().ToList().Contains(burial.Id));
            }

            var x = new BurialViewModel
            {
                Burialmains = burial_main
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


            // ViewBag
            ViewBag.SelectedSex = sex;
            ViewBag.SelectedBurialDepth = burialdepth;
            ViewBag.SelectedAgeAtDeath = age;
            ViewBag.SelectedHeadDirection = headdirection;
            ViewBag.SelectedBurialId = id;
            ViewBag.SelectedTextileFunction = function;
            ViewBag.SelectedHairColor = haircolor;
            ViewBag.SelectedEstimateStature = estimatedstature;
            ViewBag.SelectedTextileColor = textilecolor;


            ViewBag.Sex = _mummyContext.Burialmain.Select(burial => burial.Sex).Distinct().OrderBy(burial => burial).ToList();
            ViewBag.BurialDepth = _mummyContext.Burialmain.Select(burial => burial.BurialDepth).Distinct().OrderBy(burial => burial).ToList();
            ViewBag.AgeAtDeath = _mummyContext.Burialmain.Select(burial => burial.Ageatdeath).Distinct().OrderBy(burial => burial).ToList();
            ViewBag.HeadDirection = _mummyContext.Burialmain.Select(burial => burial.Headdirection).Distinct().OrderBy(burial => burial).ToList();
            ViewBag.BurialId = _mummyContext.Burialmain.Select(burial => burial.Burialid).Distinct().OrderBy(burial => burial).ToList();
            ViewBag.HairColor = _mummyContext.Burialmain.Select(burial => burial.Haircolor).Distinct().OrderBy(burial => burial).ToList();
            ViewBag.TextileFunction = _mummyContext.Textilefunction.Select(function => function.Value).Distinct().OrderBy(function => function).ToList();
            ViewBag.TextileColor = _mummyContext.Color.Select(tc => tc.Value).Distinct().OrderBy(tc => tc).ToList();
            ViewBag.EstimateStature = _mummyContext.Bodyanalysischart.Select(bas => bas.Estimatestature).Distinct().ToList();

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

        [Authorize(Roles = "authenticated")]
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
