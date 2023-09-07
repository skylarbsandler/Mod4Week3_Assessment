using CommerceMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CommerceMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string currentUser = Request.Cookies["currentUser"];
            ViewData["CurrentUser"] = currentUser;
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string currentUser)
        {
            HttpContext.Response.Cookies.Append("currentUser", currentUser);
            ViewData["CurrentUser"] = currentUser;
            return RedirectToAction("Index");
        }

        public IActionResult Logout(string currentUser)
        {
           HttpContext.Response.Cookies.Delete("currentUser");
           ViewData.Remove("CurrentUser");
           return RedirectToAction("Index");
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