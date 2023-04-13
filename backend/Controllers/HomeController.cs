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
            ViewData["ViewName"] = "Index";
            return View();
            /*
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
            }*/
        }

        public IActionResult Details(long burialid)
        {
            var SingleBurial = _mummyContext.Burialmain.Single(x => x.Id == burialid);

            //long id1 = SingleBurial.Id;

            //var interTable = _mummyContext.BurialmainTextile.Single(y => y.MainBurialmainid == id1);

            //long id2 = interTable.MainTextileid;

            //ViewBag.Textile = _mummyContext.Textile.Single(x => x.Id == id2);

            return View("Details", SingleBurial);
        }

        [HttpGet]
        [Authorize(Roles = "authenticated")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "authenticated")]
        public IActionResult Create(Burialmain ar) //HTTP post to save data when a post is done.
        {
            if (ModelState.IsValid)
            {
                _mummyContext.Add(ar);
                _mummyContext.SaveChanges();
                return RedirectToAction("Summary");
            }
            else //Stay in view if not a valid modelstate.
            {
                return View();
            }
        }

        [HttpGet]
        [Authorize(Roles = "authenticated")]
        public IActionResult Delete(long burialid)
        {
            var SingleBurial = _mummyContext.Burialmain.Single(x => x.Id == burialid);

            return View("Delete", SingleBurial);
        }

        [HttpPost]
        [Authorize(Roles = "authenticated")]
        public IActionResult Delete(Burialmain ar)
        {
            //The argument passed is the id of the model that you want to delete.
            _mummyContext.Burialmain.Remove(ar);
            _mummyContext.SaveChanges();
            return RedirectToAction("Summary");
        }

        [HttpGet]
        [Authorize(Roles = "authenticated")]
        public IActionResult Edit(long burialid)
        {
            var SingleBurial = _mummyContext.Burialmain.Single(x => x.Id == burialid);

            return View("Edit", SingleBurial);
        }

        [HttpPost]
        [Authorize(Roles = "authenticated")]
        public IActionResult Edit(Burialmain ar) //Update information in database for the movie.
        {
            _mummyContext.Update(ar);
            _mummyContext.SaveChanges();

            return RedirectToAction("Summary");
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
                color = color.Where(c => c.Value == textilecolor);
                textile_color_intermediary = textile_color_intermediary.Where(tc => color.ToList().Select(c => c.Id).Contains(tc.MainColorid));
                textile = textile.Where(t => textile_color_intermediary.ToList().Select(tc => tc.MainTextileid).Contains(t.Id));
                burial_main_textile_intermediary = burial_main_textile_intermediary.Where(bt => textile.ToList().Select(t => t.Id).Contains(bt.MainTextileid));
                burial_main = burial_main.Where(b => burial_main_textile_intermediary.ToList().Select(bt => bt.MainBurialmainid).Contains(b.Id));
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
            ViewBag.SelectedTextileStructure = structure;

            var colors = burial_main
                .Join(burial_main_textile_intermediary, b => b.Id, bt => bt.MainBurialmainid, (b, bt) => new { b, bt })
                .Join(textile, bbt => bbt.bt.MainTextileid, t => t.Id, (bbt, t) => new { bbt, t })
                .Join(textile_color_intermediary, bbtt => bbtt.t.Id, ct => ct.MainTextileid, (bbtt, tc) => new { bbtt, tc })
                .Join(color, bbtttc => bbtttc.tc.MainColorid, c => c.Id, (bbtttc, c) => new { bbtttc, c })
                .Select(
                    col => new
                    {
                        Id = col.c.Id,
                        Value = col.c.Value.Trim()
                    }
                ).Distinct().ToList();
            IQueryable<Color> finalcolors = color.Where(c => colors.Select(fc => fc.Id).ToList().Contains(c.Id));

            var structures = burial_main
                .Join(burial_main_textile_intermediary, b => b.Id, bt => bt.MainBurialmainid, (b, bt) => new { b, bt })
                .Join(textile, bbt => bbt.bt.MainTextileid, t => t.Id, (bbt, t) => new { bbt, t })
                .Join(textile_structure_intermediary, bbtt => bbtt.t.Id, ct => ct.MainTextileid, (bbtt, tc) => new { bbtt, tc })
                .Join(structure_list, bbtttc => bbtttc.tc.MainStructureid, c => c.Id, (bbtttc, c) => new { bbtttc, c })
                .Select(
                    col => new
                    {
                        Id = col.c.Id,
                        Value = col.c.Value.Trim()
                    }
                ).Distinct().ToList();
            IQueryable<Structure> finalstructures = structure_list.Where(sl => structures.Select(s => s.Id).ToList().Contains(sl.Id));

            var functions = burial_main
                .Join(burial_main_textile_intermediary, b => b.Id, bt => bt.MainBurialmainid, (b, bt) => new { b, bt })
                .Join(textile, bbt => bbt.bt.MainTextileid, t => t.Id, (bbt, t) => new { bbt, t })
                .Join(textile_function_intermediary, bbtt => bbtt.t.Id, ct => ct.MainTextileid, (bbtt, tc) => new { bbtt, tc })
                .Join(textile_function, bbtttc => bbtttc.tc.MainTextilefunctionid, c => c.Id, (bbtttc, c) => new { bbtttc, c })
                .Select(
                    col => new
                    {
                        Id = col.c.Id,
                        Value = col.c.Value
                    }
                ).Distinct().ToList();
            IQueryable<Textilefunction> finalfunctions = textile_function.Where(sl => functions.Select(s => s.Id).ToList().Contains(sl.Id));
            
            /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ THIS WILL WORK WHEN DATA IS PROVIDED ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            var statures = burial_main
                .Join(bodyanalysis_intermediary, b => b.Id, bi => bi.MainBurialmainid, (b, bi) => new { b, bi })
                .Join(bodyanalysis, bbi => bbi.bi.MainBodyanalysischartid, ba => ba.Id, (bbi, ba) => new { bbi, ba })
                .Select(
                    col => new
                    {
                        Id = col.ba.Id,
                        Value = col.ba.Estimatestature
                    }
                ).Distinct().ToList();

            IQueryable<Bodyanalysischart> finalstatures = bodyanalysis.Where(b => statures.Select(s => s.Id).ToList().Contains(b.Id));*/
            
            ViewBag.Sex = burial_main.Select(burial => burial.Sex).Distinct().OrderBy(burial => burial).ToList();
            ViewBag.BurialDepth = burial_main.Select(burial => burial.BurialDepth).Distinct().OrderBy(burial => burial).ToList();
            ViewBag.AgeAtDeath = burial_main.Select(burial => burial.Ageatdeath).Distinct().OrderBy(burial => burial).ToList();
            ViewBag.HeadDirection = burial_main.Select(burial => burial.Headdirection).Distinct().OrderBy(burial => burial).ToList();
            ViewBag.BurialId = burial_main.Select(burial => burial.Id.ToString()).Distinct().OrderBy(burial => burial).ToList();
            ViewBag.HairColor = burial_main.Select(burial => burial.Haircolor).Distinct().OrderBy(burial => burial).ToList();
            ViewBag.TextileFunction = finalfunctions.Distinct().OrderBy(f => f.Value).ToList();
            ViewBag.TextileColor = finalcolors.Distinct().OrderBy(f => f.Value).ToList();
            ViewBag.TextileStructure = finalstructures.Distinct().OrderBy(f => f.Value).ToList();
            //ViewBag.EstimateStature = finalstatures.Distinct().OrderBy(f => f.Estimatestature).ToList(); ~~~~~ VIEWBAG FOR WHEN DATA IS ADDED ~~~~~

            return View(x);
        }

        public IActionResult Supervised()
        {
            return View();
        }

        public IActionResult Unsupervised()
        {
            return View();
        }

        public IActionResult Unsupervised2()
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

        [HttpPost]
        [Authorize(Roles = "authenticated")]
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
