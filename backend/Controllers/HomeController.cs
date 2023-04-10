using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Controllers
{
    public class HomeController : Controller
    {
        private mummyContext _mummyContext { get; set; }

        public HomeController(mummyContext data) //Bring in the _mummyContext.
        {
            _mummyContext = data;
        }

        public IActionResult Index()
        {
            var x = _mummyContext.Burialmain
                .ToList();

            return View(x);
        }

        public IActionResult Summary()
        {
            return View();
        }

        public IActionResult Supervised()
        {
            return View();
        }

        public IActionResult Unsupervised()
        {
            return View();
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
