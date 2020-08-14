﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SmartHomeProject.ConnectionManager;
using SmartHomeProject.Models;

namespace SmartHomeProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RgbController : ControllerBase
    {
        [HttpPost]
        public string Post([FromBody]JsonElement data)
        {
            try
            {
                double red = data.GetProperty("red").GetInt32();
                double green = data.GetProperty("green").GetInt32();
                double blue = data.GetProperty("blue").GetInt32();
                double alpha = data.GetProperty("alpha").GetInt32();
                int deviceID = data.GetProperty("deviceID").GetInt32();
                int functionID = data.GetProperty("functionID").GetInt32();
                DeviceModel model = DatabaseManager.getDeviceModels().Where(d => d.deviceID == deviceID).First();
                if (model == null)
                {
                    throw new NullReferenceException();
                }
                var function = model.DeviceFunctions.Where(f => f.functionID == functionID).First();
                function.changeRGB(red, green, blue, alpha);
                return "SUCCESS";
            } catch(Exception ex)
            {
                Logger.Logger.logError(Logger.Logger.Category.NETWORK, ex.Message, ex);
                return "ERROR";
            }
        }
    }
}
