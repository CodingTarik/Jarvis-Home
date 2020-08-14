using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace SmartHomeProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RgbController : ControllerBase
    {
        [HttpPost]
        public string Post([FromBody]JsonElement data)
        {
            data.GetProperty("red").GetString();
            return "success";
        }
    }
}
