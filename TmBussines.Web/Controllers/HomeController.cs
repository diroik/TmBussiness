using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TmBussines.Web.Models;
using TmBussines.WebServerOffice.Data;

namespace TmBussines.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository _repository;

        public HomeController(ILogger<HomeController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public JsonResult GetData()
        {
            var model = _repository.TodoItem.AsNoTracking().ToList();

            var ddd = _repository.TodoItem.AsNoTracking().ToList();
            var c = ddd.Count;

            return Json(model);


        }

        public IActionResult Index()
        {
            var js = GetData();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}