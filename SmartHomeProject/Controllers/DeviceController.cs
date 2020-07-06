using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartHomeProject.ConnectionManager;
using SmartHomeProject.Models;
using static SmartHomeProject.Program;

namespace SmartHomeProject.Controllers
{
    public class DeviceController : Controller
    {
        private readonly ILogger<DeviceController> _logger;

        public DeviceController(ILogger<DeviceController> logger)
        {
            _logger = logger;
        }

        public IActionResult DeviceManage()
        {
           
            return View(DatabaseManager.getDeviceModels());
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public ActionResult AddDevice()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddDevice(string deviceName, string deviceType, string deviceDescription, string deviceIP, string devicePort, string deviceLocation)
        {
            DatabaseManager.AddNewDevice(deviceName, deviceType, deviceDescription, deviceIP, devicePort, deviceLocation);
            return View();
           
        }
    }
}
