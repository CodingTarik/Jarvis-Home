using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHomeProject.Models
{
    public class DeviceManageModel
    {
        public DeviceModel[] DeviceModels { get; set; }
        public string deletedDeviceName { get; set; }
        public bool deleteErrored { get; set; }

        
    }
}
