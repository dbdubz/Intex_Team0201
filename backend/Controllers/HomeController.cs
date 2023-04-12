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
            if (!string.IsNullOrWhiteSpace(sex)) { burial_main = burial_main.Where(burial => burial.Sex == sex); }
            if (!string.IsNullOrWhiteSpace(age)) { burial_main = burial_main.Where(burial => burial.Ageatdeath == age); }
            if (!string.IsNullOrWhiteSpace(id)) { burial_main = burial_main.Where(burial => Convert.ToString(burial.Id) == id); }
            if (!string.IsNullOrWhiteSpace(headdirection)) { burial_main = burial_main.Where(burial => burial.Headdirection == headdirection); }
            if (!string.IsNullOrWhiteSpace(burialdepth)) { burial_main = burial_main.Where(burial => burial.BurialDepth == burialdepth); }
            if (!string.IsNullOrWhiteSpace(haircolor)) { burial_main = burial_main.Where(burial => burial.Haircolor == haircolor); }

            IQueryable<Textile> textile = _mummyContext.Textile.AsQueryable();
            IQueryable<ColorTextile> textile_color_intermediary = _mummyContext.ColorTextile.AsQueryable();
            IQueryable<Color> color = _mummyContext.Color.AsQueryable();
            if (!string.IsNullOrWhiteSpace(textilecolor)) { 
                color = color.Where(c => c.Value == textilecolor).Distinct();
                textile_color_intermediary = textile_color_intermediary.Where(tc => tc.MainColorid == color.First().Colorid);
                textile = textile.Where(t => textile_color_intermediary.Select(tc => tc.MainTextileid).Distinct().ToList().Contains(t.Id));
                burial_main = burial_main.Where(burial => textile.Select(t => t.Burialnumber).Distinct().ToList().Contains(burial.Burialnumber));
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

            /*
            //need to add a new query to accomodate the Color table for textilecolor, the Function table for textile function, and the Structure table for textilestructure

            // __________ FILTER BURIAL BY ATTRIBUTES __________

            // ~~~~~ id ~~~~~
            var id_filter = (id != null) ? _mummyContext.Burialmain.Where(burial => burial.Id == Convert.ToInt32(id)) : _mummyContext.Burialmain;
            
            // ~~~~~ sex ~~~~~
            var sex_filter = (sex != null) ? _mummyContext.Burialmain.Where(burial => burial.Sex == sex) : _mummyContext.Burialmain;
            
            // ~~~~~ head direction ~~~~~
            var head_direction_filter = (headdirection != null) ? _mummyContext.Burialmain.Where(burial => burial.Headdirection == headdirection) : _mummyContext.Burialmain;
            
            // ~~~~~ burial depth ~~~~~
            var burial_depth_filter = (burialdepth != null) ? _mummyContext.Burialmain.Where(burial => burial.BurialDepth == burialdepth) : _mummyContext.Burialmain;
            
            // ~~~~~ hair color ~~~~~
            var hair_color_filter = (haircolor != null) ? _mummyContext.Burialmain.Where(burial => burial.Haircolor == haircolor) : _mummyContext.Burialmain;
            
            // ~~~~~ age ~~~~~
            var age_filter = (age != null) ? _mummyContext.Burialmain.Where(burial => burial.Ageatdeath == age) : _mummyContext.Burialmain;


            // --------------------------------------------------------------------------------


            // __________ FILTER TABLES __________

            // ~~~~~ color ~~~~~
            var color_table = (textilecolor != null) ? _mummyContext.Color.Where(c => c.Value == textilecolor) : _mummyContext.Color;
            
            // ~~~~~ textile function ~~~~~
            var textile_function_table = (function != null) ? _mummyContext.Textilefunction.Where(tf => tf.Value == function) : _mummyContext.Textilefunction;
            
            // ~~~~~ structure ~~~~~
            var structure_table = (structure != null) ? _mummyContext.Structure.Where(s => s.Value == structure) : _mummyContext.Structure;


            // --------------------------------------------------------------------------------


            // __________ GET MAIN TABLES __________


            // ~~~~~ Burial Main ~~~~~
            var burials_main_table = _mummyContext.Burialmain;

            // ~~~~~ Textile ~~~~~
            var textile_table = _mummyContext.Textile;


            // --------------------------------------------------------------------------------


            // __________ GET INTERMEDIARY TABLES __________

            // ~~~~~ Color/Textile ~~~~~
            var color_textile_intermediary = _mummyContext.ColorTextile;
            
            // ~~~~~ Textile/Function ~~~~~
            var textile_function_intermediary = _mummyContext.TextilefunctionTextile;

            // ~~~~~ Structure/Textile ~~~~~
            var structure_textile_intermediary = _mummyContext.StructureTextile;

            // ~~~~~ BurialMain/Textile ~~~~~
            var burial_main_textile_intermediary = _mummyContext.BurialmainTextile;

            // FILTER BY SEX
            IQueryable<Burialmain> burial_sex_filtered =
                from b in burials_main_table
                from s in sex_filter
                where s.Id == b.Id
                //return burialmain
                select new Burialmain
                {
                    Id = b.Id,
                    Ageatdeath = b.Ageatdeath,
                    Sex = b.Sex,
                    Text = b.Text,
                    Headdirection = b.Headdirection,
                    Area = b.Area,
                    Burialnumber = b.Burialnumber,
                    Hair = b.Haircolor
                };

            // FILTER BY Age
            IQueryable<Burialmain> burial_age_filtered =
                from b in burials_main_table
                from a in age_filter
                where a.Id == b.Id
                //return burialmain
                select new Burialmain
                {
                    Id = b.Id,
                    Ageatdeath = b.Ageatdeath,
                    Sex = b.Sex,
                    Text = b.Text,
                    Headdirection = b.Headdirection,
                    Area = b.Area,
                    Burialnumber = b.Burialnumber,
                    Hair = b.Haircolor
                };

            // SEX_AGE
            IQueryable<Burialmain> sex_age_filtered =
                from s in burial_sex_filtered
                from a in burial_age_filtered
                where a.Id == s.Id
                //return burialmain
                select new Burialmain
                {
                    Id = s.Id,
                    Ageatdeath = s.Ageatdeath,
                    Sex = s.Sex,
                    Text = s.Text,
                    Headdirection = s.Headdirection,
                    Area = s.Area,
                    Burialnumber = s.Burialnumber,
                    Hair = s.Haircolor
                };

            // Filter by hair color
            IQueryable<Burialmain> hair_color_filtered =
                from sa in sex_age_filtered
                from hc in hair_color_filter
                where hc.Id == sa.Id
                select new Burialmain
                {
                    Id = sa.Id,
                    Ageatdeath = sa.Ageatdeath,
                    Sex = sa.Sex,
                    Text = sa.Text,
                    Headdirection = sa.Headdirection,
                    Area = sa.Area,
                    Burialnumber = sa.Burialnumber,
                    Hair = sa.Haircolor
                };

            //Filter by burial depth
            IQueryable<Burialmain> burial_depth_filtered =
                from hc in hair_color_filtered
                from bd in burial_depth_filter
                where bd.Id == hc.Id
                select new Burialmain
                {
                    Id = hc.Id,
                    Ageatdeath = hc.Ageatdeath,
                    Sex = hc.Sex,
                    Text = hc.Text,
                    Headdirection = hc.Headdirection,
                    Area = hc.Area,
                    Burialnumber = hc.Burialnumber,
                    Hair = hc.Haircolor
                };

            IQueryable<Burialmain> head_direction_filtered =
                from bd in burial_depth_filtered
                from hd in head_direction_filter
                where hd.Id == bd.Id
                select new Burialmain
                {
                    Id = bd.Id,
                    Ageatdeath = bd.Ageatdeath,
                    Sex = bd.Sex,
                    Text = bd.Text,
                    Headdirection = bd.Headdirection,
                    Area = bd.Area,
                    Burialnumber = bd.Burialnumber,
                    Hair = bd.Haircolor
                };

            IQueryable<Burialmain> id_filtered =
                from hd in head_direction_filtered
                from i in id_filter
                where i.Id == hd.Id
                select new Burialmain
                {
                    Id = hd.Id,
                    Ageatdeath = hd.Ageatdeath,
                    Sex = hd.Sex,
                    Text = hd.Text,
                    Headdirection = hd.Headdirection,
                    Area = hd.Area,
                    Burialnumber = hd.Burialnumber,
                    Hair = hd.Haircolor
                };
            */


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

            IQueryable<Burialmain> burials = burial_main;
            IQueryable<Textile> textiles = textile;
            IQueryable<Textilefunction> textilefunctions = textile_function;
            IQueryable<TextilefunctionTextile> tf_merged = textile_function_intermediary;
            IQueryable<Color> colors = _mummyContext.Color.Distinct();

            ViewBag.Sex = burial_main.Select(burial => burial.Sex).Distinct().OrderBy(burial => burial).ToList();
            ViewBag.BurialDepth = burial_main.Select(burial => burial.BurialDepth).Distinct().OrderBy(burial => burial).ToList();
            ViewBag.AgeAtDeath = burial_main.Select(burial => burial.Ageatdeath).Distinct().OrderBy(burial => burial).ToList();
            ViewBag.HeadDirection = burial_main.Select(burial => burial.Headdirection).Distinct().OrderBy(burial => burial).ToList();
            ViewBag.BurialId = burial_main.Select(burial => burial.Burialid).Distinct().OrderBy(burial => burial).ToList();
            ViewBag.HairColor = burial_main.Select(burial => burial.Haircolor).Distinct().OrderBy(burial => burial).ToList();
            //ViewBag.TextileFunction = textilefunctions.Where(tf => textile_function_intermediary.Select(tfi => tfi.MainTextilefunctionid).ToList().Contains(tf.Id)).OrderBy(tf => tf).ToList();
            //ViewBag.TextileColor = color.Where(c => textile_color_intermediary.Select(tc => tc.MainColorid).Distinct().ToList().Contains(c.Id)).OrderBy(c => c).ToList();
            //ViewBag.TextileStructure = structure_list.Where(s => textile_structure_intermediary.Select(ts => ts.MainStructureid).Distinct().ToList().Contains(s.Id)).OrderBy(s => s).ToList();
            //ViewBag.EstimateStature = bodyanalysis.Where(b => bodyanalysis_intermediary.Select(bi => bi.MainBodyanalysischartid).ToList().Contains(b.Id)).OrderBy(b => b).ToList();

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
