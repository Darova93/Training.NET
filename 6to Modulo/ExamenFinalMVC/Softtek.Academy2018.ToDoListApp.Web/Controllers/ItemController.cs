using Newtonsoft.Json;
using Softtek.Academy2018.ToDoListApp.Web.Models;
using Softtek.Academy2018.ToDoListApp.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy2018.ToDoListApp.Web.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        [HttpGet]
        public ActionResult List()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:2048");

                var result = client.GetAsync("/api/task/getbytitle");

                string data = result.Result.Content.ReadAsStringAsync().Result;

                List<Item> list = JsonConvert.DeserializeObject<List<Item>>(data);

                var filterlist = list.Where(i => i.StatusId <= 4);

                List<ItemViewModel> itemView = filterlist.Select(q => new ItemViewModel
                {
                    Id = q.Id,
                    PriorityId = q.PriorityId,
                    Title = q.Title,
                    Description = q.Description,
                    StatusId = q.StatusId,
                    DueDate = q.DueDate,
                    Status = (Status)q.StatusId
                }).ToList();

                return View(itemView);
            }
        }

        public ActionResult Delete(ItemViewModel item)
        {
            return View(item);
        }

        public ActionResult New(ItemViewModel newitem)
        {
            if (newitem.Id == 0)
            {
                var createitem = new ItemViewModel { Tags = GetTags() };
                return View(createitem);
            }

            ItemViewModel updateitem = Get(newitem.Id);
            updateitem.Tags = GetTags();
            updateitem.Action = "Update";

            return View(updateitem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Item item, string submit)
        {
            switch (submit)
            {
                case "draft":
                    item.StatusId = 1;
                    break;
                case "ready":
                    item.StatusId = 2;
                    break;
            }

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:2048");

                var content = new ObjectContent<Item>(item, new JsonMediaTypeFormatter());

                var result = client.PostAsync("/api/task", content).Result;

                return RedirectToAction("List", "Item");
            }
        }

        public IEnumerable<Tag> GetTags()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:2048");

                var result = client.GetAsync("/api/tag");

                string data = result.Result.Content.ReadAsStringAsync().Result;

                List<Tag> alllist = JsonConvert.DeserializeObject<List<Tag>>(data);

                List<Tag> list = alllist.Where(x => x.IsActive == true).ToList();

                return list;
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            ItemViewModel itemview = Get(id);
            return View(itemview);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Item item)
        {
            int id = item.Id;

            if (item.Status==Status.Done)
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:2048");

                    var content = new ObjectContent<Item>(item, new JsonMediaTypeFormatter());

                    var result = client.PutAsync($"/api/task/{id}", content).Result;
                } 
            }

            return RedirectToAction("Index", "Item");
        }
        
        [HttpPost]
        public async Task<ActionResult> Cancel(ItemViewModel item, string submit)
        {

            ItemViewModel todeleteitem = Get(item.Id);

            if (submit=="yes" && item.Status!=Status.Done)
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:2048");

                    var result = await client.DeleteAsync($"/api/task/archive/{item.Id}");
                } 
            }

            return RedirectToAction("Index", "Item");
        }

        [HttpGet]
        public ItemViewModel Get(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:2048");

                var result = client.GetAsync($"/api/task/{id}");

                string data = result.Result.Content.ReadAsStringAsync().Result;

                Item item = JsonConvert.DeserializeObject<Item>(data);

                item.Status = (Status)item.StatusId;

                ItemViewModel itemview = new ItemViewModel
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    DueDate = item.DueDate,
                    Status = item.Status,
                    PriorityId = item.PriorityId
                };

                return itemview;
            }
        }

    }
}