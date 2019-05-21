using MyEvernote.BusinessLayer;
using MyEverNote.WebApp.ViewModels;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

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
            // Note : Kullanıcı username kontrolü
            // Note : Kullanıcı E-Posta kontrolü
            if (ModelState.IsValid)
            {
                if (model.Username == "aaa")
                {
                    ModelState.AddModelError("", "Kullanıcı adı kullanılıyor");
                }

                if (model.Email == "aaa@aaa.com")
                {
                    ModelState.AddModelError("", "E-Posta adresi kullanılıyor");
                }

                foreach (var item in ModelState)
                {
                    if (item.Value.Errors.Count > 0)
                    {
                        return View(model);
                    }
                }

                return RedirectToAction("RegisterOk");
            }

            return View();
        }

        public ActionResult RegisterOk()
        {
            return View();
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