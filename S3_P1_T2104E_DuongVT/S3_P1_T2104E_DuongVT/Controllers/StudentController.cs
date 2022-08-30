using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S3_P1_T2104E_DuongVT.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            TempData["Name"] = "Nguyễn Văn A";
            TempData["Age"] = "18";
            TempData["Address"] = "Hà Nội";
            return RedirectToAction("ShowData");
        }
        public ActionResult ShowData()
        {
            return View();
        }
    }
}