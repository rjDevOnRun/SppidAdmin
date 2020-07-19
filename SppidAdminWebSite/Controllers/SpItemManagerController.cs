using SppidAdminDTO.Models;
using SppidAdminWebSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SppidAdminWebSite.Controllers
{
    public class SpItemManagerController : Controller
    {
        // GET: SpItemManager
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewPipeRuns()
        {
            List<PlantItem> projects = SpItemManagerViewModel.GetPlantItemsAsync().Result;

            return View(projects);
        }

        // GET: SpItemManager/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SpItemManager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SpItemManager/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SpItemManager/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SpItemManager/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SpItemManager/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SpItemManager/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
