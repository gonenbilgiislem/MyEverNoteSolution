using System.Linq;
using System.Web.Mvc;
using MyEvernote.BusinessLayer;

namespace MyEverNote.WebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            NoteManager nm = new NoteManager();
            
          return View(nm.GetAllNotes().OrderByDescending(x=>x.ModifiedOn));
        }
    }
}