using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartHomeProject.ConnectionManager;
using SmartHomeProject.Models;
using System.Diagnostics;

namespace SmartHomeProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Donation()
        {
            return View();
        }

        public IActionResult Credits()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Index()
        {
            var pageModel = new DeviceManageModel { DeviceModels = DatabaseManager.getDeviceModels() };
            return View(pageModel);
        }

        [HttpGet]
        public IActionResult Settings()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Settings(string selectedTheme)
        {
            DatabaseManager.updateActiveBootstrap(selectedTheme);
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