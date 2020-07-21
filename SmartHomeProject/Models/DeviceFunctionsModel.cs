using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHomeProject.Models
{
    public class DeviceFunctionsModel
    {
        public DeviceModel[] DeviceModels { get; set; }
        public int selectedDeviceID { get; set; }
        public bool deviceSelected { get; set; }
        public string functionNameAdded { get; set; }
        public bool addedFunction { get; set; }
        public bool addedSuccess { get; set; }
        public bool functionEdited { get;  set; }
        public bool functionEditSuccess { get;  set; }
        public bool functionDelete { get;  set; }
        public bool functionDeleteSuccess { get; set; }
        public bool sensorAdded { get; set; }
        public bool sensorAddSuccess { get; set; }
        public string sensorName { get; set; }
    }
}
