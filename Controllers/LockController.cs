using System;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Text.Json;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MyWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MyWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LockController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        private readonly IWebHostEnvironment _webHostEnvironment;
        public LockController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet(Name = "GetLockName")]
        public List<Lock> Get(string lockname)
        {
            //get the root path
            var rootPath = _webHostEnvironment.ContentRootPath;

            //combine the root path with that of our json file inside Data directory
            var fullPath = Path.Combine(rootPath, "Data/sv_lsm_data.json");

            //read all the content inside the file
            var jsonData = System.IO.File.ReadAllText(fullPath);

            //if no data is present then return null or error if you wish
            if (string.IsNullOrWhiteSpace(jsonData))
            {
                return null;
            }

            //Deserialize the object as a list of all data stored in our JSON file
            var AllJsonData = JsonConvert.DeserializeObject<MyRoot>(jsonData);

            //if there's no data inside our list then return null or error 
            if (AllJsonData == null)
            {
                return null;
            }
            // If we want to see all json data we should return AllJsonData and change type of method to MyRoot
            //return AllJsonData;

            //filter the list to match with the Locks name that is being passed in
            var FullMachLock = AllJsonData.locks.FirstOrDefault(x => x.name == lockname);
            //if the name is Full match then will return it
            if (FullMachLock != null)
            {
                List<Lock> loc = new List<Lock>();
                loc.Add(FullMachLock);
                return loc;
            }
            //if the name is not Full match then will return the Partial match
            var PartialMatch = AllJsonData.locks.Where(x => x.name.Contains(lockname)).ToList();
            return PartialMatch;
        }
    }
}
