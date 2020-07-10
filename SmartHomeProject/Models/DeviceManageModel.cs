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

        public int getModlebyName(string deviceName) {
            for (int i = 0; i < DeviceModels.Length; i++) {
                if (DeviceModels[i].Name == deviceName) {
                    return (i);
                
                }
            }
            
            return(0);
        }
    }
}
