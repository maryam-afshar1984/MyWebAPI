using System.ComponentModel.DataAnnotations;

namespace MyWebAPI.Models
{
    public class Lock
    {
        public string id { get; set; }
        public string buildingId { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public object description { get; set; }
        public string serialNumber { get; set; }
        public string floor { get; set; }
        public string roomNumber { get; set; }
    }
}
