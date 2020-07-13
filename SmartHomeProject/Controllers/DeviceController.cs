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

        [HttpPost]
        public IActionResult EditDeviceSettings(string selectedDevice, string deviceNameNew, string deviceType, string deviceDescription, string deviceIP, string devicePort, string deviceLocation)
        {
            bool result = DatabaseManager.UpdateDevice(selectedDevice, deviceNameNew, deviceType, deviceDescription,
                deviceIP, devicePort, deviceLocation);
            DeviceEditModel pageModel = new DeviceEditModel() { selectedDevice = deviceNameNew, DeviceModels = DatabaseManager.getDeviceModels(), deviceNameEdited = selectedDevice, editingFailed = !result};
            return View("EditDevice", pageModel);
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
            DeviceEditModel pageModel = new DeviceEditModel() { DeviceModels = DatabaseManager.getDeviceModels()};
            return View("EditDevice", pageModel);
        }
       
        [HttpPost]
        public IActionResult EditDevice(string model)
        {
            DeviceEditModel pageModel = new DeviceEditModel() { DeviceModels = DatabaseManager.getDeviceModels(), selectedDeviceName = model};
            return View("EditDevice", pageModel);
        }
        [HttpPost]
        public IActionResult DeleteDevice(string returnUrl, string model)
        {
            bool result = DatabaseManager.DeleteDevice(model);
            DeviceManageModel pageModel = new DeviceManageModel() { deleteErrored = !result, deletedDeviceName = model, DeviceModels = DatabaseManager.getDeviceModels() };
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
