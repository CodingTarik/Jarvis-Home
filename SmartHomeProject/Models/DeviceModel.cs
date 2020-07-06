namespace SmartHomeProject.Models
{
    public class DeviceModel
    {
        public string Name { get; set; }

        public byte[] Image
        {
            get; set;
        }
        public string Type { get; set; }
        public string Location { get; set; }
        public int port { get; set; }
    }
}