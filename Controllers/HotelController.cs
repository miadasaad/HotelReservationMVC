using HotelReservation.Models;
using HotelReservation.Repository;
using HotelReservation.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelReservation.Controllers
{
    public class HotelController : Controller
    {
        IHotelReservation<Hotel> hotel;
        IHotelReservation<City> city;
        public HotelController(IHotelReservation<Hotel> ht, IHotelReservation<City> cty )
        {
            hotel = ht;
            city = cty;
;
        }
        public IActionResult Index()
        {          
            return View(hotel.getAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.cities = new SelectList(city.getAll(),"Id","Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Hotel newhotel)
        {
            if (ModelState.IsValid)
            {
                hotel.addOne(newhotel);
                return RedirectToAction(nameof(Index));
            }
            return View(newhotel);
        }

        public IActionResult Detail(int? id)
        {
            var hotelDetail = hotel.getOne(id);
            if (hotelDetail == null)
                return NotFound();
            return View(hotelDetail);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var hotelDetail = hotel.getOne(id);
            if (hotelDetail == null)
                return NotFound();
            return View(hotelDetail);
        }
        [HttpPost]
        public IActionResult Edit(Hotel newhotel)
        {
            var hotelDetail = hotel.getOne(newhotel.id);
            if (hotelDetail == null)
                return NotFound();
            hotel.updateOne(newhotel);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var hotelDetail = hotel.getOne(id);
            if (hotelDetail == null)
                return NotFound();
            return View(hotelDetail);
        }
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            hotel.deleteOne(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
