namespace SmartHomeProject.Models
{
    public class DeviceManageModel
    {
        public DeviceModel[] DeviceModels { get; set; }
        public string deletedDeviceName { get; set; }
        public bool deleteErrored { get; set; }
    }
}