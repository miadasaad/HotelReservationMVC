using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelReservation.Models;
using HotelReservation.Services;

namespace HotelReservation.Controllers
{
    public class CityController : Controller
    {
        private readonly IHotelReservation<City> _context;

        public CityController(IHotelReservation<City> context)
        {
            _context = context;
        }

        // GET: City
        public  IActionResult Index()
        {
              return View( _context.getAll());
        }

        // GET: City/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || _context.getOne(id) == null)
            {
                return NotFound();
            }

            var city =  _context.getOne(id);
                
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // GET: City/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: City/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,url")] City city)
        {
            if (ModelState.IsValid)
            {
                _context.addOne(city);
                return RedirectToAction(nameof(Index));
            }
            return View(city);
        }

        // GET: City/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city =  _context.getOne(id);
            if (city == null)
            {
                return NotFound();
            }
            return View(city);
        }

        // POST: City/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,url")] City city)
        {
            if (id != city.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.updateOne(city);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CityExists(city.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(city);
        }

        // GET: City/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city =  _context.getOne(id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // POST: City/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_context.getAll() == null)
            {
                return Problem("Entity set 'HotelContext.Cities'  is null.");
            }
            var city =  _context.getOne(id);
            if (city != null)
            {
                _context.deleteOne(city.Id);
            }
            
        
            return RedirectToAction(nameof(Index));
        }

        private bool CityExists(int? id)
        {
          return (_context.getOne(id) != null);
        }
    }
}
