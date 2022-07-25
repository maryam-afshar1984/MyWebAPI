using System.ComponentModel.DataAnnotations;

namespace MyWebAPI.Models
{
    public class Building
    {

        [Key]
        public string id { get; set; }
        public string shortCut { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

}

