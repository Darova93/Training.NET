using Softtek.MVC.Models;
using Softtek.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Softtek.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly List<User> _context = new List<User>();

        public UserController()
        {
            _context.Add(new User { Id = 1, Name = "David", ProjectId = 1 });
            Project project = new Project { Id = 1, Name = "Master" };
            _context.SingleOrDefault(x=>x.Id == 1).Project = project;
        }
        // GET: User
        public ActionResult Index()
        {
            return View(_context);
        }

        public ActionResult New()
        {
            var user = new CreateUserViewModel();
            return View(user);
        }

        public ActionResult Save(User user)
        {
            _context.Add(user);
            return RedirectToAction("Index","User");
        }
    }
}