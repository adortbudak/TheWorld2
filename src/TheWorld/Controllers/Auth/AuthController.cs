using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Identity;
using TheWorld.Models;
using TheWorld.ViewModels;
using System.Net;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TheWorld.Controllers.Auth
{
    public class AuthController : Controller
    {
        private SignInManager<WorldUser> _signInManager;

        // GET: /<controller>/

        public AuthController(SignInManager<WorldUser> signInManager)
        {
            _signInManager = signInManager;
        }
        
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Trips", "App");
            }

            return View();

        }

        [HttpPost]
        public ActionResult Login(LoginViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.OK;
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return View();
        }
        

    }
}
