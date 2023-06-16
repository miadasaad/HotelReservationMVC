using HotelReservation.Models;
using HotelReservation.Services;

namespace HotelReservation.Repository
{
    public class CityRepo:IHotelReservation<City>
    {
        HotelContext db;
        public CityRepo(HotelContext _db)
        {
            db = _db;
        }
        public IEnumerable<City> getAll()
        {
            return db.Cities.ToList();
        }
        public City getOne(int? id)
        {

            City city = db.Cities.FirstOrDefault(a => a.Id == id);
            return city;
        }
        public void addOne(City city)
        {
            db.Cities.Add(city);
            db.SaveChanges();
        }
        public void updateOne(City city)
        {
            City newCity = db.Cities.FirstOrDefault(a => city.Id == a.Id);
            newCity.Name = city.Name;
            db.SaveChanges();
        }
        public void deleteOne(int? id)
        {
            City city = db.Cities.FirstOrDefault(a => a.Id == id);
            db.Cities.Remove(city);
            db.SaveChanges();
        }
       
    }
}
