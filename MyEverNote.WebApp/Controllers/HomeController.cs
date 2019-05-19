using System;
using MyEvernote.BusinessLayer;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MyEverNote.WebApp.ViewModels;

namespace MyEverNote.WebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            NoteManager nm = new NoteManager();

            //  return View(nm.GetAllNotes().OrderByDescending(x => x.ModifiedOn));
            return View(nm.GetAllNotesQueryable().OrderByDescending(x => x.ModifiedOn).ToList());
        }

        public ActionResult ByCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var noteManager = new CategoryManager();
            var cat = noteManager.GetCategoryById(id.Value);
            if (cat == null)
            {
                return HttpNotFound();
            }

            return View($"Index", cat.Notes);
        }

        public ActionResult MostLiked()
        {
            NoteManager nm = new NoteManager();
            return View("Index", nm.GetAllNotesQueryable().OrderByDescending(x => x.LikeCount).ToList());
        }

        public ActionResult Hakkimizda()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {

            }

            // Note : Kullanıcı username kontrolü
            // Note : Kullanıcı E-Posta kontrolü
            return View(model);
        }

        public ActionResult UserActivate(Guid activate_id)
        {
            // Note: Kullanıcı aktivasyonu sağlanacak
            return View(activate_id);
        }

        public ActionResult Logout()
        {
            return View();
        }
    }
}