using SppidAdminWebAPI.Models;
using SppidAdminWebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static SppidAdminGlobals.Enums;

namespace SppidAdminWebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Summary()
        {
            ViewBag.Title = "Summary of SPPID Items";

            List<SpItem> SppidItems = new List<SpItem>();
            SppidItems.Add(new SpItem { Name = ItemType.PipeRun.ToString(), Type = ItemType.PipeRun });
            SppidItems.Add(new SpItem { Name = ItemType.Equipment.ToString(), Type = ItemType.Equipment });
            SppidItems.Add(new SpItem { Name = ItemType.Nozzle.ToString(), Type = ItemType.Nozzle });
            SppidItems.Add(new SpItem { Name = ItemType.Instrument.ToString(), Type = ItemType.Instrument });
            SppidItems.Add(new SpItem { Name = ItemType.Drawing.ToString(), Type = ItemType.Drawing });


            return View(SppidItems);
        }


        public ActionResult Config()
        {
            ViewBag.Title = "Configure SPPID Plant Details";

            //Project demoProject = new Project()
            //{
            //    Name = "Demo Project",
            //    Description = "A demo sppid project description",
            //    IniPath = @"\\SppidServer\SppidProjectFolder",
            //    DatabaseType = SppidAdminGlobals.Enums.DatabaseType.Oracle,
            //    SiteDataBase = "Site Database Name",
            //    PlantDatabase = "Plant Database Name",
            //    Port = 1521
            //};

            List<Project> SppidProjects = new List<Project>();
            //SppidProjects.Add(demoProject);

            SppidProjects = ProjectViewModel.GetProjects();

            return View(SppidProjects);
        }
    }
}
