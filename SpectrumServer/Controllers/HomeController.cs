using Microsoft.AspNetCore.Mvc;
using SpectrumServer.Models;
using System.Diagnostics;

namespace SpectrumServer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _env;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        public IActionResult Index()
        {
            string path = _env.ContentRootPath + "\\Documents\\document1.txt";

            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader reader = new StreamReader(fs);

            string content = reader.ReadToEnd();

            return Content(content);
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