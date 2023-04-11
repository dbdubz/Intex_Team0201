using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using backend.Models;
using Microsoft.AspNetCore.Identity;

namespace backend.Components
{
    public class AgeAtDeathViewComponent : ViewComponent
    {
        //This has nothing to do with the other one in the home controller, this is on its own.

        private mummyContext _mummyContext { get; set; }
        private RoleManager<IdentityRole> _roleManager { get; set; }

        public AgeAtDeathViewComponent(mummyContext data, RoleManager<IdentityRole> roleManager) //Bring in the _mummyContext.
        {
            _mummyContext = data;
            _roleManager = roleManager;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["Ageatdeath"];
            //Pulling out the different genders and sending it back to the view.
            var types = _mummyContext.Burialmain
                .Select(x => x.Ageatdeath)
                .Distinct()
                .OrderBy(x => x);

            return View(types);
        }



    }
}