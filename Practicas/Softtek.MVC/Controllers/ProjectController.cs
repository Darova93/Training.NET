using Softtek.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Softtek.MVC.Controllers
{
    public class ProjectController : Controller
    {
        private readonly List<Project> _context = new List<Project>();

        public ProjectController()
        {
            _context.Add(new Project { Id = 1, Name = "Master Project" });
        }

        // GET: Project
        public ActionResult Index()
        {
            return View(_context);
        }

        public ActionResult New()
        {
            var project = new Project();
            return View(project);
        }

        public ActionResult Save(Project project)
        {
            _context.Add(project);
            return RedirectToAction("Index", "Project");
        }
    }
}