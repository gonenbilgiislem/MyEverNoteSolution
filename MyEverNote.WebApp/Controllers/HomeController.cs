using MyEvernote.BusinessLayer;
using MyEvernote.Entities;
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

            return View($"Index",cat.Notes);
        }
    }
}