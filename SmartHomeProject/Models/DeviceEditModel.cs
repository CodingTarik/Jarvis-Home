using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SmartHomeProject.Models
{
    public class DeviceEditModel
    {
        public DeviceModel[] DeviceModels { get; set; }
        public string selectedDeviceName;
        [BindProperty]
        public string selectedDevice { get; set; }

        public void OnPost()
        {
           
        }
        public DeviceModel getModlebyName(string deviceName)
        {
            for (int i = 0; i < DeviceModels.Length; i++)
            {
                if (DeviceModels[i].Name == deviceName)
                {
                    return DeviceModels[i];

                }
            }
            return null;
        }
    }
}
