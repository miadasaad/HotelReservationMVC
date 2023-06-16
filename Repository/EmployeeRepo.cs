using HotelReservation.Models;
using HotelReservation.Services;

namespace HotelReservation.Repository
{
    public class EmployeeRepo : IHotelReservation<Employee>
    {
        HotelContext db;
        public EmployeeRepo(HotelContext _db) {
            db = _db;
        }
        public void addOne(Employee t)
        {
            db.Employees.Add(t);
            db.SaveChanges();
        }

        public void deleteOne(int? id)
        {
            var employee = db.Employees.FirstOrDefault(a => a.Id == id);
            db.Employees.Remove(employee);
            db.SaveChanges();
        }

        public IEnumerable<Employee> getAll()
        {
            return db.Employees.ToList();
        }

        public Employee getOne(int? id)
        {
            return db.Employees.FirstOrDefault(a => a.Id == id);
        }

        public void updateOne(Employee t)
        {
            var employee = db.Employees.FirstOrDefault(a => a.Id == t.Id);
            employee.Name = t.Name;
            db.SaveChanges();

        }
    }
}
