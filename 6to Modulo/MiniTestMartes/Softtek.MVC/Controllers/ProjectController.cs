using Newtonsoft.Json;
using Softtek.MVC.Models;
using Softtek.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Mvc;

namespace Softtek.MVC.Controllers
{
    public class ProjectController : Controller
    {

        public ProjectController()
        {

        }

        // GET: Project
        public ActionResult Index()
        {
            List<Project> projects = new List<Project>();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62999");

                var result = client.GetAsync("/api/projects");

                string data = result.Result.Content.ReadAsStringAsync().Result;
                List<Project> list = JsonConvert.DeserializeObject<List<Project>>(data);
                
                return View(list);
            }
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Save(Project project)
        {

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62999");

                var content = new ObjectContent<Project>(project, new JsonMediaTypeFormatter());

                var result = client.PostAsync("/api/projects", content).Result;
            }

            return RedirectToAction("Index", "Project");
        }
    }
}