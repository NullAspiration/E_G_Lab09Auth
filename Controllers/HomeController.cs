using E_G_Lab09Auth.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using E_G_Lab09Auth.Services;

namespace E_G_Lab09Auth.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserrepository _userRepo;

        public HomeController(IUserrepository userRepo, ILogger<HomeController> logger)
        {
            _logger = logger;
            _userRepo = userRepo;
        }
        public async Task<IActionResult> GetUserId()
        {
            if (User.Identity!.IsAuthenticated)
            {
                string username = User.Identity.Name ?? "";
                var user = await _userRepo.ReadByUserNameAsync(username);
                if (user != null)
                {
                    return Content(user.Id);
                }
            }
            return Content("No user");
        }


        public IActionResult Index()
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