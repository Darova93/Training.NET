using Newtonsoft.Json;
using Softtek.MVC.Models;
using Softtek.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Softtek.MVC.Controllers
{
    public class UserController : Controller
    {

        public UserController()
        {

        }

        // GET: User
        [HttpGet]
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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            CreateUserViewModel user = Get(id);

            if (user == null)
            {
                return RedirectToAction("Index", "User");
            }

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(User user)
        {

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(User user)
        {
            int id = user.Id;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62999");

                var content = new ObjectContent<User>(user, new JsonMediaTypeFormatter());

                var result = client.PutAsync($"/api/users/{id}", content).Result;
            }

            return RedirectToAction("Index", "User");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62999");

                var result = client.GetAsync($"/api/users/{id}");

                string data = result.Result.Content.ReadAsStringAsync().Result;
                User user = JsonConvert.DeserializeObject<User>(data);
                
                if (user != null)
                {
                    CreateUserViewModel userView = new CreateUserViewModel
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        IS = user.IS,
                        Salary = user.Salary,
                        DateOfBirth = user.DateOfBirth
                    };

                    return View(userView);
                }

                return RedirectToAction("Index", "User");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62999");

                var result = await client.DeleteAsync($"/api/users/{id}");
            }

            return RedirectToAction("Index", "User");
        }

        public CreateUserViewModel Get (int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62999");

                var result = client.GetAsync($"/api/users/{id}");

                string data = result.Result.Content.ReadAsStringAsync().Result;
                User user = JsonConvert.DeserializeObject<User>(data);

                CreateUserViewModel userView = new CreateUserViewModel
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    IS = user.IS,
                    Salary = user.Salary,
                    DateOfBirth = user.DateOfBirth
                };

                return userView;
            }
        }
    }
}