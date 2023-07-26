using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using TrenIstasyonlari.Models;

namespace TrenIstasyonlari.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var claims = User.Claims;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}