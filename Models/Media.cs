﻿using System.ComponentModel.DataAnnotations;

namespace MyWebAPI.Models
{
    public class Media
    {
        public string id { get; set; }
        public string groupId { get; set; }
        public string type { get; set; }
        public string owner { get; set; }
        public object description { get; set; }
        public string serialNumber { get; set; }
    }
}
