using Newtonsoft.Json;
using Softtek.MVC.Models;
using Softtek.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Web.Mvc;

namespace Softtek.MVC.Controllers
{
    public class UserController : Controller
    {

        public UserController()
        {

        }
        // GET: User
        public ActionResult Index()
        {
            List<User> user = new List<User>();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62999");

                var result = client.GetAsync("/api/users");

                string data = result.Result.Content.ReadAsStringAsync().Result;
                List<User> list = JsonConvert.DeserializeObject<List<User>>(data);

                return View(list);
            }
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Save(User user)
        {

            user.Salary = 1000;

            user.DateOfBirth = DateTime.Now.AddYears(-20);

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62999");

                var content = new ObjectContent<User>(user, new JsonMediaTypeFormatter());

                //var content = new StringContent(user.ToString(), Encoding.UTF8, "application/json");

                var result =  client.PostAsync("/api/users", content).Result;
            }
            
            return RedirectToAction("Index", "User");
        }
    }
}