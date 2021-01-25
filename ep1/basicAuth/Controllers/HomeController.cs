using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ep1.basicAuth.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }

        public IActionResult Authenticated()
        {
            //build up the identites
            var myClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Yubing"),
                new Claim(ClaimTypes.Email, "Yubing@bingsnote.info"),
                new Claim("Job", "Engineer")
            };

            var my2ndClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Yubing L"),
                new Claim("DriverLicenseYear", "2021")
            };

            var myIdentity = new ClaimsIdentity(myClaims, "Basic1");
            var my2ndIdentity = new ClaimsIdentity(my2ndClaims, "Basic2");

            var userPrincipal = new ClaimsPrincipal(new[] {myIdentity, my2ndIdentity});
            //sign in
            HttpContext.SignInAsync(userPrincipal);

            return RedirectToAction("Index");
        }

    }
}