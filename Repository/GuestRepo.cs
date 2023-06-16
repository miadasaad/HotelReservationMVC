using HotelReservation.Models;
using HotelReservation.Services;

namespace HotelReservation.Repository
{
    public class GuestRepo : IHotelReservation<Guest>
    {
        HotelContext db;
        public GuestRepo(HotelContext _db)
        {
            db = _db;
        }
        public void addOne(Guest t)
        {
            db.Guests.Add(t);
            db.SaveChanges();
        }

        public void deleteOne(int? id)
        {
            var guest = db.Guests.FirstOrDefault(a => a.Id == id);
            db.Guests.Remove(guest);
            db.SaveChanges();
        }

        public IEnumerable<Guest> getAll()
        {
            return db.Guests.ToList();
        }

        public Guest getOne(int? id)
        {
           return db.Guests.FirstOrDefault(a => a.Id == id);
        }

        public void updateOne(Guest t)
        {
            var guest = db.Guests.FirstOrDefault(a => a.Id == t.Id);
            guest.Name = t.Name;
            db.SaveChanges();
        }
    }
}
