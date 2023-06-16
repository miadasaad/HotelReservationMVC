using HotelReservation.Models;
using HotelReservation.Services;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.Repository
{
    public class HotelRepo:IHotelReservation<Hotel>
    {
        HotelContext db;
        public HotelRepo(HotelContext _db)
        {
            db = _db;
        }
        public IEnumerable<Hotel> getAll()
        {
            return db.Hotels.Include(a => a.City).ToList();
        }
        public Hotel getOne(int? id)
        {

            Hotel hotel = db.Hotels.FirstOrDefault(a => a.id == id);
            return hotel;
        }
        public void addOne(Hotel hotel)
        {
            db.Hotels.Add(hotel);
            db.SaveChanges();
        }
        public void updateOne(Hotel hotel)
        {
            Hotel newHotel = db.Hotels.FirstOrDefault(a => hotel.id== a.id);
            newHotel.HotelName = hotel.HotelName;
            db.SaveChanges();
        }
        public void deleteOne(int? id)
        {
            Hotel hotel = db.Hotels.FirstOrDefault(a => a.id == id);
            db.Hotels.Remove(hotel);
            db.SaveChanges();
        }
       
    }
}
