namespace MyWebAPI.Models
{
    public class MyRoot
    {
        public Building[] buildings { get; set; }
        public Lock[] locks { get; set; }
        public Group[] groups { get; set; }
        public Media[] media { get; set; }

    }
}
