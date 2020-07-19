using SppidAdminDTO.Models;
using SppidAdminWebSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SppidAdminWebSite.Controllers
{
    public class ProjectManagerController : Controller
    {
        // GET: ProjectManager
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewProjects()
        {
            List<Project> projects = ProjectManagerViewModel.GetAllProjectsAsync().Result;

            return View(projects);
        }

        // GET: ProjectManager/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProjectManager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectManager/Create
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

        // GET: ProjectManager/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProjectManager/Edit/5
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

        // GET: ProjectManager/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProjectManager/Delete/5
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
