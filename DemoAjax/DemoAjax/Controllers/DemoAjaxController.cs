using DemoAjax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoAjax.Controllers
{
    public class DemoAjaxController : Controller
    {
        public List<User> GetUsers()
        {
            return new List<User>()
            {
                new User()
                {
                    Id = 1,
                    Name = "Vy Tuấn Dương",
                    Email = "duongvt@gmail.com"
                },
                new User()
                {
                    Id = 2,
                    Name = "Phạm Thị Hà Trang",
                    Email = "trangpt@gmail.com"
                }
            };
        }
        // GET: DemoAjax
        public ActionResult Index()
        {
            return View(GetUsers());
        }
        //POST
        [HttpPost]
        public ActionResult Search(string txtName)
        {
            return View("_UserPartialView",GetUsers().Where(m => m.Name.Contains(txtName)));
        }
    }
}