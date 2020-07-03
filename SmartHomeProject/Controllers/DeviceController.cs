using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartHomeProject.Models;

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
            DeviceModel device = new DeviceModel() {name = "Raspi", Image = "raspi" };
            
            return View(device);
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
