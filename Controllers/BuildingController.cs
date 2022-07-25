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
    public class BuildingController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BuildingController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet(Name = "GetBuildingList")]
        //[Route("Building/{buildingname}")]
        public List< Building> GetBuildingList(string buildingname)
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

            //deserialize object as a list of Buildings in accordance with our json file
            var AllJsonData = JsonConvert.DeserializeObject<MyRoot>(jsonData);

            //if there's no data inside our list then return null or error 
            if (AllJsonData == null)
            {
                return null;
            }
            // If we want to see all json data we should return AllJsonData and change type of method to MyRoot
            //return AllJsonData;

            //filter the list to match with the Buildings name 
            var FullMachbuilding = AllJsonData.buildings.FirstOrDefault(x => x.name == buildingname); 
            //if the name is Full match then will return it
            if (FullMachbuilding != null)
            {
                 List<Building> Buil = new List<Building>();
                Buil.Add(FullMachbuilding);
                return Buil;
            }
            //if the name is not Full match then will return the Partial match
            var PartialMatch = AllJsonData.buildings.Where(x => x.name.Contains(buildingname)).ToList();
            return PartialMatch;

        }

    }
}
