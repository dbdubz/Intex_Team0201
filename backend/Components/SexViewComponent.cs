using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using backend.Models;
using Microsoft.AspNetCore.Identity;

namespace backend.Components
{
    public class SexViewComponent : ViewComponent
    {
        //This has nothing to do with the other one in the home controller, this is on its own.

        private mummyContext _mummyContext { get; set; }
        private RoleManager<IdentityRole> _roleManager { get; set; }

        public SexViewComponent(mummyContext data, RoleManager<IdentityRole> roleManager) //Bring in the _mummyContext.
        {
            _mummyContext = data;
            _roleManager = roleManager;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["Sex"];
            //Pulling out the different types of projects and sending it back to the view.
            var types = _mummyContext.Burialmain
                .Select(x => x.Sex)
                .Where(x => x == "M" || x == "F" || x == " ")
                .Distinct()
                .OrderBy(x => x);

            return View(types);
        }



    }
}
