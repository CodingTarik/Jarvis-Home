using Microsoft.AspNetCore.Mvc;

namespace SmartHomeProject.Models
{
    public class DeviceEditModel
    {
        public string selectedDeviceName;
        public DeviceModel[] DeviceModels { get; set; }

        [BindProperty] public string selectedDevice { get; set; }

        public string deviceNameEdited { get; set; }
        public bool editingFailed { get; set; }

        public void OnPost()
        {
        }

        public DeviceModel getModlebyName(string deviceName)
        {
            for (var i = 0; i < DeviceModels.Length; i++)
            {
                if (DeviceModels[i].name == deviceName)
                {
                    return DeviceModels[i];
                }
            }

            return null;
        }
    }
}