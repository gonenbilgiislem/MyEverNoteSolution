using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyEvernote.BusinessLayer;

namespace MyEverNote.WebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Test test = new Test();
         //   test.Inserttest();
          //  test.Updatetest();
            return View();
        }
    }
}