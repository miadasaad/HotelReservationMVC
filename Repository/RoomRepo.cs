using HotelReservation.Models;
using HotelReservation.Services;

namespace HotelReservation.Repository
{
    public class RoomRepo:IHotelReservation<Room>
    {
        HotelContext db;
        public RoomRepo(HotelContext _db)
        {
            db = _db;
        }

        public void addOne(Room t)
        {
            db.Rooms.Add(t);
            db.SaveChanges();
        }

        public void deleteOne(int? id)
        {
            var room = db.Rooms.FirstOrDefault(a => a.Id == id);
            db.Rooms.Remove(room);
            db.SaveChanges();
        }

        public IEnumerable<Room> getAll()
        {
            return db.Rooms.ToList();
        }

        public Room getOne(int? id)
        {
            return db.Rooms.FirstOrDefault(a => a.Id == id);
        }

        public void updateOne(Room t)
        {
            var room = db.Rooms.FirstOrDefault(a => a.Id == t.Id);
            room.price = t.price;
            db.SaveChanges();
        }
    }
}
