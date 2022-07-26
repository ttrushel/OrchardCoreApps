using Microsoft.AspNetCore.Mvc;
using Movies.Models;
using Movies.ViewModels;
using System.Threading.Tasks;
using YesSql;

namespace Movies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISession _session;
        public HomeController(ISession session)
        {
            _session = session;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(MoviePartViewModel movie)
        {
            var title = movie.Title;
            SaveMovie(title);
            return View(title);
        }

        private bool SaveMovie(string movie)
        {
            var movieRecord = new MoviePart { Title = movie };
            _session.Save(movieRecord);
            return true;
        }
    }
}
