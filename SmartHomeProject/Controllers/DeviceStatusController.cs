using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartHomeProject.ConnectionManager;
using SmartHomeProject.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartHomeProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceStatusController : ControllerBase
    {
        // GET: api/<DeviceStatusController>
        [HttpGet]
        public IEnumerable<DeviceModel> Get()
        {   
            return DatabaseManager.getDeviceModels();
        }

        // GET api/<DeviceStatusController>/5
        [HttpGet("{model}")]
        public DeviceModel Get(string model)
        {
            Console.WriteLine(model);
            return DatabaseManager.getDeviceModels().Where(device => device.Name == model).FirstOrDefault();
        }

        // POST api/<DeviceStatusController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<DeviceStatusController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<DeviceStatusController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
