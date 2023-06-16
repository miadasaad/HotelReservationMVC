using HotelReservation.Models;
using HotelReservation.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.Controllers
{
    public class EmployeeController : Controller
    {
        IHotelReservation<Employee> db;
        public EmployeeController(IHotelReservation<Employee> _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {

            return View(db.getAll());
        }
    }
}
