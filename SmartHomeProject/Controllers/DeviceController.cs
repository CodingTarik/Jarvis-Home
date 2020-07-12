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

        [HttpGet]
        public IActionResult DeviceManage()
        {
            DeviceManageModel pageModel = new DeviceManageModel() { DeviceModels = DatabaseManager.getDeviceModels() };
            return View(pageModel);
        }
        [HttpGet]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult EditDevice()
        {
            DeviceManageModel pageModel = new DeviceManageModel() { DeviceModels = DatabaseManager.getDeviceModels() };
            return View(pageModel);
        }
        [HttpPost]

        public IActionResult EditDevice(string returnUrl, string model)
        {

               return View();
        }
        [HttpPost]
        public IActionResult DeleteDevice(string returnUrl, string model)
        {
            bool result = DatabaseManager.DeleteDevice(model);
            DeviceManageModel pageModel = new DeviceManageModel() { deleteErrored = !result, deletedDeviceName = model, DeviceModels = DatabaseManager.getDeviceModels() };
            Console.WriteLine("returnUrl: " + returnUrl + " " + pageModel.deleteErrored + " " + pageModel.deletedDeviceName);
            return View("DeviceManage", pageModel);

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
