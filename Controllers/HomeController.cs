using HotelReservation.Models;
using HotelReservation.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace HotelReservation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHotelReservation<City> db;
        public HomeController(ILogger<HomeController> logger,IHotelReservation<City> _db)
        {
            _logger = logger;
            db = _db;
        }

        public IActionResult Index()
        {
            ViewBag.cities = new SelectList(db.getAll(), "Id", "Name");
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