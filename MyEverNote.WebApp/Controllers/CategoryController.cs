using MyEvernote.BusinessLayer;
using MyEvernote.Entities;
using System.Net;
using System.Web.Mvc;

namespace MyEverNote.WebApp.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Select(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Bozuk Link");
            }

            CategoryManager categoryManager = new CategoryManager();
            Category cat = categoryManager.GetCategoryById(id.Value);
            if (categoryManager == null)
            {
                return HttpNotFound();
            }

            return View(cat.Notes);
        }
    }
}