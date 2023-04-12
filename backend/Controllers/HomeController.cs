﻿using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using backend.Models.ViewModels;

namespace backend.Controllers
{
    public class HomeController : Controller
    {
        private mummyContext _mummyContext { get; set; }
        private RoleManager<IdentityRole> _roleManager { get; set; }

        public HomeController(mummyContext data, RoleManager<IdentityRole> roleManager) //Bring in the _mummyContext.
        {
            _mummyContext = data;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Summary(string sex, int pageNum = 1)
        {
            int pageSize = 100;

            var x = new BurialViewModel
            {
                Burialmains = _mummyContext.Burialmain
                .Where(bury => bury.Sex == sex || sex == null)
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

        public IActionResult ViewDetails(long id)
        {

            var test = _mummyContext.Burialmain.Where(x => x.Id == id).ToList();

            return View(test);
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

        public IActionResult CreateRole()
        {
            return View(new IdentityRole());
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(IdentityRole role)
        {
            await _roleManager.CreateAsync(role);
            return RedirectToAction("CreateRole");
        }

        public IActionResult ViewRoles()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
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
