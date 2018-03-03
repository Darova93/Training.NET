using Newtonsoft.Json;
using Softtek.Academy2018.ToDoListApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Mvc;

namespace Softtek.Academy2018.ToDoListApp.Web.Controllers
{
    public class TagController : Controller
    {
        // GET: Tag
        public ActionResult List()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:2048");

                var result = client.GetAsync("/api/tag");

                string data = result.Result.Content.ReadAsStringAsync().Result;

                List<Tag> list = JsonConvert.DeserializeObject<List<Tag>>(data);

                return View(list);
            }
        }

        public ActionResult New(Tag tag)
        {
            Tag newtag = Get(tag.Id);
            return View(newtag);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Tag tag)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:2048");

                var content = new ObjectContent<Tag>(tag, new JsonMediaTypeFormatter());

                var result = client.PostAsync("/api/tag", content).Result;

                return RedirectToAction("List", "Tag");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Tag tag)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:2048");

                var content = new ObjectContent<Tag>(tag, new JsonMediaTypeFormatter());

                var result = client.PutAsync($"/api/tag/{tag.Id}", content).Result;

                return RedirectToAction("List", "Tag");
            }
        }

        [HttpGet]
        public Tag Get(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:2048");

                var result = client.GetAsync($"/api/tag/{id}");

                string data = result.Result.Content.ReadAsStringAsync().Result;

                Tag tag= JsonConvert.DeserializeObject<Tag>(data);

                return tag;
            }
        }
    }
}