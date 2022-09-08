using S5_MVC_T2104E_DuongVT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S5_MVC_T2104E_DuongVT.Controllers
{
    public class UserController : Controller
    {
        private static List<User> _user = new List<User>();
        // GET: User
        public ActionResult Index()
        {
            return View(_user);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            var user = _user[id];
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                _user.Add(user);
                return View("Details",user);
            }
            catch
            {
                return View();
            }
        }
    }
}
